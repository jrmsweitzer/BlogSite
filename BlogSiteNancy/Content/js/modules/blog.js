$('#EditBlogButton').click(function () {
    $.post("/edit", function (data, status) {
        alert('Data: ' + data + "\nStatus: " + status);
    });
});