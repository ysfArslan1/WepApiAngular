import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment, Environment} from '../../../../environments/environment.development';
import { BookResponce } from '../models/book-responce.model';
import { Observable } from 'rxjs';
import { AddBookRequest } from '../models/add-book-request.model';

@Injectable({
  providedIn: 'root'
})
export class BooksService {

  baseApiUrl: string = (environment as Environment).baseApiUrl;

  constructor(private httpClient: HttpClient) { }

  getAllBooks(): Observable<BookResponce[]> {
    return this.httpClient.get<BookResponce[]>(this.baseApiUrl+'Books');
  }

  addBook(model:AddBookRequest):Observable<void>{
    console.log("add book");
    console.log(this.baseApiUrl+'Books');
    return this.httpClient.post<void>(this.baseApiUrl+'Books',model);
  }
}
