import { Component, OnInit } from "@angular/core"
import { ActivatedRoute } from "@angular/router"

//- models
import { ParkingLocationModel } from "../../models/parkinglocation.model"

//- services
import { LocationsService } from "../../services/locations/locations.service"


@Component({
    templateUrl: "./home.component.html"
})
export class HomeComponent implements OnInit{
  locations = []//: ParkingLocationModel[] = []
  sourceLocations: ParkingLocationModel[] = []
  numPages = 1
  pages = []
  itemsPerPage = 5

    constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.sourceLocations = this.route.snapshot.data.locations;

    this.calculatePages()
    this.loadPages(0)
  }

  calculatePages() {
    if (this.sourceLocations.length > 0) {
      let count = this.sourceLocations.length / this.itemsPerPage
      this.numPages = Math.ceil(count)
      for (var i = 0; i < this.numPages; i++) {
        this.pages.push(i)
      }
    }
  }

  loadPages(pageIndex: number) {
    let startIndex = pageIndex * this.itemsPerPage

    this.locations = []
    for (var i = startIndex; i < startIndex + this.itemsPerPage && i < this.sourceLocations.length; i++) {
      this.locations.push(this.sourceLocations[i])
    }
  }
    
}
