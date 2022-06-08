import { ViewChild } from '@angular/core';
import { ElementRef } from '@angular/core';
import { Component,OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [NgbModal, NgbModalConfig]
})
export class AppComponent {
  title = 'angular-inspection-api';
  
  @ViewChild("content", { static: true })
  content!: ElementRef;
  constructor(private modalService:NgbModal,config:NgbModalConfig,private builder:FormBuilder){
    config.backdrop = 'static';
    config.keyboard = false;
  }

  loginForm:any;
  ngOnInit(): void {
    
    this.modalService.open(this.content);
    this.loginForm=this.builder.group({
      username:['',Validators.required],
      password:['',Validators.required]
    });
  }

  isLogin:boolean=false;
  authentication(Form:FormGroup){
    if(Form.value.username=='admin'&&Form.value.password=='admin123'){
      this.isLogin=true;
      alert("Welcome to the Application You can close application");
    }
    else{
      alert("Username or Password is Not Valid");
      this.isLogin=false;
    }
  };
}
