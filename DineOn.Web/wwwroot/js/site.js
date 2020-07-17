const $dropdown = $(".dropdown");
const $dropdownToggle = $(".dropdown-toggle");
const $dropdownMenu = $(".dropdown-menu");
const showClass = "show";

$(window).on("load resize", function () {
    if (this.matchMedia("(min-width: 768px)").matches) {
        $dropdown.hover(
            function () {
                const $this = $(this);
                $this.addClass(showClass);
                $this.find($dropdownToggle).attr("aria-expanded", "true");
                $this.find($dropdownMenu).addClass(showClass);
            },
            function () {
                const $this = $(this);
                $this.removeClass(showClass);
                $this.find($dropdownToggle).attr("aria-expanded", "false");
                $this.find($dropdownMenu).removeClass(showClass);
            }
        );
    } else {
        $dropdown.off("mouseenter mouseleave");
    }
});


// This Function Checks for any anchor tag (<a></a>)
// with class modal-trigger. When the anchor tag is clicked it 
// launches a modal whose header has been declared in the .cshtml file.
// The modal is defined in a partial view and renderred in the controller
$(document).ready(function () {

    $('.modal-trigger').click(function () {
        var url = $('#menuItemModal').data('url');
        $.get(url, function (data) {
            $("#menuItemModal").html(data);
            $("#menuItemModal").modal('show');

        });
    });

});
