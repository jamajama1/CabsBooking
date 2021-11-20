import { Component, OnInit } from '@angular/core';
import { BookingService } from 'src/app/core/services/booking.service';
import { BookingDetails } from 'src/app/shared/models/bookingDetailsModel';
import { Booking } from 'src/app/shared/models/bookingModel';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css']
})
export class BookingComponent implements OnInit {

  bookings!: Booking[];
  booking: BookingDetails = {
    id: 0,
    bookingTime: '',
    pickupTime: '',
    email: '',
    contactNo: '',
    status: '',
    locationRequest: {
      id: 0,
      pickupAddress: '',
      dropoffAddress: '',
      landmark: '',
      placeIdRequestModel: {
        id: 0,
      }
    }
  }
  constructor(private bookingservice: BookingService) { }

  ngOnInit(): void {
    this.bookingservice.getAll().subscribe(

      b=> {
        console.table(b);
        return this.bookings = b;
      }

    );
  }

  delete(id: number){
    this.booking.id = id;
    this.bookingservice.delete(this.booking).subscribe();
  }
}
