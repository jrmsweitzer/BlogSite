import {Component} from 'angular2/core';
import {RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS} from 'angular2/router';

import {DashboardComponent}  from './dashboard.component';
import {HeroListComponent}   from './heroes.component';
import {HeroDetailComponent} from './hero-detail.component';

import {BlogComponent}       from './blog.component';

import {HeroService}         from './hero.service';
import {BlogService}         from './blog.service';

@Component({
    selector: 'my-app',
    templateUrl: 'app/app.component.html',
    styleUrls: ['app/app.component.css'],
    directives: [ROUTER_DIRECTIVES],
    providers: [
        ROUTER_PROVIDERS,
        HeroService,
        BlogService]
})

@RouteConfig([
    {
        path: '/dashboard',
        name: 'Dashboard',
        component: DashboardComponent,
        useAsDefault: true
    },
    { // Blog child route...
        path: '/blog/...',
        name: 'Blog',
        component: BlogComponent,
    },
])

export class AppComponent {
    title = 'Welcome';
}