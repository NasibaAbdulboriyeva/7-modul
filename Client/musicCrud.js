class Music {
  constructor(id, title, artist, genre) {
    this.id = id;
    this.title = title;
    this.artist = artist;
    this.genre = genre;
  }
}

let musicList = [];
let musicIdCounter = 1;

const form = document.getElementById('musicForm');
const tableBody = document.getElementById('musicTable');

form.addEventListener('submit', function (e) {
  e.preventDefault();

  const id = document.getElementById('musicId').value;
  const title = document.getElementById('title').value.trim();
  const artist = document.getElementById('artist').value.trim();
  const genre = document.getElementById('genre').value.trim();

  if (!title || !artist || !genre) return;

  if (id) {
    updateMusic(parseInt(id), title, artist, genre);
  } else {
    addMusic(title, artist, genre);
  }

  form.reset();
  document.getElementById('musicId').value = '';
  renderTable();
});

function addMusic(title, artist, genre) {
  const music = new Music(musicIdCounter++, title, artist, genre);
  musicList.push(music);
}

function updateMusic(id, title, artist, genre) {
  const music = musicList.find(m => m.id === id);
  if (music) {
    music.title = title;
    music.artist = artist;
    music.genre = genre;
  }
}

function deleteMusic(id) {
  musicList = musicList.filter(m => m.id !== id);
  renderTable();
}

function editMusic(id) {
  const music = musicList.find(m => m.id === id);
  if (music) {
    document.getElementById('musicId').value = music.id;
    document.getElementById('title').value = music.title;
    document.getElementById('artist').value = music.artist;
    document.getElementById('genre').value = music.genre;
  }
}

function renderTable() {
  tableBody.innerHTML = '';
  musicList.forEach((m, index) => {
    const row = document.createElement('tr');
    row.innerHTML = `
      <td>${index + 1}</td>
      <td>${m.title}</td>
      <td>${m.artist}</td>
      <td>${m.genre}</td>
      <td>
        <button class="btn btn-sm btn-success me-2" onclick="editMusic(${m.id})">Edit</button>
        <button class="btn btn-sm btn-danger" onclick="deleteMusic(${m.id})">Delete</button>
      </td>
    `;
    tableBody.appendChild(row);
  });
}
