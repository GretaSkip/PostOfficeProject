import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ParcelModel } from '../models/parcel.model';
import { ParcelCreateEditModel } from '../models/parcel-create-edit.model';

@Injectable({
  providedIn: 'root'
})
export class ParcelsService {

  private http: HttpClient;

  constructor(http: HttpClient) {
    this.http = http;
  }


  public getParcels(): Observable<ParcelModel[]> {
    return this.http.get<ParcelModel[]>("https://localhost:44371/Parcel");
  }

  public getParcelsByPost(postId: number): Observable<ParcelModel[]> {
    return this.http.get<ParcelModel[]>(`https://localhost:44371/Parcel/ParcelsbyPost/${postId}`);
  }

  public addParcel(parcel: ParcelCreateEditModel): Observable<number> {
    return this.http.post<number>("https://localhost:44371/Parcel", parcel);
  }

  public deleteParcel(id: number): Observable<ParcelModel> {
    return this.http.delete<ParcelModel>(`https://localhost:44371/Parcel/${id}`);
  }

  public updateParcel(parcel: ParcelCreateEditModel): Observable<ParcelModel> {
    return this.http.put<ParcelModel>(`https://localhost:44371/Parcel`, parcel);
  }

}
