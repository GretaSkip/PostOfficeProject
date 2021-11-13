import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PostModel } from '../models/post.model';

@Injectable({
  providedIn: 'root'
})
export class PostsService {

  private http: HttpClient;

  constructor(http: HttpClient) {
    this.http = http;
  }


  public getPosts(): Observable<PostModel[]> {
    return this.http.get<PostModel[]>("https://localhost:44371/Post");
  }

  public addPost(post: PostModel): Observable<number> {
    return this.http.post<number>("https://localhost:44371/Post", post);
  }

  public deletePost(id: number): Observable<PostModel> {
    return this.http.delete<PostModel>(`https://localhost:44371/Post/${id}`);
  }

  public updatePost(post: PostModel): Observable<PostModel> {
    return this.http.put<PostModel>(`https://localhost:44371/Post`, post);
  }
}
