import { Injectable } from "@angular/core";

@Injectable()
export class RouteService {
    getRouterLink(routeName: string) {
        return ["/" + routeName];
    }
}
