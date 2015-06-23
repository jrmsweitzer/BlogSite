function BlogViewModel() {
    var self = this;
    self.currentBlog = ko.observable(new Blog());

    self.saveBlog = function () {
        var blogModel = ko.mapping.toJS(self.currentBlog);
        ko.utils.postJson("/Blog/Create", { model: blogModel });
    };
}

function Blog(blogTitle, blogPost, blogTags) {
    var self = this;
    self.Title = ko.observable(blogTitle);
    self.Post = ko.observable(blogPost);
    self.Tags = ko.observableArray(blogTags);
}

$(document).ready(function() {
    window.ko.applyBindings(new BlogViewModel());
});