import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment, Environment} from '../../../../environments/environment.development';
import { BookResponse } from '../models/book-responce.model';
import { Observable } from 'rxjs';
import { AddBookRequest } from '../models/add-book-request.model';
import { UpdateBookRequest } from '../models/update-book-request.model';

@Injectable({
  providedIn: 'root'
})
export class BooksService {

  baseApiUrl: string = (environment as Environment).baseApiUrl;

  constructor(private httpClient: HttpClient) { }

  getAllBooks(): Observable<BookResponse[]> {
    return this.httpClient.get<BookResponse[]>(this.baseApiUrl+'Books');
  }

  getBookById(id:number): Observable<BookResponse> {
    return this.httpClient.get<BookResponse>(this.baseApiUrl+'Books/'+id);
  }

  addBook(model:AddBookRequest):Observable<void>{
    console.log(this.baseApiUrl+'Books');
    return this.httpClient.post<void>(this.baseApiUrl+'Books',model);
  }

  updateBook(id:number,model:UpdateBookRequest):Observable<void>{
    console.log(this.baseApiUrl+'Books/'+id);
    return this.httpClient.put<void>(this.baseApiUrl+'Books/'+id,model);
  }

  deleteBook(id:number):Observable<void>{
    console.log(this.baseApiUrl+'Books/'+id);
    return this.httpClient.delete<void>(this.baseApiUrl+'Books/'+id);
  }
}
