///<reference path="~/Content/js/ThirdParty/jasmine/jasmine.js"/>
///<reference path="~/Content/js/ThirdParty/angular.min.js"/>
///<reference path="~/Content/js/ThirdParty/angular-apimock.js"/>

///<reference path="~/Content/js/App/app.modulejs"/>
///<reference path="~/Content/js/App/Blog/blog.module.js"/>
///<reference path="~/Content/js/App/Blog/blog.service.js"/>

describe("ServiceTests", function () {

    beforeEach(module("app.blog"));

    describe("Blog service", function () {

        var blog;

        beforeEach(inject(function ($injector) {
            blog = $injector.get('blogService')
        }));

        it('should return 1 blog when querying', function () {
            expect(blog.getBlogs().length).toBe(1);
        });

    });

});