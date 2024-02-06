import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment, Environment} from '../../../../environments/environment.development';
import { Observable } from 'rxjs';
import { GenreResponse } from '../models/genre-responce.model';

@Injectable({
  providedIn: 'root'
})
export class GenresServiceService {

  baseApiUrl: string = (environment as Environment).baseApiUrl;

  constructor(private httpClient: HttpClient) { }

  getAllGenres(): Observable<GenreResponse[]> {
    return this.httpClient.get<GenreResponse[]>(this.baseApiUrl+'Genres');
  }
}
