import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { VideoGame } from '../video-game';
import { VideoGamesStore } from '../store/video-games.store';
import { GetVideoGameDetailsAction } from '../actions/get-video-game-details.action';

@Component({
  selector: 'video-game-details',
  templateUrl: './video-game-details.component.html',
  styleUrls: ['./video-game-details.component.scss']
})
export class VideoGameDetailsComponent implements OnInit {
  game$: Observable<VideoGame>;
  game: VideoGame = {} as VideoGame;

  constructor(
    private route: ActivatedRoute,
    private getVideoGameDetailsAction: GetVideoGameDetailsAction,
    private store: VideoGamesStore,
    private location: Location
  ) {
    this.game$ = this.store.getVideoGameDetails();
  }

  ngOnInit(): void {
    this.game$.subscribe(game => (this.game = game));
    this.getGameDetails();
  }

  getGameDetails(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.getVideoGameDetailsAction.execute(id!);
  }

  goBack() {
    this.location.back();
  }
}
