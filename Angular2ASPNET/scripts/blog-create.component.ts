import {Component, OnInit} from 'angular2/core';

import {Blog} from './blog';
import {BlogService} from './blog.service';


@Component({
    selector: 'blog-create',
    templateUrl: 'app/blog-create.component.html',
})

export class BlogCreateComponent {
    title: string;
    post: string;
    tags: string;
    postPreview: string;
    allowComments: boolean;
    nsfw: boolean;

    constructor(
        private _blogService: BlogService) {
    }

    ngOnInit() {
    }
}