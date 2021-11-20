import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Location } from 'src/app/shared/models/locationModel';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class LocationService {
  location!:Location;
  constructor(private http: HttpClient) { }

  getAll():Observable<Location[]>{
    return this.http.get<Location[]>("https://localhost:44309/api/Location/GetAllLocations");
  }

  // addPlace(locationData: Location):Observable<Location>{
  //   return this.http.post("https://localhost:44309/api/Place/add", locationData)
  //   .pipe(map((response: any) =>{
  //     console.log(response);
  //        if(response){
  //         this.location.pickupAddress = locationData.pickupAddress;
  //         this.location.dropoffAddress = locationData.dropoffAddress;
  //         this.location.landmark = locationData.landmark;
  //         this.location.placesId = locationData.placesId;
  //         this.location.bookingsId = locationData.pickupAddress;
  //         //return this.cab;
  //         return this.place;
  //        }
  //        else {
  //          return this.place;
  //        }
  //   }));
  // }

  delete(locationData: Location){
    console.log(locationData);
    return this.http.post("https://localhost:44309/api/Location/delete", locationData)
    .pipe(map((response: any) =>{
      console.log(response);
         if(response){

          //return this.cab;
          return true;
         }
         else {
           return false;
         }
    }));
  }
}
