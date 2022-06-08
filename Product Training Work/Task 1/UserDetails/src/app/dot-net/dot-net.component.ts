import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-dot-net',
  templateUrl: './dot-net.component.html',
  styleUrls: ['./dot-net.component.css']
})
export class DotNETComponent implements OnInit {

  constructor(private http: HttpClient, private modalService: NgbModal, private fb: FormBuilder) { }

  userList: any;
  userForm: any;
  newForm = false;
  index: any;
  formSubmitted = false;

  //Initial
  ngOnInit(): void {
    this.getUsers();
    this.userForm = this.fb.group({
      userId:[''],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      address: ['', Validators.required],
      city: ['', Validators.required],
      state: ['', Validators.required],
      country: ['', Validators.required],
      contact: ['', [Validators.required, Validators.pattern('^[0-9]{10,}')]],
      email: ['', [Validators.required, Validators.email]]
    });
  }

  //Getting User Details and store into UserList
  getUsers() {
    this.userList = [];
    this.http.get("https://localhost:44339/api/Users").subscribe((data: any) => {
      this.userList = data
    });
  }

  //Open Modal
  closeResult = '';
  open(content: any, data: any, i: any) {
    this.index = i;
    if (data) {
      this.newForm = false;
      this.userForm.setValue({
        userId: data.userId,
        firstName: data.firstName,
        lastName: data.lastName,
        address: data.address,
        city: data.city,
        state: data.state,
        country: data.country,
        contact: data.contact,
        email: data.email
      });
    }
    else {
      this.newForm = true;
      this.userForm.reset();
    }

    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title', size: 'md', backdrop: 'static' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed`;
    });
  }

  get form() { return this.userForm.controls; }
  //Insert User Data
  postUserFormData() {
    this.formSubmitted = true;
    if (this.userForm.invalid) {
      return;
    }
    this.http.post("https://localhost:44339/api/Users",this.userForm.value).subscribe(data=>{
      this.getUsers();
    },response=>{
      if(response.status=200)
      {
        this.getUsers();
      }
    });
    this.modalService.dismissAll();
    this.formSubmitted = true;
  }

  //Update UserData
  updateUserFormData() {
    this.formSubmitted = true;
    if (this.userForm.invalid) {
      return;
    }
    this.http.put("https://localhost:44339/api/Users/"+this.userForm.value.userId,this.userForm.value).subscribe(data=>{
      this.getUsers();
    },response=>{
      if(response.status==200)
      {
        this.getUsers();
      }
    });
    this.modalService.dismissAll();
    this.formSubmitted = false;
  }

  //Delete UserData
  deleteUser(id:any) {
    this.http.delete("https://localhost:44339/api/Users/"+id).subscribe(data=>{},
      response=>{
        if(response.status==200){
          console.log("Record Deleted Successfully!");
        }
      });
    this.userList.splice(this.index, 1);
  }

}
