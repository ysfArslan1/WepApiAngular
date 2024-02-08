import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, RouterOutlet } from '@angular/router';
import { UpdateGenreRequest } from '../models/update-genre-request.model';
import { GenresServiceService } from '../services/genres.service';

@Component({
  selector: 'app-genre-update',
  standalone: true,
  imports: [RouterOutlet,CommonModule,HttpClientModule,FormsModule],
  templateUrl: './genre-update.component.html',
  styleUrl: './genre-update.component.css'
})
export class GenreUpdateComponent   implements OnInit {
  
  model : UpdateGenreRequest;
  id:number;
  genresService = inject(GenresServiceService)
  constructor(private route: ActivatedRoute){
    this.id=0;
    this.model={
      name:'',
      isActive:true
    };
  }

  ngOnInit(): void{

    this.route.params.subscribe(params => {
      this.id = +params['id']; // Extracting the 'id' parameter from the URL
    });

    this.genresService.getGenreById(this.id)
    .subscribe({
      next: (data) => {
        console.log(data)
        this.model.name=data.name;
        this.model.isActive=true;
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  onFormSubmit(){
    console.log(this.model);

    this.genresService.updateGenre(this.id,this.model).subscribe({
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
