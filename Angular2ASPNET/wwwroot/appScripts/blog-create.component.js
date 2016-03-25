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
var blog_service_1 = require('./blog.service');
var BlogCreateComponent = (function () {
    function BlogCreateComponent(_blogService) {
        this._blogService = _blogService;
    }
    BlogCreateComponent.prototype.ngOnInit = function () {
    };
    BlogCreateComponent = __decorate([
        core_1.Component({
            selector: 'blog-create',
            templateUrl: 'app/blog-create.component.html',
        }), 
        __metadata('design:paramtypes', [blog_service_1.BlogService])
    ], BlogCreateComponent);
    return BlogCreateComponent;
}());
exports.BlogCreateComponent = BlogCreateComponent;
//# sourceMappingURL=blog-create.component.js.map