import { Component, OnInit, inject, input } from '@angular/core';
import { BookResponse } from '../models/book-responce.model';
import { BooksService } from '../services/books.service';
import { ActivatedRoute, RouterOutlet } from '@angular/router';
import { CommonModule, DatePipe } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { AddBookRequest } from '../models/add-book-request.model';
import { UpdateBookRequest } from '../models/update-book-request.model';
import { FormsModule } from '@angular/forms';
import { AuthorResponse } from '../../authors/models/author-responce.model';
import { AuthorsService } from '../../authors/services/authors.service';
import { GenreResponse } from '../../genres/models/genre-responce.model';
import { GenresServiceService } from '../../genres/services/genres.service';


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

  authors: AuthorResponse[]=[]  
  authorsService = inject(AuthorsService)
  
  genres: GenreResponse[]=[]
  genresService = inject(GenresServiceService)

  formattedDate: string='';
  selectedGenreId: string='';
  selectedAuthorId: string='';

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


    this.booksService.getBookById(this.id)
    .subscribe({
      next: (data) => {
        console.log(data)
        this.model.Title=data.title;
        this.model.PageCount=Number(data.pageCount);
        // this.selectedGenreId=data.genre;
        this.selectGenreByName(data.genre);
        this.selectAuthorByName(data.author);
        
        const date = data.publishDate.split(' ')[0]
        const [month, day, year] = date.split('.');
        const newDate = new Date(parseInt(year), parseInt(month) - 1, parseInt(day));
        this.formattedDate = newDate.toISOString().slice(0, 10); 
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

  selectGenreByName(genreName: string): void {
    const genre = this.genres.find(genre => genre.name === genreName);
    if (genre) {
      this.selectedGenreId = String(genre.id);
    }
  }

  selectAuthorByName(authorName: string): void {
    const author = this.authors.find(author => (author.name +' '+author.surname)=== authorName);
    if (author) {
      this.selectedAuthorId = String(author.id);
    }
  }
}
