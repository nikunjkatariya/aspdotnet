import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http:HttpClient) { }

  LoginId=1;
  LoginType="Peon";

  urls={
    "Request":"https://localhost:7120/api/Requests",
    "Peon":"https://localhost:7120/api/Peons",
    "Staff":"https://localhost:7120/api/Staffs"
  };

  //Request
  getRequests(){
    return this.http.get(this.urls.Request);
  }
  getRequestById(Index:any){
    return this.http.get(this.urls.Request+'/'+Index);
  }
  getRequestsBySenderId(Index:any){
    return this.http.get(this.urls.Request+"?senderId="+Index);
  }
  getRequestsByPeonId(Index:any){
    return this.http.get(this.urls.Request+"?peonId="+Index);
  }
  postRequest(RequestData:any){
    return this.http.post(this.urls.Request,RequestData);
  }
  putRequest(RequestData:any,Index:any){
    return this.http.put(this.urls.Request+'/'+Index,RequestData);
  }

  //Peon
  getPeons(){
    return this.http.get(this.urls.Peon);
  }
  getPeonById(Index:any){
    return this.http.get(this.urls.Peon+'/'+Index);
  }
  postPeon(RequestData:any){
    return this.http.post(this.urls.Peon,RequestData);
  }
  putPeon(RequestData:any,Index:any){
    return this.http.put(this.urls.Peon+'/'+Index,RequestData);
  }

  //Staff
  getStaffs(){
    return this.http.get(this.urls.Staff);
  }
  getStaffById(Index:any){
    return this.http.get(this.urls.Staff+'/'+Index);
  }
  postStaff(RequestData:any){
    return this.http.post(this.urls.Staff,RequestData);
  }
  putStaff(RequestData:any,Index:any){
    return this.http.put(this.urls.Staff+'/'+Index,RequestData);
  }
}
