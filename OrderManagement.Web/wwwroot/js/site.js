function AddItemToTable(nameValue, quantityValue, unitValue, count ) {
    let orderItem = {
        id: 0,
        itemName: nameValue,
        quantity: quantityValue,
        unit: unitValue
    }
    let rowString = '<tr><th scope="row">' + count + '</th><td>'
        + orderItem.itemName + '</td><td>'
        + orderItem.quantity + '</td><td>'
        + orderItem.unit + '</td></tr>';
    return {
        orderItem,
        rowString
    }
}
function SendFormData(form, order, url) {
    form.on("submit", function (e) {
        e.preventDefault();
        if (form.valid()) {
            $.ajax({
                url: form.attr("action"),
                data: order,
                type: "POST",
                contentType: "application/json",
                success: function () {
                    window.location = url;
                },
                error: function (result) {
                    console.log(result);
                    alert("Ошибка добавления");
                }
            });
        }
    });
}