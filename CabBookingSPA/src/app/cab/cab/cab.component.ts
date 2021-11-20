import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CabService } from 'src/app/core/services/cab.service';
import { Cab } from 'src/app/shared/models/cabModel';

@Component({
  selector: 'app-cab',
  templateUrl: './cab.component.html',
  styleUrls: ['./cab.component.css']
})
export class CabComponent implements OnInit {
  cabs!:Cab[];
  cab: Cab = {
    id: 0,
    cabTypeName: ''
  };
  deleteId!: number;
  constructor(private cabservice: CabService) { }

  ngOnInit(): void {
    this.cabservice.getAll().subscribe(
      c=>{
        this.cabs = c;
      }
    );
  }

  delete(id: number){
    this.cab.id = id;
    console.log(this.cab);
    this.cabservice.delete(this.cab).subscribe();
  }

}
