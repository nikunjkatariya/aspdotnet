import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from '../data.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  UserFormData: any;
  UserRegistrationData: any;
  UserInfo: any;

  FormType = "Login";
  submitted = false;
  regsubmitted = false;
  alertmsg = false;
  regalertmsg=false;
  flag = false;

  constructor(private DataService: DataService, private fb: FormBuilder, private router: Router) { }

  ngOnInit(): void {
    this.UserFormData = this.fb.group({
      Username: ['', Validators.required],
      Password: ['', Validators.required],
    });
    this.UserRegistrationData = this.fb.group({
      Firstname: ['', Validators.required],
      Lastname: ['', Validators.required],
      Name: ['', Validators.required],
      Contact: ['', Validators.required],
      Block: ['', Validators.required],
      Location: ['', Validators.required],
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  //User Type
  UserType = "Professor";
  userType(value: Number) {
    if (value == 1) {
      this.submitted = false;
      this.regsubmitted = false;
      this.UserType = "Professor";
    }
    else if (value == 2) {
      this.submitted = false;
      this.regsubmitted = false;
      this.UserType = "Peon";
    }
  }

  get f() { return this.UserFormData.controls; }

  get reg() { return this.UserRegistrationData.controls; }

  AuthCheck(FormType: string) {
    //Login
    if (FormType == "Login") {
      this.submitted = true;
      if (this.UserFormData.invalid) {
        return;
      }
      if (this.UserType == "Peon") {
        this.DataService.getPeons().subscribe((Peons: any) => {
          for (let i = 0; i < Peons.length; i++) {
            if (this.UserFormData.value.Username == Peons[i].username && this.UserFormData.value.Password == Peons[i].password) {
              this.flag=true;
              this.DataService.LoginId = Peons[i].id;
              this.DataService.LoginType = "Peon";
              this.router.navigateByUrl('/Landing');
            }
          }
          if (this.flag == false) {
            this.alertmsg = true;
            setTimeout(() => {
              this.alertmsg = false;
            }, 3000);
          }
        });
      }
      else if (this.UserType == "Professor") {
        this.DataService.getStaffs().subscribe((Staffs: any) => {
          for (let i = 0; i < Staffs.length; i++) {
            if (this.UserFormData.value.Username == Staffs[i].username && this.UserFormData.value.Password == Staffs[i].password) {
              this.flag=true;
              this.DataService.LoginId = Staffs[i].id;
              this.DataService.LoginType = "Professor";
              this.router.navigateByUrl('/Landing');
            }
          }
          if (this.flag == false) {
            this.alertmsg = true;
            setTimeout(() => {
              this.alertmsg = false;
            }, 3000);
          }
        });
      }
    }
    //Registration
    else if (FormType == "Registration") {
      this.regsubmitted = true;
      if (this.UserType == "Peon") {
        this.DataService.getPeons().subscribe((Peons: any) => {
          for (let i = 0; i < Peons.length; i++) {
            if (this.UserRegistrationData.value.username == Peons[i].username) {
              this.flag=true;
              break;
            }
          }
          if (this.flag == true) {
            this.regalertmsg = true;
            setTimeout(() => {
              this.regalertmsg = false;
            }, 3000);
          }
          else{
            let PeonData={
              "name":this.UserRegistrationData.value.Name,
              "contact":this.UserRegistrationData.value.Contact,
              "username":this.UserRegistrationData.value.username,
              "password":this.UserRegistrationData.value.password
            }
            this.DataService.postPeon(PeonData).subscribe((data:any)=>console.log(data));
          }
        });
      }
      else if (this.UserType == "Professor") {
        this.DataService.getStaffs().subscribe((Staffs: any) => {
          for (let i = 0; i < Staffs.length; i++) {
            if (this.UserRegistrationData.value.username == Staffs[i].username) {
              this.flag=true;
              break;
            }
          }
          if (this.flag == true) {
            this.alertmsg = true;
            setTimeout(() => {
              this.alertmsg = false;
            }, 3000);
          }
          else{
            let ProfessorData={
              "firstName": this.UserRegistrationData.value.Firstname,
              "lastName": this.UserRegistrationData.value.Lastname,
              "sittingBlock": this.UserRegistrationData.value.Block,
              "sittingLocation": this.UserRegistrationData.value.Location,
              "contact": this.UserRegistrationData.value.Contact,
              "username": this.UserRegistrationData.value.username,
              "password": this.UserRegistrationData.value.password
            }
            this.DataService.postStaff(ProfessorData).subscribe();
          }
        });
      }
      this.FormType = "Login";
    }
  }

}
