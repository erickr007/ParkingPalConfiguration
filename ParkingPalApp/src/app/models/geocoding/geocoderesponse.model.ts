import { GeocodeAttributesModel } from "./geocodeattributes.model"
import { GeocodeCandidateModel } from "./geocodecandidate.model"
import { SpatialReferenceModel } from "./spatialreference.model"

export class GeocodeResponseModel{
  spatialReference: SpatialReferenceModel;
  candidates: GeocodeCandidateModel[];
}
