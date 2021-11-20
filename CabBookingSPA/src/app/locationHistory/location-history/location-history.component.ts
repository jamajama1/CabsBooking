import { Component, OnInit } from '@angular/core';
import { LocationHistoryService } from 'src/app/core/services/location-history.service';
import { Identifier } from 'src/app/shared/models/identifier.model';
import { LocationHistory } from 'src/app/shared/models/location-history.model';

@Component({
  selector: 'app-location-history',
  templateUrl: './location-history.component.html',
  styleUrls: ['./location-history.component.css']
})
export class LocationHistoryComponent implements OnInit {
  locations!:LocationHistory[]
  id:Identifier= {
    id: 0
  }
  constructor(private locationhistoryservice: LocationHistoryService) { }

  ngOnInit(): void {
    this.locationhistoryservice.getAll().subscribe(
      l=> {
        this.locations = l;
      }
    );
  }

  delete(id: number){
    this.id.id = id;
    console.log(this.id);
    this.locationhistoryservice.delete(this.id).subscribe();
  }

}
