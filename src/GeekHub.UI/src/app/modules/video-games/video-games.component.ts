import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { VideoGame } from './video-game';
import { VideoGamesStore } from './store/video-games.store';
import { GetVideoGamesAction } from './actions/get-video-games.action';

@Component({
  selector: 'video-games',
  templateUrl: 'video-games.component.html',
  styleUrls: ['video-games.component.scss']
})
export class VideoGamesComponent implements OnInit {
  games$: Observable<VideoGame[]> = new Observable<VideoGame[]>();
//   gamesCount$: Observable<number>;
  games: VideoGame[] = [];

  constructor(
    private route: ActivatedRoute,
    store: VideoGamesStore,
    private getVideoGamesAction: GetVideoGamesAction
  ) {
    this.games$ = store.getVideoGames();
    // this.gamesCount$ = store.pagesStore.topGames.gamesCount$;
  }

  ngOnInit() {
    this.games$.subscribe(games => (this.games = games));
   // this.gamesCount$.subscribe(gamesCount => (this.setPageNumbers(gamesCount)));

    const pageNumber = this.route.snapshot.paramMap.get('pageNumber');
    this.getVideoGames();
  }

  getVideoGames() {
    this.getVideoGamesAction.execute();
  }
}