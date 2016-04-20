import {Component} from "angular2/core";
import {RouteConfig, RouterOutlet, RouterLink, ROUTER_DIRECTIVES} from "angular2/router";

import {BlogCreateComponent} from "./blog-create.component";
import {BlogListComponent} from "./blog-list.component";
import {BlogService} from "./blog.service";

@Component({
    template: "<router-outlet></router-outlet>",
    directives: [RouterOutlet, RouterLink, ROUTER_DIRECTIVES],
    providers: [BlogService]
})
@RouteConfig([
    {
        path: "/",
        name: "BlogList",
        component: BlogListComponent
    },
    {
        path: "/create",
        name: "BlogCreate",
        component: BlogCreateComponent
    }
])
export class BlogComponent {
    // base blog component
}