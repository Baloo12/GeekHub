import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './components/core/layout/layout.component';
import { VideoGameDetailsComponent } from './modules/video-games/details/video-game-details.component';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      {
        path: '',
        redirectTo: '/video-games',
        pathMatch: 'full'
      },
      {
        path: 'video-games',
        loadChildren: () => import('src/app/modules/video-games/video-games.module').then(m => m.VideoGamesModule)
      },
      {
        path: 'video-games/:id',
        component: VideoGameDetailsComponent
      }
    ]
  },
  {
    path: '**',
    redirectTo: ''
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
