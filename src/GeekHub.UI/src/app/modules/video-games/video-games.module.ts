import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { VideoGamesComponent } from './video-games.component';
import { VideoGamesRoutingModule } from './video-games-routing.module';
import { VideoGamesGridComponent } from './grid/video-games-grid.component';

@NgModule({
  declarations: [VideoGamesComponent, VideoGamesGridComponent],
  imports: [CommonModule, VideoGamesRoutingModule, 
    // CommonComponentsModule
]
})
export class VideoGamesModule {}