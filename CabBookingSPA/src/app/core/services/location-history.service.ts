import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Identifier } from 'src/app/shared/models/identifier.model';
import { LocationHistory } from 'src/app/shared/models/location-history.model';

@Injectable({
  providedIn: 'root'
})
export class LocationHistoryService {

  constructor(private http: HttpClient) { }

  getAll():Observable<LocationHistory[]>{
    return this.http.get<LocationHistory[]>('https://localhost:44309/api/LocationHistory/GetAll');
  }

  delete(id: Identifier){
    console.log(id);
      return this.http.post("https://localhost:44309/api/LocationHistory/delete", id);
  }
}
