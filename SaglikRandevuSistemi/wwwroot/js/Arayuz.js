
document.addEventListener('DOMContentLoaded', function() {
    // Tüm tab'leri seçiyoruz
    const tabs = document.querySelectorAll('.tab');
    const tabContents = document.querySelectorAll('.tab-content');

    // Her tab'a tıklama olayı ekliyoruz
    tabs.forEach((tab, index) => {
        tab.addEventListener('click', () => {
            // Aktif tab'ı kaldırıyoruz
            tabs.forEach(t => t.classList.remove('active'));
            tabContents.forEach(content => content.style.display = 'none');

            // Tıklanan tab'ı aktif yapıyoruz
            tab.classList.add('active');
            tabContents[index].style.display = 'block';
        });
    });

    // Sayfa yüklendiğinde ilk tab aktif olacak şekilde ayarlıyoruz
    tabContents.forEach((content, index) => {
        if (index !== 0) {
            content.style.display = 'none';
        }
    });
});