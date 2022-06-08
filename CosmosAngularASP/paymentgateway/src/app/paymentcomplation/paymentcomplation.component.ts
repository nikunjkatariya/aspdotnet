import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DataService } from '../data.service';

@Component({
  selector: 'app-paymentcomplation',
  templateUrl: './paymentcomplation.component.html',
  styleUrls: ['./paymentcomplation.component.css']
})

export class PaymentcomplationComponent implements OnInit {

  constructor(private ds:DataService, private router:Router) { }
  
  paymentdata:any="";
  status=false;

  ngOnInit(): void {
    this.ds.ConfirmPayment().subscribe((data:any)=>{
      this.paymentdata=data;
      console.log(this.paymentdata);
      if(this.paymentdata!=null){
        this.status=true;
      }
    });
  }
  processed(){
    this.router.navigateByUrl("");
  }

}
