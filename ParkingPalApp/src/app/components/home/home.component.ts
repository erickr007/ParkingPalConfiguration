import { Component, OnInit } from "@angular/core"
import { ActivatedRoute } from "@angular/router"

//- services
import { LocationsService } from "../../services/locations/locations.service"


@Component({
    templateUrl: "./home.component.html"
})
export class HomeComponent implements OnInit{
    locations = []

    constructor(private route: ActivatedRoute) { }

    ngOnInit() {
      this.locations = this.route.snapshot.data.locations;
    }
}
