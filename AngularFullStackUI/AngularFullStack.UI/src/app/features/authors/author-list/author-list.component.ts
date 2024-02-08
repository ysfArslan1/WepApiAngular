import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { AuthorResponse } from '../models/author-responce.model';
import { AuthorsService } from '../services/authors.service';

@Component({
  selector: 'app-author-list',
  standalone: true,
  imports: [RouterModule,CommonModule,HttpClientModule,RouterOutlet],
  templateUrl: './author-list.component.html',
  styleUrl: './author-list.component.css'
})
export class AuthorListComponent {
  authors: AuthorResponse[]=[]

  authorsService = inject(AuthorsService)
  constructor(){}
  ngOnInit(): void{
    
    this.authorsService.getAllAuthors()
    .subscribe({
      next: (data) => {
        if (data && data.length > 0) {
          this.authors = data;
        }
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  DeleteAuthor(id: number) {
    this.authorsService.deleteAuthor(id)
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
