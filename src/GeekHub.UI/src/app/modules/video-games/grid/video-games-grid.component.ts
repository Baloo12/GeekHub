import { Component, Input } from '@angular/core';
import { VideoGame } from '../video-game';

@Component({
  selector: 'video-games-grid',
  templateUrl: 'video-games-grid.component.html',
  styleUrls: ['video-games-grid.component.scss']
})
export class VideoGamesGridComponent {
  @Input() games: VideoGame[] = [];
}
