import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { VideoGame } from '../video-game';
import { environment } from 'src/environments/environments';

@Injectable()
export class VideoGamesService {
  constructor(private httpClient: HttpClient) {}

  getVideoGames(): Observable<VideoGame[]> {
    return this.get<VideoGame[]>('video-games');
  }

  getVideoGameDetails(id: string): Observable<VideoGame> {
    return this.get<VideoGame>(`video-games/${id}`);
  }

  private get<T>(url: string): Observable<T> {
    return this.httpClient.get<T>(this.buildUrl(url));
  }

  private buildUrl(url: string): string {
    var url = `${environment.serverURL}${url}`;
    return url;
  }
}
