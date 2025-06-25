let musicList = [];
let selectedIndex = -1;

function renderTable(list = musicList) {
  const tbody = document.getElementById("musicTableBody");
  tbody.innerHTML = "";
  list.forEach((music, index) => {
    tbody.innerHTML += `
      <tr onclick="selectMusic(${index})">
        <td>${index + 1}</td>
        <td>${music.title}</td>
        <td>${music.artist}</td>
        <td>${music.genre}</td>
      </tr>
    `;
  });
}

function addMusic() {
  const title = document.getElementById("title").value.trim();
  const artist = document.getElementById("artist").value.trim();
  const genre = document.getElementById("genre").value.trim();

  if (!title || !artist || !genre) return alert("Fill all fields");

  musicList.push({ title, artist, genre });
  clearForm();
  renderTable();
}

function selectMusic(index) {
  selectedIndex = index;
  const music = musicList[index];
  document.getElementById("title").value = music.title;
  document.getElementById("artist").value = music.artist;
  document.getElementById("genre").value = music.genre;
}

function updateMusic() {
  if (selectedIndex === -1) return alert("Select a music entry");
  const title = document.getElementById("title").value.trim();
  const artist = document.getElementById("artist").value.trim();
  const genre = document.getElementById("genre").value.trim();

  musicList[selectedIndex] = { title, artist, genre };
  selectedIndex = -1;
  clearForm();
  renderTable();
}

function deleteMusic() {
  if (selectedIndex === -1) return alert("Select a music entry");
  musicList.splice(selectedIndex, 1);
  selectedIndex = -1;
  clearForm();
  renderTable();
}

function getMusicByTitle() {
  const search = document.getElementById("searchTitle").value.trim().toLowerCase();
  const filtered = musicList.filter(m => m.title.toLowerCase().includes(search));
  renderTable(filtered);
}

function clearForm() {
  document.getElementById("title").value = "";
  document.getElementById("artist").value = "";
  document.getElementById("genre").value = "";
  document.getElementById("searchTitle").value = "";
}

window.onload = () => {
  renderTable();
};
