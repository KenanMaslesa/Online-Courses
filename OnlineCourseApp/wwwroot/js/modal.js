$(document).ready(function () {
    $(".btn-popup").click(function () {
        event.preventDefault();

        var $modal = $("#global_modal");
        $modal.modal('toggle');
        var modalTitle = $(this).data("modaltitle");
        var modalHeader = $(this).data("modal-header");

       
        $.get($(this).data("url"), function (result) {
            $modal.find(".modal-title").html(modalTitle);
            $modal.find(".modal-header").css("display", modalHeader);
            $modal.find(".modal-body").html(result);
        });
    })
});
$("[data-toggle=popover]").popover();