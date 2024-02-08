import { Component, OnDestroy, inject } from '@angular/core';
import { AddGenreRequest } from '../models/add-genre-request.model';
import { GenresServiceService } from '../services/genres.service';
import { Subscription } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-add-genre',
  standalone: true,
  imports: [FormsModule,CommonModule,HttpClientModule],
  templateUrl: './add-genre.component.html',
  styleUrl: './add-genre.component.css'
})
export class AddGenreComponent  implements OnDestroy  {
  model : AddGenreRequest;
  genresService =inject(GenresServiceService)
  private addGenreSubcription? : Subscription;

  constructor(){
    this.model = {
      name:''
    };
  }
  ngOnDestroy(): void {
    this.addGenreSubcription?.unsubscribe();
  }

  onFormSubmit(){
    console.log(this.model);
    this.addGenreSubcription = this.genresService.addGenre(this.model).subscribe({
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
