import { Gender } from "../components/persons/gender";

export interface Person {
  id: number;
  firstName: string;
  lastName: string;
  personalNumber: string;
  birthDate
  gender: Gender;
  salary: number;
}

export const personProps = {
  id: "id",
  firstName: "firstName",
  lastName: "lastName",
  personalNumber: "personalNumber",
  birthDate: "birthDate",
  gender: "gender",
  salary: "salary",
};
