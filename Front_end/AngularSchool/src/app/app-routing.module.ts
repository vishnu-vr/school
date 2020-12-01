import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RouterModule, Routes } from '@angular/router';
import { FormPopupComponent } from './form-popup/form-popup.component';
import { DetailsTableComponent } from './details-table/details-table.component';
// import { ToastComponent } from './toast/toast.component';

const routes: Routes = [
  { path: '',   redirectTo: 'staff/None', pathMatch: 'full' },
  { path: 'staff/:staffType', component: DetailsTableComponent },
  { path: 'form_popup/:staff/:inpExtraField/:staffType', component: FormPopupComponent },
  // { path: 'toast', component: ToastComponent }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
