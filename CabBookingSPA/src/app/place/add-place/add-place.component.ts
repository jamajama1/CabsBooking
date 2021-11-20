import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { PlaceService } from 'src/app/core/services/place.service';
import { Place } from 'src/app/shared/models/placeModel';

@Component({
  selector: 'app-add-place',
  templateUrl: './add-place.component.html',
  styleUrls: ['./add-place.component.css']
})
export class AddPlaceComponent implements OnInit {
  place: Place = {
    id: 0,
    placeName: ''
  };
  constructor(private placeservice: PlaceService, private router: Router) { }

  ngOnInit(): void {
  }

  addPlace(form: NgForm){
    this.placeservice.addPlace(this.place).subscribe();
    this.router.navigateByUrl('addplace');
  }

}
