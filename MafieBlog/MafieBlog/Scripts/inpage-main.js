$(document).ready(function () {

  //switch off dropdown menu
  $(document).off('.dropdown.data-api');
  
  //
  $("a.ajax").on("click", function (event) {
    event.preventDefault();
    var url = this.href;

    $.ajax({
      type: "GET",
      url: url,
      success: function (response) {

        var jsonObj = JSON.parse(response);

        if (jsonObj.result === "success") {

          $("#cart").load('/render/basket/');
          $('#addBasketModalTitle').html('<a href="' + jsonObj.url + '">' + jsonObj.title + '</a>');
          $('#addBasketModalImage').attr("href", jsonObj.url);
          $('#addBasketModalImage').html('<img class="img-thumbnail img-responsive" title="' + jsonObj.title + '" alt="' + jsonObj.title + '" src="' + jsonObj.imageUrl + '">');
          $('#addBasketModalVariant').html('<strong>' + jsonObj.variant + '</strong>');


          $priceHTML = '';
          if (jsonObj.priceOriginal !== '') {
            $priceHTML += '<div class="price-original-vat">' + jsonObj.priceOriginal;
            if (jsonObj.vat !== '') {
              $priceHTML += ' <span class="vat-info">' + jsonObj.vat + '</span>';
            }
            $priceHTML += '</div>';
          }

          if (jsonObj.priceCurrent !== '') {
            $priceHTML += '<div class="price-current-vat">' + jsonObj.priceCurrent;
            if (jsonObj.vat !== '') {
              $priceHTML += ' <span class="vat-info">' + jsonObj.vat + '</span>';
            }
            $priceHTML += '</div>';
          }

          $('#addBasketModalPrice').html($priceHTML);
          $('#addBasketModal').modal();

        } else {
          $('#addBasketModalError').modal();
        }
      },
      error: function () {
        $('#addBasketModalError').modal();
      }
    });

  });

  $('.thickbox').attr('data-gallery', '');
}); 


	
