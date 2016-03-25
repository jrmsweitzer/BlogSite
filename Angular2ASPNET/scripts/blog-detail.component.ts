import {Component, OnInit} from 'angular2/core';
import {RouteParams, Router} from 'angular2/router';
import {Blog} from './blog';
import {BlogService} from './blog.service';

@Component({
	selector: 'my-blog-detail',
	templateUrl: 'app/blog-detail.component.html'
})

export class BlogDetailComponent implements OnInit {
	blog: Blog;
	
	constructor(
		private _blogService: BlogService,
        private _routeParams: RouteParams,
        private _router: Router) { }
		
	ngOnInit() {
		let id = +this._routeParams.get('id');
		this._blogService.getBlog(id)
			.then(blog => this.blog = blog);
	}
	
	goBack() {
		window.history.back();
    }

    edit(id: number) {
        this._router.navigate(['BlogEdit', { id: id }]);
    }
}