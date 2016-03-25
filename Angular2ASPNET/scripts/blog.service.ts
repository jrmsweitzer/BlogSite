import {BLOGS} from './mock-blogs';
import {Blog} from './blog';
import {Injectable} from 'angular2/core';

@Injectable()
export class BlogService {
    getBlog(id: number) {
        return Promise.resolve(BLOGS).then(
            blogs => blogs.filter(blog => blog.id === id)[0]
        );
    } 

    getBlogs() {
        return Promise.resolve(BLOGS);
    }
}