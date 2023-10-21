
var ProductsOrderId = [];
function getProducts(id) {
    $.ajax({
        url: "/home/HomeProductShow",
        data: { "catID": id },
        success: function (result) {
            $("#products").html(result);

            // Retrieve ProductsOrderId from localStorage
            ProductsOrderId = JSON.parse(localStorage.getItem("ProductsOrderId")) || [];

            // Select all elements with the class "productrow"
            var products = document.querySelectorAll(".productrow");

            for (var i = 0; i < products.length; i++) {
                var productId = products[i].id;

                if (ProductsOrderId?.some(productToDesable => productToDesable == productId)) {
                    var product = document.getElementById(productId);
                    $(product).prop("disabled", true);
                }
            }
        }
    });
}

function getSelectProduct(id) {
    var product = document.getElementById(id);
    ProductsOrderId.push(id);
    localStorage.setItem("ProductsOrderId", JSON.stringify(ProductsOrderId));
    $(product).prop("disabled", true);
    $.ajax({
        url: "/product/GetByID",
        data: { "id": id }
        , success: function (result) {
            $("#orderRow").append(result);
        }
    });
}
function Delete(e, id) {
    var confirmDelete = confirm("Are you sure you want to delete?");
    if (confirmDelete) {
        // Find the parent element and remove it when the user confirms
        var parent = e.parentNode;
        parent.remove();

        // Update localStorage to remove the deleted product's ID
        ProductsOrderId = JSON.parse(localStorage.getItem("ProductsOrderId"));
        ProductsOrderId = ProductsOrderId.filter(productId => productId != id);
        localStorage.setItem("ProductsOrderId", JSON.stringify(ProductsOrderId));

        // Re-enable the button or element if you were previously disabling it
        var product = document.getElementById(id);
        if (product) {
            $(product).prop("disabled", false);
        }
    }
}
