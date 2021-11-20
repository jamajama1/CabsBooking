import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BookingHistoryServiceService } from 'src/app/core/services/booking-history-service';
import { BookingHistory } from 'src/app/shared/models/booking-history.model'
import { Identifier } from 'src/app/shared/models/identifier.model';

@Component({
  selector: 'app-booking-history',
  templateUrl: './booking-history.component.html',
  styleUrls: ['./booking-history.component.css']
})
export class BookingHistoryComponent implements OnInit {
  bookingHistory!: BookingHistory[]
  id: Identifier = {
    id: 0
  }
  constructor(private bookinghistoryservice: BookingHistoryServiceService) { }

  ngOnInit(): void {
    this.bookinghistoryservice.getAll().subscribe(

      b=> {
        console.table(b);
        return this.bookingHistory = b;
      }

    );
  }

  delete(id: number){
    this.id.id = id;
    this.bookinghistoryservice.delete(this.id).subscribe();
  }
}
