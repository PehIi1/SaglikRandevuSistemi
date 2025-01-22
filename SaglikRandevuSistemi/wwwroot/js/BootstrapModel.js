function openModal(randevuId, tarih) {
    // Modal'a randevu ID'sini gönder
    $('#modalRandevuId').val(randevuId);

    // Saatler için dropdown'ı temizle
    $('#saatDropdown').empty();

    // 9-16 saatleri için API çağrısı yap
    $.getJSON('/Randevu/GetMusaitSaatler', { randevuId: randevuId, tarih: tarih }, function (data) {
        $('#saatDropdown').append('<option value="">Bir saat seçiniz</option>');
        data.forEach(function (saat) {
            $('#saatDropdown').append('<option value="' + saat + '">' + saat + '</option>');
        });
    });

    // Modal'ı göster
    $('#saatSecimModal').modal('show');
}

$('#saatKaydetBtn').click(function () {
    // Seçilen saat ve randevu ID'sini al
    var randevuId = $('#modalRandevuId').val();
    var secilenSaat = $('#saatDropdown').val();

    if (!secilenSaat) {
        alert('Lütfen bir saat seçiniz.');
        return;
    }

    // Formu gönder
    $.post('/Randevu/SaatSecimi', { RandevuId: randevuId, SecilenSaat: secilenSaat }, function () {
        alert('Randevu saati kaydedildi.');
        $('#saatSecimModal').modal('hide');
        location.reload(); // Sayfayı yenile
    });
});