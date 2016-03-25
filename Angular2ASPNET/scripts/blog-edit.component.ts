import {Component, OnInit} from "angular2/core";
import {RouteParams} from "angular2/router";
import {IBlog} from "./blog";
import {BlogService} from "./blog.service";

@Component({
    selector: "blog-edit",
    templateUrl: "app/blog-edit.component.html"
})

export class BlogEditComponent implements OnInit {
    blog: IBlog;

    constructor(
        private _blogService: BlogService,
        private _routeParams: RouteParams) { }

    ngOnInit() {
        let id = +this._routeParams.get("id");

        this._blogService.getBlog(id)
            .then(blog => this.blog = blog);

    }

    goBack() {
        window.history.back();
    }
}