import { Component, ViewChild } from '@angular/core';
import { SideNavComponent } from "./components/layout/side-nav/side-nav.component";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  @ViewChild(SideNavComponent) sideNavComponent: SideNavComponent;

  toggleSidenav() {
    this.sideNavComponent.toggle();
  }

}
