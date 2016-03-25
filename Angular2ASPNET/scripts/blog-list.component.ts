import {Component, OnInit} from 'angular2/core';
import {Router} from 'angular2/router';
import {Blog} from './blog';
import {BlogDetailComponent} from './blog-detail.component';
import {BlogService} from './blog.service';

@Component({
	selector: 'my-blogs',
	templateUrl: 'app/blogs.component.html',
	styleUrls: ['app/blogs.component.css']
})

export class BlogListComponent implements OnInit {
	constructor(
		private _blogService: BlogService,
		private _router: Router) {}
		
	ngOnInit() {
		this.getBlogs();
	}
	
	title = "Read our Blogs!";
	blogs: Blog[];
	selectedBlog: Blog;
	
	onSelect(blog: Blog) {
		this.selectedBlog = blog;
	}
	
	getBlogs() {
		this._blogService.getBlogs().then(blogs => this.blogs = blogs);
	}
	
	gotoDetail() {
		this._router.navigate(['BlogDetail', {id: this.selectedBlog.id}]);
	}
}