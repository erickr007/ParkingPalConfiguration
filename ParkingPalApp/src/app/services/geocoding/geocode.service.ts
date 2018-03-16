import { Injectable } from "@angular/core"
import { Http } from "@angular/http"
import { Observable } from "rxjs/Rx"
import 'rxjs/Rx'
//- Models
import { GeocodeResponseModel } from "../../models/geocoding/geocoderesponse.model"
import { MapPointModel } from "../../models/mappoint.model"
import { SuggestModel } from "../../models/geocoding/suggest.model"

@Injectable()
export class GeocodeService {
  geocodeUrl: string = "http://geocode.arcgis.com/arcgis/rest/services/World/GeocodeServer/findAddressCandidates?";
  suggestUrl: string = "http://geocode.arcgis.com/arcgis/rest/services/World/GeocodeServer/suggest?";

  constructor(public http: Http) { }

  findAddressCandidate(address: string): Observable<GeocodeResponseModel>{
    var url = this.geocodeUrl + "f=json&singleline=" + address;

    return this.http.get(url).map(
      (val, index) => {
        return val.json();
      }
    )
  }

  getAddressSuggest(address: string): Observable<[SuggestModel]> {
    var result: string = "";

    return this.http.get(this.suggestUrl + "maxSuggestions=5&f=json&text=" + address).map(
      (val, index) => {
        return val.json();
      }
    )

    
  }
}
