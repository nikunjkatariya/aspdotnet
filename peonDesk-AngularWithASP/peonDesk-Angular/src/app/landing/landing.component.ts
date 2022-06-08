import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../data.service';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.css']
})
export class LandingComponent implements OnInit {

  isMenuCollapsed=true;

  constructor(private DataService:DataService,private router:Router) { }

  ngOnInit(): void {
  }
  
  LogOut(){
    this.isMenuCollapsed = true
    this.DataService.LoginId=0;
    this.DataService.LoginType="";
    this.router.navigateByUrl('/');
  }
}
