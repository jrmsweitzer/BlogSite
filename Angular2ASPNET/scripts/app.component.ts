// CORE
import {Component} from "angular2/core";
import {RouteConfig, ROUTER_PROVIDERS} from "angular2/router";

// CUSTOM
import {DashboardComponent}  from "./dashboard.component";
import {BlogComponent}       from "./blog.component";
import {BlogService}         from "./blog.service";

@Component({
    selector: "my-app",
    templateUrl: "app/app.component.html",
    styleUrls: ["app/app.component.css"],
    providers: [
        ROUTER_PROVIDERS,
        BlogService]
})

@RouteConfig([
    {
        path: "/dashboard",
        name: "Dashboard",
        component: DashboardComponent,
        useAsDefault: true
    },
    {
        path: "/blog/...",
        name: "Blog",
        component: BlogComponent,
    },
])

export class AppComponent {
    title = "Welcome";
}