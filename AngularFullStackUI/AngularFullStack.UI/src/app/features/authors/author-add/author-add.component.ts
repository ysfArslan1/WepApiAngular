import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnDestroy, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AddAuthorRequest } from '../models/add-genre-request.model';
import { AuthorsService } from '../services/authors.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-author-add',
  standalone: true,
  imports: [FormsModule,CommonModule,HttpClientModule],
  templateUrl: './author-add.component.html',
  styleUrl: './author-add.component.css'
})
export class AuthorAddComponent  implements OnDestroy  {
  model : AddAuthorRequest;
  authorsService =inject(AuthorsService)
  private addAuthorSubcription? : Subscription;

  constructor(){
    this.model = {
      name:'',
      surname:'',
      birthdate:new Date()
    };
  }
  ngOnDestroy(): void {
    this.addAuthorSubcription?.unsubscribe();
  }

  onFormSubmit(){
    console.log(this.model);
    this.addAuthorSubcription = this.authorsService.addAuthor(this.model).subscribe({
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
