import { Component, OnInit } from '@angular/core';
import { PlaceService } from 'src/app/core/services/place.service';
import { Place } from 'src/app/shared/models/placeModel';

@Component({
  selector: 'app-place',
  templateUrl: './place.component.html',
  styleUrls: ['./place.component.css']
})
export class PlaceComponent implements OnInit {
  places!:Place[];
  place: Place = {
    id:0,
    placeName: ''
  }
  constructor(private placeservice: PlaceService) { }

  ngOnInit(): void {
    this.placeservice.getAll().subscribe(
      p => {
        return this.places = p;
      }
    );
  }

  delete(id: number){
    console.log(id);
    this.place.id = id;
    this.placeservice.delete(this.place).subscribe();
  }
}
