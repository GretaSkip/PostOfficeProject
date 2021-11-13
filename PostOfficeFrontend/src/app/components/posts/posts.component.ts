import { Component, OnInit } from '@angular/core';
import { PostModel } from 'src/app/models/post.model';
import { PostsService } from 'src/app/services/posts.service';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {

  private postsService: PostsService;

  constructor(postsService: PostsService) {
    this.postsService = postsService;
  }

  public id: number;
  public name: string;
  public town: string;
  public capacity: number;
  public code: string;

  public posts: PostModel[] = [];

  public hideMode: boolean = true;
  public editMode: boolean = false;


  ngOnInit(): void {
    this.getData();
  }

  public getData(): void {
    this.postsService.getPosts().subscribe((postsFromApi) => {
      this.posts = postsFromApi;
    })
  }

  public addPost(): void {
    var newPost: PostModel = {
      id: this.id,
      name: this.name,
      town: this.town,
      capacity: this.capacity,
      code: this.code
    }

    this.postsService.addPost(newPost).subscribe((postId) => {
      newPost.id = postId;
      this.posts.push(newPost);
      this.getData();
    })

    this.resetValues();
    this.hideMode = true;
  }

  deletePost(id: number): void {
    this.postsService.deletePost(id).subscribe(() => {
      let index = this.posts.map(p => p.id).indexOf(id);
      this.posts.splice(index, 1);
    })
  }

  loadPost(post: PostModel): void {

    this.hideMode = false;
    this.editMode = true;

    this.id = post.id;
    this.name = post.name;
    this.town = post.town;
    this.capacity = post.capacity;
    this.code = post.code;
  }

  sendUpdatedPost(): void {
    var updatedValue: PostModel = {
      id: this.id,
      name: this.name,
      town: this.town,
      capacity: this.capacity,
      code: this.code
    }

    this.postsService.updatePost(updatedValue).subscribe(() => {
      this.getData();
    })

    this.resetValues();

    this.hideMode = true;
    this.editMode = false;
  }

  resetValues(): void {
    this.name = "";
    this.town = "";
    this.capacity = null;
    this.code = "";
  }

}
