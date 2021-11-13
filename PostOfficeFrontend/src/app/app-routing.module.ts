import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ParcelsComponent } from './components/parcels/parcels.component';
import { PostsComponent } from './components/posts/posts.component';

const routes: Routes = [
  {
    path: 'parcels',
    component: ParcelsComponent
  },
  {
    path: 'posts',
    component: PostsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }