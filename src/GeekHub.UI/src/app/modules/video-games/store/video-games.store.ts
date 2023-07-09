import { BehaviorSubject, Observable } from 'rxjs';
import { VideoGame } from '../video-game';

export class VideoGamesStore {
  private gamesSbj$: BehaviorSubject<VideoGame[]> = new BehaviorSubject<VideoGame[]>([]);
  private games$: Observable<VideoGame[]> = this.gamesSbj$.asObservable();

  private gameDetailsSbj$: BehaviorSubject<VideoGame> = new BehaviorSubject<VideoGame>({} as VideoGame);
  private gameDetails$: Observable<VideoGame> = this.gameDetailsSbj$.asObservable();

  //   gamesCountSbj$: BehaviorSubject<number> = new BehaviorSubject<number>(0);
  //   games$: Observable<VideoGame[]> = this.gamesSbj$.asObservable();
  setVideoGames(items: VideoGame[]) {
    this.gamesSbj$.next(items);
  }

  setVideoGameDetails(item: VideoGame) {
    this.gameDetailsSbj$.next(item);
  }

  getVideoGames() {
    return this.games$;
  }

  getVideoGameDetails() {
    return this.gameDetails$;
  }
}
