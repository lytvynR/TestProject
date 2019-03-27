import { Person } from "../../../models/person";

export interface PersonsWithPagingResponse
    {
      entity: Person[] ;
      pageNumber: number;
      entitiesCount: number;
    }
