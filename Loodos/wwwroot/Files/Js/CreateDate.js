$(document).on("click", "#btnDateCreate", function () {

    var startDateControl = Date.parse($("#dateStart").val()) || 0;
    var endDateControl = Date.parse($("#dateEnd").val()) || 0;
    if (startDateControl == 0 || endDateControl == 0) {
        alert("Lütfen Tarih Seçme Kısımlarını Boş Bırakamayın");
        window.location.reload();
    } else {

        var startDate = $("#dateStart").val();
        var endDate = $("#dateEnd").val();

        $.ajax({
            method: "GET",
            url: "http://localhost:62600/api/" + startDate + "/" + endDate + "/",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                alert(data.message);
                window.location = "http://localhost:62600/Home/Index";
            },
            error: function (data) {
                alert("Bir Hata Oluştu");
            }
        });

    }


});