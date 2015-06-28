ko.bindingHandlers.richText = {
    init: function (element, valueAccessor) {

        console.log("element: " + element);
        console.log("valueAccessor: " + valueAccessor);

        var modelValue = valueAccessor();
        console.log("modelValue: " + modelValue);
        var value = ko.utils.unwrapObservable(valueAccessor());
        console.log("value: " + value);
        var element$ = $(element);
        console.log("element$: " + element$);

        // Set initial value and create the CKEditor
        element$.html(value);
        var editor = element$.ckeditor().editor;
        console.log("editor: " + editor);

        // bind to change events and link it to the observable
        editor.on('change', function (e) {
            var self = this;
            if (ko.isWriteableObservable(self)) {
                self($(e.listenerData).val());
            }
        }, modelValue, element);


        /* Handle disposal if KO removes an editor 
         * through template binding */
        ko.utils.domNodeDisposal.addDisposeCallback(element,
            function () {
                editor.updateElement();
                editor.destroy();
            });
    },

    /* Hook and handle the binding updating so we write 
     * back to the observable */
    update: function (element, valueAccessor) {
        var element$ = $(element);
        var newValue = ko.utils.unwrapObservable(valueAccessor());
        if (element$.ckeditorGet().getData() != newValue) {
            element$.ckeditorGet().setData(newValue);
        }
    }
}

function BlogViewModel() {
    var self = this;

    self.Title = ko.observable();
    self.Post = ko.observable();
    self.Tags = ko.observableArray();

    self.saveBlog = function () {
        var blogModel = ko.mapping.toJS(self.currentBlog);
        ko.utils.postJson("/Blog/Create", { model: blogModel });
    };
}

var vm = new BlogViewModel();

$(document).ready(function () {
    ko.applyBindings(vm, document.getElementById('Content'));
});