//- services
import { Injectable } from "@angular/core"
import { Resolve } from "@angular/router"
import { Observable } from "rxjs/Rx"
import { LocationsService } from "./locations.service"

//- models
import { ParkingLocationModel } from "../../models/parkinglocation.model"

@Injectable()
export class ParkingLocationsResolver implements Resolve<ParkingLocationModel[]>{
    constructor(private locationService: LocationsService) { }

    resolve(): Observable<ParkingLocationModel[]> {
        return this.locationService.GetAllParkingLocations();
    }
}
