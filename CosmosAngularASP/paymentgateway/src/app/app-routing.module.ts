import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { PaymentcomplationComponent } from './paymentcomplation/paymentcomplation.component';
import { PaymentgatewayComponent } from './paymentgateway/paymentgateway.component';

const routes: Routes = [
  {path:"",component:PaymentgatewayComponent},
  {path:"paymentcomplation",component:PaymentcomplationComponent},
  {path:"home",component:PaymentgatewayComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
