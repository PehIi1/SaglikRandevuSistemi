document.addEventListener("DOMContentLoaded", () => {
    debugger
    const guncelleButton = document.getElementById("guncelle");
    const inputs = document.querySelectorAll("input, select");
    const form = document.getElementById("profilForm");

    let isEditing = false; // Başlangıçta düzenleme kapalı

    guncelleButton.addEventListener("click", () => {
        if (!isEditing) {
            inputs.forEach(input => input.removeAttribute("readonly"));
            document.getElementById("cinsiyet").removeAttribute("disabled");

            // 3️⃣ Butonun adını değiştir
            guncelleButton.textContent = "Kaydet";
        } else {
            // 4️⃣ Eğer buton "Kaydet" modundaysa formu gönder
            form.submit();
        }

        isEditing = !isEditing; // Durumu tersine çevir
    });
});