$(function () {
    $("#tbEvent").on("click", ".EventDel", function () {
        var btn = $(this);
        bootbox.confirm("Do you want to delelte the Event?", function (result) {
            if (result) {
                var id = btn.data("id");
                $.ajax({
                    type: "GET",
                    url: "/CEvent/Event_del/" + id,
                    success: function () {
                        btn.parent().parent().remove();
                    }
                });
            }
        });
    });
});