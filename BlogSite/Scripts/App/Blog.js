function Blog(blogTitle, blogPost) {
    var self = this;
    self.Title = ko.observable(blogTitle);
    self.Post = ko.observable(blogPost);
}

function BlogViewModel() {
    var self = this;
    self.currentBlog = ko.observable(new Blog());

    self.saveBlog = function() {
        var blogModel = ko.mapping.toJS(self.currentBlog);
        ko.utils.postJson("/Blog/Create", { model: blogModel });
    };
}

$(document).ready(function() {
    window.ko.applyBindings(new BlogViewModel());
});