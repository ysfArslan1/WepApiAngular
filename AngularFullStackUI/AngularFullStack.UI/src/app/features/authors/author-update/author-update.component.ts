import { Component, OnInit, inject } from '@angular/core';
import { UpdateAuthorRequest } from '../models/update-author-request.model';
import { AuthorsService } from '../services/authors.service';
import { ActivatedRoute, RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-author-update',
  standalone: true,
  imports: [RouterOutlet,CommonModule,HttpClientModule,FormsModule],
  templateUrl: './author-update.component.html',
  styleUrl: './author-update.component.css'
})
export class AuthorUpdateComponent implements OnInit {
  
  model : UpdateAuthorRequest;
  id:number;
  authorService = inject(AuthorsService)
  constructor(private route: ActivatedRoute){
    this.id=0;
    this.model={
      name:'',
      surname:'',
      birthdate: new Date()
    };
  }

  ngOnInit(): void{

    this.route.params.subscribe(params => {
      this.id = +params['id']; // Extracting the 'id' parameter from the URL
    });

    this.authorService.getAuthorById(this.id)
    .subscribe({
      next: (data) => {
        console.log(data)
        this.model.name=data.name;
        this.model.surname=data.surname;

        const date = data.birthdate.split(' ')[0]
        const [month, day, year] = date.split('.');
        this.model.birthdate = new Date(parseInt(year), parseInt(month) - 1, parseInt(day));

      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  onFormSubmit(){
    console.log(this.model);
    
    this.authorService.updateAuthor(this.id,this.model).subscribe({
      next(response) {
        console.log('succsesful');
        console.log(response);
      },
      error(err) {
        console.log(err);
      },
    })
  }
}
