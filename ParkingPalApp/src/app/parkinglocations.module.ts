import { CommonModule } from '@angular/common'
import { NgModule } from "@angular/core"
import { FormsModule } from "@angular/forms"
import { RouterModule } from "@angular/router"
import { Ng2AutoCompleteModule } from "ng2-auto-complete"

//- components
import { AddLocationComponent } from "./components/locations/addlocation.component"
import { LocationsComponent } from "./components/locations/locations.component"

//- services
import { GeocodeService } from "./services/geocoding/geocode.service"
import { LocationsService } from "./services/locations/locations.service"
import { ParkingLocationsResolver } from "./services/locations/parkinglocations.resolver"

@NgModule({
  declarations: [
        AddLocationComponent,
        LocationsComponent
    ],
    providers: [
        GeocodeService,
        LocationsService,
        ParkingLocationsResolver
    ],
    imports: [
      CommonModule,
      FormsModule,
      Ng2AutoCompleteModule,
      RouterModule.forChild([
        { path: "addlocation", component: AddLocationComponent },
        { path: "addlocation/:id", component: AddLocationComponent },
        { path: "locations", component: LocationsComponent, resolve: ParkingLocationsResolver }
      ])
    ]
})
export class ParkingLocationsModule { }
