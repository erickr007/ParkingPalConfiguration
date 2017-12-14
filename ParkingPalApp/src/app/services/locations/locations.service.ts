import { Http, Response } from "@angular/http"
import { Injectable } from "@angular/core"
import { Observable } from "rxjs/Rx"
import "rxjs/add/operator/map"
import "rxjs/add/operator/catch"

//- models
import { ParkingLocationModel } from "../../models/parkinglocation.model"

@Injectable()
export class LocationsService {
    apiURL: string = "http://localhost:59945/";

    constructor(private http: Http) {

    }

    //- Get All ParkingLocations
    public GetAllParkingLocations(): Observable<ParkingLocationModel[]> {
        var val = this.http.get(this.apiURL).
            map((locations: Response) => {
                return locations.json();
            });

        return val;
    }
}
