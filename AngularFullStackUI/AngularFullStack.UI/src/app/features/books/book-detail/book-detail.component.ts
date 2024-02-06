import { Component, inject } from '@angular/core';
import { BooksService } from '../services/books.service';
import { BookResponse } from '../models/book-responce.model';
import { ActivatedRoute } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-book-detail',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './book-detail.component.html',
  styleUrl: './book-detail.component.css'
})
export class BookDetailComponent {
  model: BookResponse;

  booksService = inject(BooksService);
  id:number;
  constructor(private route: ActivatedRoute){
    this.id=0;
    this.model={
      id:1,
      title:'a',
      genre:'a',
      author:'a',
      pageCount:'a',
      publishDate:'a'
    };
  }

  ngOnInit(): void{
    
    this.route.params.subscribe(params => {
      this.id = +params['id']; // Extracting the 'id' parameter from the URL
    });

    this.booksService.getBookById(this.id)
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
