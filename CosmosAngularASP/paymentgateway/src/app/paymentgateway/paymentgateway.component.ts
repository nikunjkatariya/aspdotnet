import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from '../data.service';

@Component({
  selector: 'app-paymentgateway',
  templateUrl: './paymentgateway.component.html',
  styleUrls: ['./paymentgateway.component.css']
})
export class PaymentgatewayComponent implements OnInit {

  constructor(private dataService:DataService, private fb:FormBuilder,private router:Router) { }

  ShowPayment:any;
  PaymentForm:any;
  submitted = false;

  ngOnInit(): void {
    this.PaymentForm=this.fb.group({
      Amount:['',Validators.required],
      BankName:['BOB',Validators.required],
      CardNumber:['45678945612345',Validators.required],
      ValidMonth:['05',Validators.required],
      ValidYear:['22',Validators.required],
      CardHolder:['ASD',Validators.required],
      CVV:['789',Validators.required]
    });
    this.dataService.GetPayments().subscribe((Data:any)=>this.ShowPayment=Data);
  }

  get f() { return this.PaymentForm.controls; }

  SendPayment:any;

  PostPayment(){
    this.submitted = true;
    if (this.PaymentForm.invalid) {
      return;
    }
    this.SendPayment={
      "id":"",
      "transactionId":"",
      "amount":parseInt(this.PaymentForm.value.Amount),
      "bankName":this.PaymentForm.value.BankName,
      "cardNumber":this.PaymentForm.value.CardNumber,
      "validMonth":parseInt(this.PaymentForm.value.ValidMonth),
      "validYear":parseInt(this.PaymentForm.value.ValidYear),
      "cardHolder":this.PaymentForm.value.CardHolder,
      "cvv":this.PaymentForm.value.CVV
    }
    // console.log(this.SendPayment);
    this.PaymentForm.reset();
    this.submitted=false;
    this.dataService.PostPayments(this.SendPayment).subscribe((Data:any)=>{
      this.ShowPayment.push(Data);
    });
    // this.router.navigateByUrl("/paymentcomplation");
  }
}
