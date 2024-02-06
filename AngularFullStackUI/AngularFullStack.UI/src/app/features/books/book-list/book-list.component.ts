import { Component, OnInit, ViewEncapsulation, inject, Input } from '@angular/core';
import { BookResponse } from '../models/book-responce.model';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import {CommonModule} from '@angular/common';
import { BooksService } from '../services/books.service';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-book-list',
  standalone: true,
  imports: [RouterOutlet,CommonModule,HttpClientModule,RouterModule],
  templateUrl: './book-list.component.html',
  styleUrl: './book-list.component.css',
  encapsulation: ViewEncapsulation.None
})
export class BookListComponent implements OnInit {
  books: BookResponse[]=[]

  booksService = inject(BooksService)
  constructor(private router: Router){}

  updateBook(book: any) {
    this.router.navigate(['/books/update'], { queryParams: { book: JSON.stringify(book) } });
  }

  DeleteBook(id: number) {
    this.booksService.deleteBook(id)
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

  ngOnInit(): void{
    
    this.booksService.getAllBooks()
    .subscribe({
      next: (data) => {
        if (data && data.length > 0) {
          this.books = data;
        }
      },
      error: (err) => {
        console.log(err);
      },
    });
  }


}
