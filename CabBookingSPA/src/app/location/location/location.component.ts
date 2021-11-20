import { Component, OnInit } from '@angular/core';
import { LocationService } from 'src/app/core/services/location.service';
import { Location } from 'src/app/shared/models/locationModel';

@Component({
  selector: 'app-location',
  templateUrl: './location.component.html',
  styleUrls: ['./location.component.css']
})
export class LocationComponent implements OnInit {
  locations!:Location[];
  location: Location = {
    id: 0,
    pickupAddress: '',
    dropoffAddress: '',
    landmark: '',
    bookingsId: 0,
    bookings: null,
    placesId: 0,
    places: null
  }
  constructor(private locationservice: LocationService) { }

  ngOnInit(): void {
    this.locationservice.getAll().subscribe(
      l=> {
        this.locations = l;
      }
    );
  }
  delete(id: number){
    this.location.id = id;
    console.log(this.location);
    this.locationservice.delete(this.location).subscribe();
  }
}
