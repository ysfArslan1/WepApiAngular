import { Component, OnInit, ViewEncapsulation, inject } from '@angular/core';
import { BookResponce } from '../models/book-responce.model';
import { RouterOutlet } from '@angular/router';
import {CommonModule} from '@angular/common';
import { BooksService } from '../services/books.service';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-book-list',
  standalone: true,
  imports: [RouterOutlet,CommonModule,HttpClientModule],
  templateUrl: './book-list.component.html',
  styleUrl: './book-list.component.css',
  encapsulation: ViewEncapsulation.None
})
export class BookListComponent implements OnInit {
  books: BookResponce[]=[]

  booksService =inject(BooksService)
  // constructor(private booksService: BooksService){}

  ngOnInit(): void{

    this.booksService.getAllBooks()
    .subscribe({
      next: (data) => {
        console.log(data);
        this.books = data;
      },
      error: (err) => {
        console.log(err);
      },
    });
}
}
