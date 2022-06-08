import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DotNETComponent } from './dot-net/dot-net.component';
import { DotNETCoreComponent } from './dot-netcore/dot-netcore.component';
import { WCFComponent } from './wcf/wcf.component';

const routes: Routes = [
  {path:"netcore",component:DotNETCoreComponent},
  {path:"net",component:DotNETComponent},
  {path:"wcf",component:WCFComponent},
  {path:"",component:DotNETCoreComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
