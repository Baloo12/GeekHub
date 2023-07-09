import { Injectable } from '@angular/core';
import { VideoGamesStore } from '../store/video-games.store';
import { VideoGamesService } from '../api/video-games.service';

@Injectable()
export class GetVideoGamesAction {
  constructor(private store: VideoGamesStore, private videoGamesService: VideoGamesService) {}

  execute(): void {
    this.videoGamesService.getVideoGames().subscribe(games => {
      this.store.setVideoGames(games);
    });
  }
}
