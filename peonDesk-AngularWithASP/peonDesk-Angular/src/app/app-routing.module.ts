import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingComponent } from './landing/landing.component';
import { LoginComponent } from './login/login.component';
import { ProfileComponent } from './profile/profile.component';
import { RequestComponent } from './request/request.component';

const routes: Routes = [
  {path:'Initial',component:LoginComponent},
  {path:'Landing',component:LandingComponent,children:[
    {path:'Profile',component:ProfileComponent},
    {path:'Request',component:RequestComponent},
    {path:'',component:RequestComponent}
  ]},
  {path:'',component:LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
