import { Component, inject } from '@angular/core';
import { GenreResponse } from '../models/genre-responce.model';
import { GenresServiceService } from '../services/genres.service';
import { ActivatedRoute } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-genre-detail',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './genre-detail.component.html',
  styleUrl: './genre-detail.component.css'
})
export class GenreDetailComponent {
  model: GenreResponse;

  genresService = inject(GenresServiceService);
  id:number;
  constructor(private route: ActivatedRoute){
    this.id=0;
    this.model={
      id:0,
      name:''
    };
  }

  ngOnInit(): void{
    
    this.route.params.subscribe(params => {
      this.id = +params['id']; // Extracting the 'id' parameter from the URL
    });

    this.genresService.getGenreById(this.id)
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
