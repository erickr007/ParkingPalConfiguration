import { NgModule } from "@angular/core"
import { RouterModule } from "@angular/router"
import { FormsModule } from "@angular/forms"

//- components
import { LocationsComponent } from "./components/locations/locations.component"

//- services
import { LocationsService } from "./services/locations/locations.service"
import { ParkingLocationsResolver } from "./services/locations/parkinglocations.resolver"

@NgModule({
    declarations: [
        LocationsComponent
    ],
    providers: [
        LocationsService,
        ParkingLocationsResolver
    ],
    imports: [
        RouterModule.forChild([
            { path: "locations", component: LocationsComponent, resolve: ParkingLocationsResolver }
        ])
    ]
})
export class ParkingLocationsModule { }
