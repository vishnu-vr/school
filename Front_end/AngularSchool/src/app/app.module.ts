import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { DetailsTableComponent } from './details-table/details-table.component';

import { HttpClientModule } from '@angular/common/http';
import { FormPopupComponent } from './form-popup/form-popup.component';
import { FormsModule } from '@angular/forms';
import { ConfirmPopupComponent } from './confirm-popup/confirm-popup.component';
import { ToastComponent } from './toast/toast.component'; // <-- NgModel lives here

@NgModule({
  declarations: [
    AppComponent,
    DetailsTableComponent,
    FormPopupComponent,
    ConfirmPopupComponent,
    ToastComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
