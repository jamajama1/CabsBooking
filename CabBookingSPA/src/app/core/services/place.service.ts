import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Place } from 'src/app/shared/models/placeModel';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PlaceService {
place!:Place;
  constructor(private http: HttpClient) { }

  getAll():Observable<Place[]>{
    return this.http.get<Place[]>("https://localhost:44309/api/Place/GetAllPlaces");
  }

    //https://localhost:44309/api/CabContoller/add
    addPlace(placeData: Place):Observable<Place>{
      console.log("in function");
      console.log(placeData);
      return this.http.post("https://localhost:44309/api/Place/add", placeData)
      .pipe(map((response: any) =>{
        console.log(response);
           if(response){
            this.place.placeName = placeData.placeName;
            //return this.cab;
            return this.place;
           }
           else {
             return this.place;
           }
      }));
    }

    delete(placeData: Place){
      console.log(placeData);
      return this.http.post("https://localhost:44309/api/Place/delete", placeData)
      .pipe(map((response: any) =>{
        console.log(response);
           if(response){
            return true;
           }
           else {
             return false;
           }
      }));
    }
}
