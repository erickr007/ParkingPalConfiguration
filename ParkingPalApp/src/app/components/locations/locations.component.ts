import { Component } from '@angular/core'

//- services
import { LocationsService } from "../../services/locations/locations.service"

@Component({
    templateUrl: "./locations.component.html"

})

export class LocationsComponent {

    constructor(locationService: LocationsService) {

    }
}
