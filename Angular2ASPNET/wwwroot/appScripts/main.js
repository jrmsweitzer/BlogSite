"use strict";
///<reference path="../node_modules/angular2/typings/browser.d.ts"/>
var app_component_1 = require("./app.component");
var browser_1 = require("angular2/platform/browser");
var router_1 = require("angular2/router");
var core_1 = require('angular2/core');
browser_1.bootstrap(app_component_1.AppComponent, [
    router_1.ROUTER_PROVIDERS,
    core_1.provide(core_1.PLATFORM_DIRECTIVES, {
        useValue: [router_1.ROUTER_DIRECTIVES], multi: true })
]);
//# sourceMappingURL=main.js.map