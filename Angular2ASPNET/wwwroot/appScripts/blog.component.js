"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('angular2/core');
var router_1 = require('angular2/router');
var blog_create_component_1 = require('./blog-create.component');
var blog_list_component_1 = require('./blog-list.component');
var blog_service_1 = require('./blog.service');
var BlogComponent = (function () {
    function BlogComponent() {
    }
    BlogComponent = __decorate([
        core_1.Component({
            template: '<router-outlet></router-outlet>',
            directives: [router_1.RouterOutlet],
            providers: [blog_service_1.BlogService]
        }),
        router_1.RouteConfig([
            {
                path: '/',
                name: 'BlogList',
                component: blog_list_component_1.BlogListComponent
            },
            {
                path: '/create',
                name: 'BlogCreate',
                component: blog_create_component_1.BlogCreateComponent
            }
        ]), 
        __metadata('design:paramtypes', [])
    ], BlogComponent);
    return BlogComponent;
}());
exports.BlogComponent = BlogComponent;
//# sourceMappingURL=blog.component.js.map