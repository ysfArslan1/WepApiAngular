import { Component, OnInit, inject, input } from '@angular/core';
import { BookResponse } from '../models/book-responce.model';
import { BooksService } from '../services/books.service';
import { ActivatedRoute, RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { AddBookRequest } from '../models/add-book-request.model';
import { UpdateBookRequest } from '../models/update-book-request.model';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-update-book',
  standalone: true,
  imports: [RouterOutlet,CommonModule,HttpClientModule,FormsModule],
  templateUrl: './update-book.component.html',
  styleUrl: './update-book.component.css'
})
export class UpdateBookComponent  implements OnInit {
  
  model : UpdateBookRequest;
  id:number;
  booksService = inject(BooksService)
  constructor(private route: ActivatedRoute){
    this.id=0;
    this.model={
      Title:'a',
      GenreId:1,
      AuthorId:1,
      PageCount:1,
      PublishDate:new Date()
    };
  }

  ngOnInit(): void{

    this.route.params.subscribe(params => {
      this.id = +params['id']; // Extracting the 'id' parameter from the URL
    });

    this.booksService.getBookById(this.id)
    .subscribe({
      next: (data) => {
        console.log(data)
        this.model.Title=data.title;
        const date = data.publishDate.split(' ')[0]
        const [month, day, year] = date.split('.');
        this.model.PublishDate = new Date(parseInt(year), parseInt(month) - 1, parseInt(day));
        this.model.PublishDate=new Date(data.publishDate);
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  onFormSubmit(){
    console.log(this.model);

    this.booksService.updateBook(this.id,this.model).subscribe({
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
