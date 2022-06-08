import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http:HttpClient) { }

  GetPayments(){
    return this.http.get("https://localhost:7204/api/payments");
  }

  PostPayments(Data:any){
    return this.http.post("https://localhost:7204/api/payments/",Data);
  }

  ConfirmPayment(){
    return this.http.get("https://localhost:7201/api/Payments");
  }
}
