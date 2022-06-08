import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../data.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor(private DataService: DataService, private router:Router) { }

  UserType="";
  UserData:any;

  ngOnInit(): void {
    if(this.DataService.LoginType=='')
    {
      this.router.navigateByUrl('Initial');
    }
    if(this.DataService.LoginType=="Peon"){
      this.UserType="Peon";
      this.DataService.getPeonById(this.DataService.LoginId).subscribe((data:any)=>this.UserData=data);
    }
    else if(this.DataService.LoginType=="Professor"){
      this.UserType="Professor";
      this.DataService.getStaffById(this.DataService.LoginId).subscribe((data:any)=>this.UserData=data);
    }
  }

}
