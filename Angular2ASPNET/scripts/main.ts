///<reference path="../node_modules/angular2/typings/browser.d.ts"/>
import {AppComponent} from "./app.component";
import {bootstrap} from "angular2/platform/browser";
import {ROUTER_PROVIDERS, ROUTER_DIRECTIVES} from "angular2/router";
import {PLATFORM_DIRECTIVES, provide} from 'angular2/core';

bootstrap(AppComponent, [
    ROUTER_PROVIDERS,
    provide(PLATFORM_DIRECTIVES, {
        useValue: [ROUTER_DIRECTIVES], multi: true})
]);