import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { VideoGame } from './video-game';

@Component({
  selector: 'video-games',
  templateUrl: 'video-games.component.html',
  styleUrls: ['video-games.component.scss']
})
export class VideoGamesComponent implements OnInit {
  games$: Observable<VideoGame[]> = new Observable<VideoGame[]>();
//   gamesCount$: Observable<number>;
  games: VideoGame[] = [];

//   constructor(
//     private route: ActivatedRoute,
//     store: Store,
//     private gamesRequestedAction: TopGamesRequestedAction
//   ) {
//     this.games$ = store.pagesStore.topGames.games$;
//     this.gamesCount$ = store.pagesStore.topGames.gamesCount$;
//   }

  ngOnInit() {
//     this.games$.subscribe(games => (this.games = games));
//    // this.gamesCount$.subscribe(gamesCount => (this.setPageNumbers(gamesCount)));

//     const pageNumber = this.route.snapshot.paramMap.get('pageNumber');
//     this.queryTopGames();
  }

//   queryTopGames() {
//     this.gamesRequestedAction.execute();
//   }
}