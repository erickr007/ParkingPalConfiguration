import { Component } from "@angular/core"
import { NgForm } from "@angular/forms"
//import { CompleterService, CompleterData } from 'ng2-completer';
import { Observable } from "rxjs/Rx"

//- models
import { GeocodeResponseModel } from "../../models/geocoding/geocoderesponse.model"
import { ParkingLocationModel } from "../../models/parkinglocation.model"
import { SuggestModel } from "../../models/geocoding/suggest.model"

//- services
import { GeocodeService } from "../../services/geocoding/geocode.service"
import { LocationsService } from "../../services/locations/locations.service"

import 'rxjs/Rx'

@Component({
  templateUrl: "addlocation.component.html"
})

export class AddLocationComponent {
  location: ParkingLocationModel = new ParkingLocationModel();
  address: string = ""
  suggestions: SuggestModel[] = [];
  displaySuggest: boolean = false;

  constructor(private locationService: LocationsService, private geocodeService: GeocodeService) {

  }

  locationSubmit(locationForm: NgForm) {
    console.log(locationForm);
    
    //- try geocode address
    this.geocodeService.findAddressCandidate(this.location.ad).subscribe(
      (response: GeocodeResponseModel) => {
        //console.log(response);

        if (response.candidates.length == 0) {
          alert("Address could not be geocoded.  Please update and resubmit");
          return;
        }

        //- get first candidate coordinates
        this.location.lg = response.candidates[0].location.x;
        this.location.lt = response.candidates[0].location.y;

        //- upon successful geocode complete submit to server
        this.locationService.AddParkingLocation(this.location).subscribe(
          (response: any) => {
            console.log("add complete");
            locationForm.reset();
          },
          (error: any) => {

          },
          () => {

          }
        );
      }
    )

    
  }

  addressChanged(value) {
    if (value.length > 2) {
      this.geocodeService.getAddressSuggest(value).subscribe(
        (suggestArray: any) => {
          this.suggestions = suggestArray.suggestions;

          if (suggestArray.suggestions.length > 0) {
            this.displaySuggest = true;
          }
          else {
            this.displaySuggest = false;
          }
        },
        (error: Error) => {

        },
        () => {

        }
      );
    }
  }

  selectedAddress(item: SuggestModel) {
    this.location.ad = item.text
    this.closeSuggestList();
  }

  closeSuggestList() {
    this.displaySuggest = false;
  }
}
