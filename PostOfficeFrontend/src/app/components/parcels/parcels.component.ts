import { Component, OnInit } from '@angular/core';
import { ParcelCreateEditModel } from 'src/app/models/parcel-create-edit.model';
import { ParcelModel } from 'src/app/models/parcel.model';
import { PostModel } from 'src/app/models/post.model';
import { ParcelsService } from 'src/app/services/parcels.service';
import { PostsService } from 'src/app/services/posts.service';

@Component({
  selector: 'app-parcels',
  templateUrl: './parcels.component.html',
  styleUrls: ['./parcels.component.css']
})
export class ParcelsComponent implements OnInit {

  private parcelsService: ParcelsService;
  private postsService: PostsService;


  constructor(parcelsService: ParcelsService, postsService: PostsService) {
    this.parcelsService = parcelsService;
    this.postsService = postsService;
  }

  public id: number;
  public recipient: string;
  public weight: number;
  public phone: string;
  public info: string;
  public postId: number;

  public postSelected: number;

  public parcels: ParcelModel[] = [];
  public valueCreated: ParcelCreateEditModel[] = [];
  public posts: PostModel[] = [];

  public hideMode: boolean = true;
  public editMode: boolean = false;
  public disabledMode: boolean = true;

  ngOnInit(): void {
    this.getData();
    this.getPostsData();
  }

  public getData(): void {
    this.parcelsService.getParcels().subscribe((parcelsFromApi) => {
      this.parcels = parcelsFromApi;
    })
  }

  public getPostsData(): void {
    this.postsService.getPosts().subscribe((postsFromApi) => {
      this.posts = postsFromApi;
    })
  }

  public onPostSelected(selectedPostId: number): void {
    if (selectedPostId !== 0) {
      this.parcelsService.getParcelsByPost(selectedPostId).subscribe((parcelsFromApi) => {
        this.parcels = parcelsFromApi;
      })
    } if (selectedPostId == 0) {
      this.getData();
    }
  }

  public addParcel(): void {
    var newParcel: ParcelCreateEditModel = {
      id: this.id,
      recipient: this.recipient,
      weight: this.weight,
      phone: this.phone,
      info: this.info,
      postId: this.postId
    }

    this.parcelsService.addParcel(newParcel).subscribe((parcelId) => {
      newParcel.id = parcelId;
      this.valueCreated.push(newParcel);
      this.getData();
    })

    this.resetValues();

    this.hideMode = true;

  }

  public deleteParcel(id: number): void {
    this.parcelsService.deleteParcel(id).subscribe(() => {
      let index = this.parcels.map(p => p.id).indexOf(id);
      this.parcels.splice(index, 1);
    })
  }

  public loadParcel(parcel: ParcelModel): void {

    this.hideMode = false;
    this.editMode = true;

    this.id = parcel.id;
    this.recipient = parcel.recipient;
    this.weight = parcel.weight;
    this.phone = parcel.phone;
    this.info = parcel.info;
    this.postId = parcel.postId;
  }

  public sendUpdatedParcel(): void {
    var updatedValue: ParcelCreateEditModel = {
      id: this.id,
      recipient: this.recipient,
      weight: this.weight,
      phone: this.phone,
      info: this.info,
      postId: this.postId
    }

    this.parcelsService.updateParcel(updatedValue).subscribe(() => {
      this.getData();
    })

    this.resetValues();

    this.hideMode = true;
    this.editMode = false;

  }

  public resetValues(): void {
    this.recipient = "";
    this.weight = null;
    this.phone = "";
    this.info = "";
    this.postId = null;
  }

}
