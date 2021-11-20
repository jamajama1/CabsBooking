import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BookingHistory } from 'src/app/shared/models/booking-history.model';
import { Identifier } from 'src/app/shared/models/identifier.model';

@Injectable({
  providedIn: 'root'
})
export class BookingHistoryServiceService {

  constructor(private http: HttpClient) { }

  getAll():Observable<BookingHistory[]>{
    return this.http.get<BookingHistory[]>('https://localhost:44309/api/BookingHistory/GetAllBookings');
  }

  delete(id: Identifier){
    console.log(id);
      return this.http.post("https://localhost:44309/api/BookingHistory/delete", id);
  }
}
