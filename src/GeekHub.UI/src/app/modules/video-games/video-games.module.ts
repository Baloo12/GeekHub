import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { VideoGamesComponent } from './video-games.component';
import { VideoGamesRoutingModule } from './video-games-routing.module';
import { VideoGamesGridComponent } from './grid/video-games-grid.component';
import { VideoGamesStore } from './store/video-games.store';
import { VideoGamesService } from './api/video-games.service';
import { GetVideoGamesAction } from './actions/get-video-games.action';
import { HttpClientModule } from '@angular/common/http';
import { VideoGameDetailsComponent } from './details/video-game-details.component';
import { GetVideoGameDetailsAction } from './actions/get-video-game-details.action';

@NgModule({
  declarations: [VideoGamesComponent, VideoGamesGridComponent, VideoGameDetailsComponent],
  imports: [
    CommonModule,
    VideoGamesRoutingModule,
    HttpClientModule
    // CommonComponentsModule
  ],
  providers: [VideoGamesStore, VideoGamesService, GetVideoGamesAction, GetVideoGameDetailsAction]
})
export class VideoGamesModule {}
