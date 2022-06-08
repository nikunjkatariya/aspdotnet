import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DataService } from './data.service';
import { PaymentcomplationComponent } from './paymentcomplation/paymentcomplation.component';
import { PaymentgatewayComponent } from './paymentgateway/paymentgateway.component';

@NgModule({
  declarations: [
    AppComponent,
    PaymentcomplationComponent,
    PaymentgatewayComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
