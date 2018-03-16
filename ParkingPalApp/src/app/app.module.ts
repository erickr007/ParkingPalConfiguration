import { BrowserModule } from '@angular/platform-browser'
import { CommonModule } from '@angular/common'
import { FormsModule } from '@angular/forms'
import { HttpModule } from "@angular/http"
import { NgModule } from '@angular/core'
import { ParkingLocationsModule } from "./parkinglocations.module"
import { RouterModule } from '@angular/router'

import { AppComponent } from './components/app/app.component'
import { HomeComponent } from './components/home/home.component'

@NgModule({
  declarations: [
      AppComponent,
      HomeComponent
  ],
  imports: [
      BrowserModule,
      CommonModule,
      FormsModule,
      HttpModule,
      ParkingLocationsModule,
      RouterModule.forRoot([
          { path: "home", component: HomeComponent },
          { path: "", redirectTo: 'home', pathMatch: "full" },
          { path: "**", redirectTo: 'home' }
      ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
