import { Component, OnDestroy, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AddBookRequest } from '../models/add-book-request.model';
import { BooksService } from '../services/books.service';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-add-book',
  standalone: true,
  imports: [FormsModule,CommonModule,HttpClientModule],
  templateUrl: './add-book.component.html',
  styleUrl: './add-book.component.css'
})
export class AddBookComponent implements OnDestroy {
  model : AddBookRequest;
  booksService =inject(BooksService)
  private addBookSubcription? : Subscription;

  constructor(){
    this.model = {
      Title:'',
      AuthorId:0,
      GenreId:0,
      PageCount:0,
      PublishDate:new Date()
    };
  }
  ngOnDestroy(): void {
    this.addBookSubcription?.unsubscribe();
  }

  onFormSubmit(){
    console.log(this.model);
    this.addBookSubcription = this.booksService.addBook(this.model).subscribe({
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
