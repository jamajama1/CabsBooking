import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Booking } from 'src/app/shared/models/bookingModel';
import { HttpClient } from '@angular/common/http'
import { BookingDetails } from 'src/app/shared/models/bookingDetailsModel';
import { map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class BookingService {
  booking!:BookingDetails;
  constructor(private http: HttpClient) { }

  //https://localhost:44309/api/Booking/GetAllBookings
  getAll(): Observable<Booking[]>{
    return this.http.get<Booking[]>('https://localhost:44309/api/Booking/GetAllBookings');
  }

  addBooking(bookingData: BookingDetails){
    console.log("in function");
      console.log(bookingData);
      return this.http.post("https://localhost:44309/api/Booking/add", bookingData);
  }

  delete(bookingData: BookingDetails){
    console.log(bookingData);
      return this.http.post("https://localhost:44309/api/Booking/delete", bookingData);
  }
}
