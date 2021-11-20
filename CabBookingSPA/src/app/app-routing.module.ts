import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookingComponent } from './booking/booking/booking.component';
import { AddCabComponent } from './cab/add-cab/add-cab.component';
import { CabComponent } from './cab/cab/cab.component';
import { AddBookingComponent } from './booking/add-booking/add-booking.component';
import { LocationComponent } from './location/location/location.component';
import { AddPlaceComponent } from './place/add-place/add-place.component';
import { PlaceComponent } from './place/place/place.component';
import { HomeComponent } from './home/home.component';
import { EditCabComponent } from './cab/edit-cab/edit-cab.component';
import { EditBookingComponent } from './booking/edit-booking/edit-booking.component';
import { EditLocationComponent } from './location/edit-location/edit-location.component';
import { EditPlaceComponent } from './place/edit-place/edit-place.component';
import { BookingHistoryComponent } from './bookingHistory/booking-history/booking-history.component';
import { LocationHistoryComponent } from './locationHistory/location-history/location-history.component';

const routes: Routes = [
  {
    path: "", component: HomeComponent
  },
  {
    path: "bookings", component: BookingComponent
  },
  {
    path: "locations", component: LocationComponent
  },
  {
    path: "places", component: PlaceComponent
  },
  {
    path: "cabs", component: CabComponent
  },
  {
    path: "addcab", component: AddCabComponent
  },
  {
    path: "addplace", component: AddPlaceComponent
  },
  {
    path: "addbooking", component: AddBookingComponent
  },
  {
    path: "editcab", component: EditCabComponent
  },
  {
    path: "editbooking", component: EditBookingComponent
  },
  {
    path: "editlocation", component: EditLocationComponent
  },
  {
    path: "editplace", component: EditPlaceComponent
  },
  {
    path: "bookinghistory", component: BookingHistoryComponent
  },
  {
    path: "locationhistory", component: LocationHistoryComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

