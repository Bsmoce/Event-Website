$(function () {
    $("#tbUser").on("click", ".BookDel", function () {
        var btn = $(this);
        bootbox.confirm("Do you want to delelte the Booking?", function (result) {
            if (result) {
                var id = btn.data("id");
                $.ajax({
                    type: "GET",
                    url: "/CUsers/Book_del/" + id,
                    success: function () {
                        btn.parent().parent().remove();
                    }
                });
            }
        });
    });
});
