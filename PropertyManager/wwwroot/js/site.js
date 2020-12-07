


$("#add-property-save").on('click', () => {
    var purchasePrice = $("#purchase-price").val();
    var currentMarketValue = $("#current-market-value").val();
    var state = $("#state").val();
    var city = $("#city").val();
    var streetAddress = $("#street-address").val();
    var propertyType = $("#property-type").val();
    var purchaseDate = $("#purchase-date").val();
    var currentRentPerMonth = $("#current-rents").val();
    var marketRentsPerMonth = $("#market-rents").val();
    var isVacant = $("#is-rented").val();

    $.post({
        url: "https://localhost:5001/propertyajax/savepropertyfromform",
        data: { purchasePrice: purchasePrice, currentMarketValue: currentMarketValue, state: state, city: city, streetAddress: streetAddress, propertyType: propertyType, purchaseDate: purchaseDate, currentRentPerMonth: currentRentPerMonth, currentMarketValue: currentMarketValue, isVacant: isVacant }
    })
        .done(() => {
            // TODO: Replace with growler alerts
            alert('successfully added property')
        })
        .fail((response) => {
            console.log(response);
        })

    //DateTime ? purchaseDate, double ? monthsOwned,
        //int ? currentRentPerMonth, int ? marketRentsPerMonth, bool isVacant)
})

function removePropertyFromCard() {
    var id = localStorage.getItem("PropertyToDelete");
    var data = { propertyId: id };
    $.post({
        url: "https://localhost:5001/propertyajax/DeleteUserProperty",
        data: data
    })
        .done(() => {
            
            alert('remove property successfully');
            $("#modal-remove-property").modal('hide');
            $(`#card-${id}`).css("display", "none");
        })
        .fail(response => {
            console.log(response);
        })
}

function setPropertyToRemove(id) {
    localStorage.setItem("PropertyToDelete", id);
}