import { Component } from '@angular/core'
import { NgForm } from '@angular/forms'

//- model
import { ParkingLocationModel } from "../../models/parkinglocation.model"

//- services
import { LocationsService } from "../../services/locations/locations.service"

@Component({
  templateUrl: "./locations.component.html"

})

export class LocationsComponent {

  constructor(private service: LocationsService) {

  }

  
}
