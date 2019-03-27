import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { SideNavComponent } from './components/layout/side-nav/side-nav.component';
import { ToolbarComponent } from './components/layout/toolbar/toolbar.component';
import { RouterModule } from "@angular/router";
import { routes } from "./routing/routes";
import { PersonListComponent } from './components/persons/person-list/person-list.component';
import { EditPersonComponent } from './components/persons/edit-person/edit-person.component';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouteService } from "./services/route.service";
import { HttpClientModule } from "@angular/common/http";
import { ApiClientService } from "./services/api-client.service";
import { MatModule } from "./shared/mat-module";

@NgModule({
  declarations: [
    AppComponent,
    SideNavComponent,
    ToolbarComponent,
    PersonListComponent,
    EditPersonComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    RouterModule.forRoot(routes),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatModule,
  ],
  providers: [RouteService, ApiClientService],
  bootstrap: [AppComponent]
})
export class AppModule { }
