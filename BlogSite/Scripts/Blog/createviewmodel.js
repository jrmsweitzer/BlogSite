function CreateViewModel() {
    this.blogTitle = ko.observable();
    this.blogPost = ko.observable();

    // validate data
    this.validateData = function () {
        var valid = true;
        if (!this.blogPost || !this.blogTitle ||
            this.blogPost.length === 0 || this.blogTitle.length === 0) {
            valid = false;
        }
        return valid;
    };

    // submit data
    this.createBlog = function() {
        ko.utils.postJson(location.href, {
            blogTitle: this.blogTitle,
            blogPost: this.blogPost
        });
    };
}

ko.applyBindings(new CreateViewModel());