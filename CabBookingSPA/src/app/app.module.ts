import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './core/layer/header/header.component';
import { BookingComponent } from './booking/booking/booking.component';
import { CabComponent } from './cab/cab/cab.component';
import { PlaceComponent } from './place/place/place.component';
import { LocationComponent } from './location/location/location.component';
import { AddCabComponent } from './cab/add-cab/add-cab.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddPlaceComponent } from './place/add-place/add-place.component';
import { AddBookingComponent } from './booking/add-booking/add-booking.component';
import { HomeComponent } from './home/home.component';
import { EditCabComponent } from './cab/edit-cab/edit-cab.component';
import { EditLocationComponent } from './location/edit-location/edit-location.component';
import { EditBookingComponent } from './booking/edit-booking/edit-booking.component';
import { EditPlaceComponent } from './place/edit-place/edit-place.component';
import { BookingHistoryComponent } from './bookingHistory/booking-history/booking-history.component';
import { LocationHistoryComponent } from './locationHistory/location-history/location-history.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    BookingComponent,
    CabComponent,
    PlaceComponent,
    LocationComponent,
    AddCabComponent,
    AddPlaceComponent,
    AddBookingComponent,
    HomeComponent,
    EditCabComponent,
    EditLocationComponent,
    EditBookingComponent,
    EditPlaceComponent,
    BookingHistoryComponent,
    LocationHistoryComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
