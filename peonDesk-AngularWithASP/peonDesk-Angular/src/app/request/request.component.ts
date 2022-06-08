import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../data.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-request',
  templateUrl: './request.component.html',
  styleUrls: ['./request.component.css']
})
export class RequestComponent implements OnInit {

  constructor(private DataService: DataService,
    private router: Router,
    private modalService: NgbModal,
    private fb: FormBuilder) { }

  RequestForm: any;
  RequestData: any = [];
  Requests: any = [];
  UserType = "";

  //Peon Requests
  PeonRequest: any = [];
  PeonRequestData: any = [];
  //Request Model
  StaffData: any = [];

  ngOnInit(): void {
    if (this.DataService.LoginType == "") {
      this.router.navigateByUrl('Initial');
    }
    this.RequestForm = this.fb.group({
      "recieverId": ['', Validators.required],
      "documentDetails": ['', Validators.required],
      "takenDate": ['', Validators.required]
    });

    if (this.DataService.LoginType == "Peon") {
      this.UserType = "Peon";
      this.PeonData();
    }
    else if (this.DataService.LoginType == "Professor") {
      this.UserType = "Professors";
      this.Requests = [];
      this.DataService.getRequestsBySenderId(this.DataService.LoginId).subscribe((ProfessorRequests: any) => {
        this.RequestData = ProfessorRequests;
        this.Requests = ProfessorRequests;
        for (let p = this.RequestData.length - 1; p >= 0; p--) {
          this.DataService.getStaffById(this.RequestData[p].recieverId).subscribe((StaffData: any) => {
            this.Requests[p].recieverId = StaffData;
          });
          if (this.Requests[p].peonId != '') {
            this.DataService.getPeonById(this.RequestData[p].peonId).subscribe((PeonData: any) => {
              this.Requests[p].recieverId = PeonData;
            });
          }
        }
      });
    }
  }

  PeonData() {
    this.Requests = [];

    //Print Waiting Requests
    this.DataService.getRequests().subscribe((Req: any) => {
      this.RequestData = Req;
      this.Requests = Req;
      for (let r = this.RequestData.length - 1; r >= 0; r--) {
        if (this.RequestData[r].peonId == "") {
          this.DataService.getStaffById(this.RequestData[r].senderId).subscribe((senderData: any) => {
            this.Requests[r].senderId = senderData;
          });
          this.DataService.getStaffById(this.RequestData[r].recieverId).subscribe((receiverData: any) => {
            this.Requests[r].recieverId = receiverData;
          });
        }
      }
    });

    //Print Requests Which is Accepted by Peon
    this.DataService.getRequestsByPeonId(this.DataService.LoginId).subscribe((Req: any) => {
      for (let i = 0; i < Req.length; i++) {
        if (Req[i].peonId != '') {
          this.PeonRequestData = Req;
          this.PeonRequest = Req;
          for (let r = this.PeonRequestData.length - 1; r >= 0; r--) {
            this.DataService.getStaffById(this.PeonRequestData[r].senderId).subscribe((senderData: any) => {
              this.PeonRequest[r].senderId = senderData;
            });
            this.DataService.getStaffById(this.PeonRequestData[r].recieverId).subscribe((receiverData: any) => {
              this.PeonRequest[r].recieverId = receiverData;
            });
          }
        }
      }
    });
  }

  closeResult = '';
  open(content: any) {
    this.StaffData = [];
    this.DataService.getStaffs().subscribe((data: any) => {
      for (let s = 0; s < data.length; s++) {
        if (data[s].id != this.DataService.LoginId) {
          this.StaffData.push(data[s]);
        }
      }
    });
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title', size: 'md', backdrop: 'static' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed`;
    });
  }

  PostRequest() {
    let Request = {
      "senderId": this.DataService.LoginId.toString(),
      "recieverId": this.RequestForm.value.recieverId.toString(),
      "documentDetails": this.RequestForm.value.documentDetails,
      "takenDate": this.RequestForm.value.takenDate.toString(),
      "requiestStatus": true,
      "peonId": "",
      "deliveryStatus": false
    }
    this.ngOnInit();
  }

  acceptRequest(data:any)
  {
    console.log(data);
    
    let RequestData={
      "senderId": data.senderId.id.toString(),
      "recieverId": data.recieverId.id.toString(),
      "documentDetails": data.documentDetails,
      "takenDate": data.takenDate.toString(),
      "requiestStatus": false,
      "peonId": this.DataService.LoginId.toString(),
    }
    this.DataService.putRequest(RequestData,data.id).subscribe();
    // this.Requests.splice(1);
  }
}
