import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable()
export class ApiClientService {

  constructor(private httpClient: HttpClient) { }

  get<T>(url: string): Observable<T> {
    return this.httpClient.get<T>(url);
  }

  post<T>(url: string, data:T): Observable<T> {
    return this.httpClient.post<T>(url, data);
  }

  put(url: string, data: object): Observable<void> {
    return this.httpClient.put<void>(url, data);
  }

  delete(url: string): Observable<void> {
    return this.httpClient.delete<void>(url);
  }
}
