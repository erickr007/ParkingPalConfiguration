import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'
import { RouterModule } from '@angular/router'
import { NgModule } from '@angular/core';
import { ParkingLocationsModule } from "./parkinglocations.module"

import { AppComponent } from './components/app/app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
      BrowserModule,
      FormsModule,
      ParkingLocationsModule,
      RouterModule.forRoot([
          { path: "", redirectTo: 'locations' },
          { path: "**", redirectTo: 'locations' }
      ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
