import { Injectable } from "@angular/core"
import { Resolve } from "@angular/router"

import { Observable } from 'rxjs/Observable'
import 'rxjs/add/observable/of';

import {ParkingLocationModel} from "../../models/parkinglocation.model"

import { LocationsService } from "../../services/locations/locations.service"

@Injectable()
export class HomeResolver implements Resolve<Observable<ParkingLocationModel[]>> {
  service: LocationsService;

  constructor(locationService: LocationsService) {
    this.service = locationService;
  }

  resolve() {
    return this.service.GetAllParkingLocations();
  }
}
