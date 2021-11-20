import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { BookingService } from 'src/app/core/services/booking.service';
import { BookingDetails } from 'src/app/shared/models/bookingDetailsModel';

@Component({
  selector: 'app-add-booking',
  templateUrl: './add-booking.component.html',
  styleUrls: ['./add-booking.component.css']
})
export class AddBookingComponent implements OnInit {
  booking:BookingDetails = {
  id: 0,
  email: '',
  bookingTime: '',
  pickupTime: '',
  contactNo: '',
  status: '',
  locationRequest: {
    id: 0,
    pickupAddress: '',
    dropoffAddress: '',
    landmark: '',
    placeIdRequestModel: {
      id: 0
    }
  }
  };
  constructor(private bookingservice: BookingService, private router: Router) { }

  ngOnInit(): void {
  }

  addBooking(form: NgForm){
    console.log(this.booking);
    console.log("from component")
    console.log(this.booking);
    this.bookingservice.addBooking(this.booking).subscribe();
    this.router.navigateByUrl('addbooking');
  }

}
