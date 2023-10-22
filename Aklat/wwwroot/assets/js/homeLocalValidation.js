
var ProductsOrderId = [];
var ProductQuantity = 1;

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
function createArrayOfObjects() {
    const rows = document.querySelectorAll('.orderProd'); // Select all <tr> elements with the class "orderProd"
    const dataArray = [];
    rows.forEach(row => {
        const obj = {};

        // Get input elements within the current row
        const inputs = row.querySelectorAll('input');

        inputs.forEach(input => {
            const key = input.getAttribute('name'); // Use the 'name' attribute as the object key
            const value = input.value;
            obj[key] = value;
        });

        dataArray.push(obj); // Add the object to the array
    });
    var noteinpute = document.getElementById("note")
    var note = noteinpute.value;

    const requestData = {
        dataArray: dataArray,
        note: note
    };

    // Send the dataArray to the server using AJAX
    $.ajax({
        type: "POST",
        url: "/Order/GetPRO",
        data: JSON.stringify(requestData),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
        },
        error: function (error) {
            // Handle any errors
            console.log(error);
        }
    });
    localStorage.removeItem("ProductsOrderId");
}

function add(e) {
    var row = e.closest('tr');
    var quantityInput = row.querySelector('input[name="ProductQuantity"]');
    var priceInput = row.querySelector('input[name="Price"]');
    var totalPriceInput = row.querySelector('input[name="TotalPrice"]');
    quantityInput.value = parseInt(quantityInput.value)+1
    totalPriceInput.value = parseInt(quantityInput.value) * parseFloat(priceInput.value);
}

function less(e) {
    var row = e.closest('tr');
    var quantityInput = row.querySelector('input[name="ProductQuantity"]');
    var priceInput = row.querySelector('input[name="Price"]');
    var totalPriceInput = row.querySelector('input[name="TotalPrice"]');
    var quantity = parseInt(quantityInput.value) - 1;
    if (quantity < 1) {
        quantity = 1;
    }
    quantityInput.value = quantity;
    var price = parseFloat(priceInput.value);
    var total = quantity * price;
    totalPriceInput.value = total;
}

function adjustQuantity(input) {
    var row = input.closest('tr');
    var totalPriceInput = row.querySelector('#TotalPrice');
    var priceInput = row.querySelector('#Price');
    var currentValue = parseInt(input.value);
    ProductQuantity = currentValue;
    console.log(currentValue);
    totalPriceInput.value = currentValue * parseFloat(priceInput.value);
    console.log(totalPriceInput.value);
    //var originalValue = parseInt(input.getAttribute('data-original-value'));
    //if (currentValue > originalValue) {
    //    add(input);
    //} else if (currentValue < originalValue) {
    //    less(input);
    //}

//    input.setAttribute('data-original-value', currentValue);
}

