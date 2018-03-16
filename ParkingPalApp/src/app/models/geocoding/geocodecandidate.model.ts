import { MapPointModel } from "../mappoint.model"
import { GeocodeAttributesModel } from "./geocodeattributes.model"

export class GeocodeCandidateModel {
  address: string;
  location: MapPointModel;
  score: number;
  attributes: GeocodeAttributesModel;
}
