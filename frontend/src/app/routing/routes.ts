import { Routes } from "@angular/router";
import { routeConstants } from "./route-constants";
import { AppComponent } from "../app.component";
import { EditPersonComponent } from "../components/persons/edit-person/edit-person.component";
import { PersonListComponent } from "../components/persons/person-list/person-list.component";


export const routes: Routes = [
  { path: routeConstants.root, redirectTo: routeConstants.persons, pathMatch: "full" },
  { path: routeConstants.persons, component:  PersonListComponent, pathMatch: "full"},
  { path: routeConstants.editPerson, component: EditPersonComponent, pathMatch: "full" },
  { path: routeConstants.editPersonWithId, component: EditPersonComponent, pathMatch: "full" },
  { path: "**", redirectTo: routeConstants.persons, pathMatch: "full" }
];
