import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DotNETCoreComponent } from './dot-netcore/dot-netcore.component';
import { DotNETComponent } from './dot-net/dot-net.component';
import { WCFComponent } from './wcf/wcf.component';

@NgModule({
  declarations: [
    AppComponent,
    DotNETCoreComponent,
    DotNETComponent,
    WCFComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
