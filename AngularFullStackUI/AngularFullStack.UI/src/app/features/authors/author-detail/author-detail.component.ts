import { Component, inject } from '@angular/core';
import { AuthorResponse } from '../models/author-responce.model';
import { AuthorsService } from '../services/authors.service';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-author-detail',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './author-detail.component.html',
  styleUrl: './author-detail.component.css'
})
export class AuthorDetailComponent {

  model: AuthorResponse;

  authorsService = inject(AuthorsService);
  id:number;
  constructor(private route: ActivatedRoute){
    this.id=0;
    this.model={
      id:0,
      name:'',
      surname:'',
      birthdate:''
    };
  }

  ngOnInit(): void{
    
    this.route.params.subscribe(params => {
      this.id = +params['id']; // Extracting the 'id' parameter from the URL
    });

    this.authorsService.getAuthorById(this.id)
    .subscribe({
      next: (data) => {
        if (data) {
          this.model = data;
        }
      },
      error: (err) => {
        console.log(err);
      },
    });
  }
}
