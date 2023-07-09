import { Injectable } from '@angular/core';
import { VideoGamesStore } from '../store/video-games.store';
import { VideoGamesService } from '../api/video-games.service';

@Injectable()
export class GetVideoGameDetailsAction {
  constructor(private store: VideoGamesStore, private videoGamesService: VideoGamesService) {}

  execute(id: string): void {
    this.videoGamesService.getVideoGameDetails(id).subscribe(game => {
      this.store.setVideoGameDetails(game);
    });
  }
}
