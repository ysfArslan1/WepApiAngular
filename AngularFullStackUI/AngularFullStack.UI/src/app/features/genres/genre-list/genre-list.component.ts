import { Component, inject } from '@angular/core';
import { GenreResponse } from '../models/genre-responce.model';
import { GenresServiceService } from '../services/genres.service';
import { RouterModule, RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-genre-list',
  standalone: true,
  imports: [RouterModule,CommonModule,HttpClientModule,RouterOutlet],
  templateUrl: './genre-list.component.html',
  styleUrl: './genre-list.component.css'
})
export class GenreListComponent {

  genres: GenreResponse[]=[]
  genresService = inject(GenresServiceService)

  constructor(){}
  ngOnInit(): void{
    
    this.genresService.getAllGenres()
    .subscribe({
      next: (data) => {
        if (data && data.length > 0) {
          this.genres = data;
        }
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  DeleteGenre(id: number) {
    this.genresService.deleteGenre(id)
    .subscribe({
      next(response) {
        console.log('succsesful');
        console.log(response);
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

}
