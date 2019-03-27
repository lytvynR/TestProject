import { Component, OnInit } from '@angular/core';
import { apiPathConstants } from "../../../constants/api-path.constants";
import { Person, personProps } from "../../../models/person";
import { ApiClientService } from "../../../services/api-client.service";
import { Router } from "@angular/router";
import { routeConstants } from "../../../routing/route-constants";
import { Gender } from "../gender";
import { PersonsWithPagingResponse } from "./person-with-paging";
import { personPageSize } from "../../../constants/paging-constants";

@Component({
  selector: 'pm-person-list',
  templateUrl: './person-list.component.html',
  styleUrls: ['./person-list.component.scss']
})
export class PersonListComponent implements OnInit {
  persons: Person[];
  currentPage = 0;
  personsCount = 0;
  pageSize = personPageSize;
  gender = Gender;
  personProps = personProps;

  private _personsFullList: Person[];
  constructor(
    private apiClientService: ApiClientService,
    private router: Router
  ) { }

  ngOnInit() {
   this.openNewPage();
  }

  private openNewPage() {
    this.apiClientService.get<PersonsWithPagingResponse>(this.getPageUrl(apiPathConstants.persons))
    .subscribe(res => {
      this.persons = res.entity;
      this._personsFullList = this.persons;
      this.currentPage = res.pageNumber;
      this.personsCount = res.entitiesCount;
    })
  }

  deletePerson(id: number) {
    this.apiClientService.delete(apiPathConstants.persons + "/" + id).subscribe(() => {
      this.persons = this.persons.filter(persons => {
        return persons.id !== id;
      });
      this._personsFullList = this.persons;;
    })
  }

  editPerson(id: number) {
    this.router.navigate([routeConstants.editPerson, id])
  }

  //it can be done better with reactive forms but for now it's just easy way to do filtering
  filter(value: string, propName: string) {
    value = value.toString();

    this.persons = this._personsFullList.filter(person => {
      return person[propName].toString().toLowerCase().includes(value.toLowerCase())
    })
  }

  getOtherPage(nextPageNumber: number) {
    this.currentPage = nextPageNumber;
    this.openNewPage();
  }

  private getPageUrl(url: string): string {
    return url + "?page=" + this.currentPage;
  }
}
