import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cab } from 'src/app/shared/models/cabModel';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CabService {

  cab: Cab = {
    id: 0,
    cabTypeName: ''
  };
  constructor(private http: HttpClient) { }

  getAll():Observable<Cab[]>{
    return this.http.get<Cab[]>("https://localhost:44309/api/CabContoller/GetAllCabs");
  }

  //https://localhost:44309/api/CabContoller/add
  addCab(cabData: Cab):Observable<Cab>{
    return this.http.post("https://localhost:44309/api/CabContoller/add", cabData)
    .pipe(map((response: any) =>{
      console.log(response);
         if(response){
          this.cab.cabTypeName = cabData.cabTypeName;
          //return this.cab;
          return this.cab;
         }
         else {
           return this.cab;
         }
    }));
  }

  delete(cabData: Cab){
    console.log(cabData);
    return this.http.post("https://localhost:44309/api/CabContoller/delete", cabData)
    .pipe(map((response: any) =>{
      console.log(response);
         if(response){

          //return this.cab;
          return true;
         }
         else {
           return false;
         }
    }));
  }

  edit(){

  }
}


// login(userLogin: Login): Observable<boolean> {

//   return this.http.post(`${environment.apiUrl}account/login`, userLogin)
//     .pipe(map((response: any) => {
//       if (response) {
//         // Save JWT sent from server in localstorage
//         localStorage.setItem('token', response.token);
//         this.populateUserInfo();
//         return true;
//       }
//       return false;
//     }));
// }

// purchaseMovie(movieId: number): Observable<boolean> {
//   return this.http.post(`${environment.apiUrl}user/purchase`, { 'movieId': movieId }).pipe(map((response: any) => {
//     if (response.purchased) {
//       return true;
//     }
//     return false;
//   }));
// }