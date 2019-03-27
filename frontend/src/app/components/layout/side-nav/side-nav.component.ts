import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSidenav } from "@angular/material";
import { RouteService } from "../../../services/route.service";
import { routeConstants } from "../../../routing/route-constants";


@Component({
  selector: 'pm-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.scss']
})
export class SideNavComponent implements OnInit {
  @ViewChild(MatSidenav) sidenav: MatSidenav;

  routeConstants = routeConstants

  constructor(private routeService: RouteService) { }

  ngOnInit() {
  }

  toggle() {
    this.sidenav.toggle();
  }

  getRouterLink(routeName: string) {
    return this.routeService.getRouterLink(routeName);
  }

}
