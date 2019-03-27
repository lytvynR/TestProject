import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { ApiClientService } from "../../../services/api-client.service";
import { apiPathConstants } from "../../../constants/api-path.constants";
import { Person, personProps } from "../../../models/person";
import { Gender } from "../gender";
import { FormGroup, FormControl, Validators } from "@angular/forms";
import { FormsControlGroup } from "../../../models/form-control-group";

@Component({
  selector: 'pm-edit-person',
  templateUrl: './edit-person.component.html',
  styleUrls: ['./edit-person.component.scss']
})
export class EditPersonComponent implements OnInit {
  personId: any;
  person: Person = {
    id: null,
    firstName: "",
    lastName: "",
    birthDate: "",
    gender: Gender.male,
    personalNumber: "",
    salary: 0
  }
  isNew: boolean;
  editPersonForm: FormGroup;
  personProps = personProps;
  gender = Gender;

  private existingPersonNumbers: string[] = [];

  constructor(
    private apiClientService: ApiClientService,
    private activatedRoute: ActivatedRoute,
  ) { }

  ngOnInit() {
    this.personId = this.activatedRoute.snapshot.params.id;
    this.isNew = !this.personId;

    if (!this.isNew) {
      this.apiClientService.get<Person>(apiPathConstants.person + this.personId)
        .subscribe(personResponse => {
          this.apiClientService.get<string[]>(apiPathConstants.existingNumbers).subscribe(res => {
            this.person = personResponse;
            this.existingPersonNumbers = res.filter(number => number != personResponse.personalNumber);
            this.editPersonForm = this.createEditPersonForm(this.person);
          });
        });
    } else {
      this.apiClientService.get<string[]>(apiPathConstants.existingNumbers).subscribe(res => {
        this.existingPersonNumbers = res;
        this.editPersonForm = this.createEditPersonForm(this.person);
      });
    }
  }

  submit() {
    if (this.existingPersonNumbers.indexOf(this.editPersonForm.value.personalNumber) !== -1) {
      this.editPersonForm.controls[personProps.personalNumber].setErrors({ 'incorrect': true });
      return;
    }

    let person: Person = {
      id: this.person.id,
      firstName: this.editPersonForm.value.firstName,
      lastName: this.editPersonForm.value.lastName,
      birthDate: this.editPersonForm.value.birthDate,
      gender: this.editPersonForm.value.gender,
      personalNumber: this.editPersonForm.value.personalNumber,
      salary: this.editPersonForm.value.salary,
    }

    this.isNew ? this.createPerson(person) : this.updatePerson(person);

  }

  private createPerson(person: Person) {
    this.apiClientService.post(apiPathConstants.persons, person).subscribe(() => {

    });
  }

  private updatePerson(person: Person) {
    this.apiClientService.put(apiPathConstants.persons, person).subscribe(() => {

    });
  }

  private createEditPersonForm(person: Person) {
    const group: FormsControlGroup = {};
    group[personProps.firstName] = new FormControl(person.firstName, [Validators.required, Validators.maxLength(25)]);
    group[personProps.lastName] = new FormControl(person.lastName, [Validators.required, Validators.maxLength(50)]);
    group[personProps.personalNumber] = new FormControl(person.personalNumber, [Validators.required, Validators.minLength(11), Validators.maxLength(11)]);
    group[personProps.birthDate] = new FormControl(person.birthDate, [Validators.required]);
    group[personProps.gender] = new FormControl(person.gender, [Validators.required, Validators.min(0), Validators.max(1)]);
    group[personProps.salary] = new FormControl(person.salary, [Validators.required, Validators.min(0), Validators.pattern("^[0-9]*$")]);

    let formGroup = new FormGroup(group);

    return formGroup;
  }
}


