<script setup>
import { ref } from 'vue';
import { RouterLink, RouterView } from 'vue-router'
import HelloWorld from './components/HelloWorld.vue'

let dragging = false;

const inputRef = ref(null);

const uploadFetch = () => {
  const file = inputRef.value.files[0];
  const formData = new FormData();
  formData.append("file", file)
  fetch("api/upload", {
    method: "post",
    enctype: "multipart/form-data",
    body: formData,
  }).then(response => console.log(response))
}

const handleDrop = (event) => {
  event.preventDefault();
  dragging = false;
  const files = event.dataTransfer.files;
  uploadFiles(files);
}
const handleFileInput = () => {
  const files = inputRef.files;
  uploadFiles(files);
}
const uploadFiles = async (files) => {
  const formData = new FormData();
  formData.append("file", files[0])
  fetch("api/upload", {
    method: "post",
    enctype: "multipart/form-data",
    body: formData,
  }).then(response => console.log(response))
}
</script>

<template>
  <p>
  <h1>form</h1>
  <form action="/api/upload" enctype="multipart/form-data" method="post">
    <label>
      file:
      <input type="file" name="file" />
    </label>
    <input type="submit">
  </form>
  </p>
  <p>
  <h1>fetch</h1>
  <label>
    file:
    <input type="file" ref="inputRef" />
  </label>
  <button @click="uploadFetch">submit</button>
  </p>
  <p>
  <h1>Drag and Drop</h1>
  <div class="file-upload">
    <div class="drop-area" @dragover.prevent @dragenter="dragging = true" @dragleave="dragging = false"
      @drop.prevent="handleDrop">
      <p v-if="dragging">ファイルをここにドロップしてください</p>
      <p v-else>ファイルをドラッグしてアップロード</p>
    </div>
    <input type="file" ref="fileInput" style="display: none" @change="handleFileInput">
  </div>
  </p>
</template>

<style scoped>
header {
  line-height: 1.5;
  max-height: 100vh;
}

.file-upload {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.drop-area {
  border: 2px dashed #ccc;
  padding: 20px;
  text-align: center;
  cursor: pointer;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}

nav {
  width: 100%;
  font-size: 12px;
  text-align: center;
  margin-top: 2rem;
}

nav a.router-link-exact-active {
  color: var(--color-text);
}

nav a.router-link-exact-active:hover {
  background-color: transparent;
}

nav a {
  display: inline-block;
  padding: 0 1rem;
  border-left: 1px solid var(--color-border);
}

nav a:first-of-type {
  border: 0;
}

@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }

  nav {
    text-align: left;
    margin-left: -1rem;
    font-size: 1rem;

    padding: 1rem 0;
    margin-top: 1rem;
  }
}
</style>
