import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Cab } from 'src/app/shared/models/cabModel';

@Component({
  selector: 'app-edit-cab',
  templateUrl: './edit-cab.component.html',
  styleUrls: ['./edit-cab.component.css']
})
export class EditCabComponent implements OnInit {
  cab:Cab = {
    id: 0,
    cabTypeName: ''
  }
  constructor() { }

  ngOnInit(): void {
    
  }

  editCab(form: NgForm){

  }

}
