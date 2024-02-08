import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment, Environment} from '../../../../environments/environment.development';
import { Observable } from 'rxjs';
import { GenreResponse } from '../models/genre-responce.model';
import { AddGenreRequest } from '../models/add-genre-request.model';
import { UpdateGenreRequest } from '../models/update-genre-request.model';

@Injectable({
  providedIn: 'root'
})
export class GenresServiceService {

  baseApiUrl: string = (environment as Environment).baseApiUrl;

  constructor(private httpClient: HttpClient) { }

  getAllGenres(): Observable<GenreResponse[]> {
    return this.httpClient.get<GenreResponse[]>(this.baseApiUrl+'Genres');
  }

  getGenreById(id:number): Observable<GenreResponse> {
    console.log(id);
    return this.httpClient.get<GenreResponse>(this.baseApiUrl+'Genres/'+id);
  }

  addGenre(model:AddGenreRequest):Observable<void>{
    console.log("add genre");
    console.log(this.baseApiUrl+'Genres');
    return this.httpClient.post<void>(this.baseApiUrl+'Genres',model);
  }

  updateGenre(id:number,model:UpdateGenreRequest):Observable<void>{
    console.log("update genre");
    console.log(this.baseApiUrl+'Genres/'+id);
    return this.httpClient.put<void>(this.baseApiUrl+'Genres/'+id,model);
  }

  deleteGenre(id:number):Observable<void>{
    console.log("delete genre");
    console.log(this.baseApiUrl+'Genres/'+id);
    return this.httpClient.delete<void>(this.baseApiUrl+'Genres/'+id);
  }
}
