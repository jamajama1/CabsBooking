import { Component, OnInit } from '@angular/core';
import { CabService } from 'src/app/core/services/cab.service';
import { Cab } from 'src/app/shared/models/cabModel';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-add-cab',
  templateUrl: './add-cab.component.html',
  styleUrls: ['./add-cab.component.css']
})
export class AddCabComponent implements OnInit {
  cab:Cab = {
    id: 0,
    cabTypeName: ''
  };
  constructor(private cabservice: CabService, private router: Router) { }

  ngOnInit(): void {
    // this.cabservice.addCab().subscribe(
    //   c=>{
    //     this.cab = c;
    //   }
    // );
  }

  addCab(form: NgForm){
    this.cabservice.addCab(this.cab).subscribe();
    this.router.navigateByUrl('addcab');
  }

}