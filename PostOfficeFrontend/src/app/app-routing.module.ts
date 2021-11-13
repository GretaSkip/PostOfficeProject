import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ParcelsComponent } from './components/parcels/parcels.component';
import { PostsComponent } from './components/posts/posts.component';

const routes: Routes = [
    {
        path: '',
        component: HomeComponent
    },
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