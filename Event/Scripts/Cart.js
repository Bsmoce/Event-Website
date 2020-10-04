
var taxRate = 0.05;
var fadeTime = 300;

$(".product-removal button").click(function () {
    removeItem(this);
});

function recalculateCart() {
    var subtotal = 0;

    $(".product").each(function () {
        subtotal += parseFloat($(this).children(".product-line-price").text());
    });


    var tax = subtotal * taxRate;
    var total = subtotal + tax;

    /* Update totals display */
    $(".totals-value").fadeOut(fadeTime, function () {
        $("#cart-subtotal").html(subtotal.toFixed(2));
        $("#cart-tax").html(tax.toFixed(2));
        $("#cart-total").html(total.toFixed(2));
        if (total == 0) {
            $(".checkout").fadeOut(fadeTime);
        } else {
            $(".checkout").fadeIn(fadeTime);
        }
        $(".totals-value").fadeIn(fadeTime);
    });
}


    /* Update line price display and recalc cart totals */
    productRow.children(".product-line-price").each(function () {
        $(this).fadeOut(fadeTime, function () {
            $(this).text(linePrice.toFixed(2));
            recalculateCart();
            $(this).fadeIn(fadeTime);
        });
    });
}

/* Remove item from cart */
function removeItem(removeButton) {
    /* Remove row from DOM and recalc cart total */
    var productRow = $(removeButton).parent().parent();
    productRow.slideUp(fadeTime, function () {
        productRow.remove();
        recalculateCart();
    });
}
