// Toplantı formunu gönderme
document.getElementById('meetingForm').addEventListener('submit', function (event) {
    event.preventDefault();

    const selectedCheckboxes = Array.from(document.querySelectorAll('#participantsCheckboxList input[type="checkbox"]:checked'));
    const participants = selectedCheckboxes.map(checkbox => ({
        id: checkbox.value,
        name: checkbox.nextElementSibling.textContent,
        email: "", // Boş alan, sunucudan gelebilir
        meetingId: 0 // Yeni toplantı için ID sunucudan gelir
    }));

    //const date = new Date(document.getElementById('date').value + 'T00:00:00Z');
    //const startTime = document.getElementById('startTime').value + ':00';
    //const endTime = document.getElementById('endTime').value + ':00';
    

    const meetingData = {
        meetingDto: {
            id: 0, // Yeni bir toplantı için genellikle 0 kullanılır
            topic: document.getElementById('topic').value,
            date: date.toISOString(), // UTC formatında
            startTime: document.getElementById('startTime').value + ':00', // "hh:mm:ss" formatında
            endTime: document.getElementById('endTime').value + ':00', // "hh:mm:ss" formatında
            participants: participants,
        }
    };

    fetch('https://localhost:7169/api/meetings', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(meetingData),
    })
        .then(response => {
            if (!response.ok) {
                return response.json().then(err => { throw new Error(err.title || 'API isteği başarısız.'); });
            }
            return response.json();
        })
        .then(data => {
            fetchMeetings(); // Yeni listeyi yükle
            document.getElementById('meetingForm').reset(); // Formu temizle
        })
        .catch(error => {
            console.error('Hata:', error.message);
        });
});

// Toplantıları listeleme fonksiyonu
function fetchMeetings() {
    fetch('https://localhost:7169/api/meetings')
        .then(response => response.json())
        .then(data => {
            const meetingList = document.getElementById('meetingList');
            meetingList.innerHTML = ''; // Önceki verileri temizle

            data.forEach(meeting => {
                // Yeni bir tablo satırı oluştur
                const tr = document.createElement('tr');

                // Toplantı konusunu bir hücreye ekle
                const topicCell = document.createElement('td');
                topicCell.textContent = meeting.topic;
                tr.appendChild(topicCell);

                // Tarihi bir hücreye ekle
                const dateCell = document.createElement('td');
                dateCell.textContent = new Date(meeting.date).toLocaleDateString(); // Tarihi formatla
                tr.appendChild(dateCell);

                // Başlangıç saatini bir hücreye ekle
                const startTimeCell = document.createElement('td');
                startTimeCell.textContent = meeting.startTime;
                tr.appendChild(startTimeCell);

                // Bitiş saatini bir hücreye ekle
                const endTimeCell = document.createElement('td');
                endTimeCell.textContent = meeting.endTime;
                tr.appendChild(endTimeCell);

                // Katılımcıları bir hücreye ekle
                const participantsCell = document.createElement('td');
                participantsCell.textContent = meeting.participants.map(p => p.name).join(', ');
                tr.appendChild(participantsCell);

                // Silme butonunu bir hücreye ekle
                const actionCell = document.createElement('td');
                const deleteButton = document.createElement('button');
                deleteButton.classList.add('btn', 'btn-danger', 'btn-sm');
                deleteButton.textContent = 'Sil';
                deleteButton.onclick = function () {
                    deleteMeeting(meeting.id);
                };

                actionCell.appendChild(deleteButton);
                tr.appendChild(actionCell);

                // Satırı tabloya ekle
                meetingList.appendChild(tr);
            });
        })
        .catch(error => {
            console.error('Hata:', error);
        });
}

// Silme fonksiyonu
function deleteMeeting(id) {
    if (confirm('Bu toplantıyı silmek istediğinizden emin misiniz?')) {
        fetch(`https://localhost:7169/api/meetings/${id}`, {
            method: 'DELETE',
        })
            .then(response => {
                if (response.ok) {
                    fetchMeetings(); // Silindikten sonra listeyi güncelle
                } else {
                    console.error('Silme işlemi başarısız: ', response.statusText);
                }
            })
            .catch(error => {
                console.error('Hata:', error);
            });
    }
}

// Katılımcı listesini dinamik olarak doldurma (Örnek)
function fetchParticipants() {
    // Sunucudan katılımcıları çekmek için
    fetch('https://localhost:7169/api/participants')
        .then(response => response.json())
        .then(data => {
            const participantsCheckboxList = document.getElementById('participantsCheckboxList');
            participantsCheckboxList.innerHTML = ''; // Önceki listeyi temizle

            data.forEach(participant => {
                const checkbox = document.createElement('input');
                checkbox.type = 'checkbox';
                checkbox.value = participant.id;
                checkbox.classList.add('form-check-input');

                const label = document.createElement('label');
                label.classList.add('form-check-label');
                label.textContent = participant.name;

                const div = document.createElement('div');
                div.classList.add('form-check');

                div.appendChild(checkbox);
                div.appendChild(label);

                participantsCheckboxList.appendChild(div);
            });
        })
        .catch(error => {
            console.error('Katılımcılar yüklenirken hata:', error);
        });
}

// Sayfa yüklendiğinde toplantıları ve katılımcıları çek
window.onload = function () {
    fetchMeetings();
    fetchParticipants();
};
