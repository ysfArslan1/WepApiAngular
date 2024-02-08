import { Injectable } from '@angular/core';
import { environment, Environment} from '../../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { AuthorResponse } from '../models/author-responce.model';
import { Observable } from 'rxjs';
import { AddAuthorRequest } from '../models/add-genre-request.model';
import { UpdateAuthorRequest } from '../models/update-author-request.model';

@Injectable({
  providedIn: 'root'
})
export class AuthorsService {

  baseApiUrl: string = (environment as Environment).baseApiUrl;

  constructor(private httpClient: HttpClient) { }

  getAllAuthors(): Observable<AuthorResponse[]> {
    return this.httpClient.get<AuthorResponse[]>(this.baseApiUrl+'Authors');
  }

  getAuthorById(id:number): Observable<AuthorResponse> {
    console.log(id);
    return this.httpClient.get<AuthorResponse>(this.baseApiUrl+'Authors/'+id);
  }

  addAuthor(model:AddAuthorRequest):Observable<void>{
    console.log("add author");
    console.log(this.baseApiUrl+'Authors');
    return this.httpClient.post<void>(this.baseApiUrl+'Authors',model);
  }

  updateAuthor(id:number,model:UpdateAuthorRequest):Observable<void>{
    console.log("update auther");
    console.log(this.baseApiUrl+'Authors/'+id);
    return this.httpClient.put<void>(this.baseApiUrl+'Authors/'+id,model);
  }

  deleteAuthor(id:number):Observable<void>{
    console.log("delete author");
    console.log(this.baseApiUrl+'Authors/'+id);
    return this.httpClient.delete<void>(this.baseApiUrl+'Authors/'+id);
  }
}
