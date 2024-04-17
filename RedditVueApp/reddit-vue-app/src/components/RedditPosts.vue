<template>
  <!-- Reddit Posts component -->
  <div class="reddit-posts">
    <h1>Reddit Posts</h1> <!-- Title -->
    <ul>
      <!-- Loop through each post -->
      <li v-for="post in posts" :key="post.title">
        <!-- Post container -->
        <div class="post-container">
          <!-- Post content -->
          <div class="post-content">
            <!-- Post information -->
            <div class="post-info">
              <p>Age: {{ post.age }}</p> <!-- Display post age -->
              <p>Subreddit: {{ post.subredditTitle }}</p> <!-- Display subreddit title -->
              <h2>{{ post.title }}</h2> <!-- Display post title -->
            </div>
            <!-- Post image -->
            <div class="post-image">
              <img :src="post.imagelink" alt="Post Image"> <!-- Display post image -->
            </div>
          </div>
          <!-- Post details -->
          <div class="post-details">
            <!-- Upvote button -->
            <button class="upvote-button">Upvote {{ post.upvoteCount }}</button> <!-- Display upvote count -->
            <!-- Downvote button -->
            <button class="downvote-button">Downvote</button>
            <!-- Comments button -->
            <button class="Comments-button">Comments {{ post.commentCount }}</button> <!-- Display comment count -->
          </div>
        </div>
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  props: {
    posts: { 
      type: Array, 
      required: true 
    }
  }
}
</script>

<style>
/* Styling */

body {
  background-color: #0000009d; 
}

.reddit-posts {
  max-width: 900px; 
  margin: 0 auto; 
}

.post-container {
  background-color: #f4f4f4b4; 
  border: 1px solid #ccc; 
  border-radius: 5px; 
  margin-bottom: 20px; 
}

.post-content {
  display: flex; 
  flex-direction: column; 
}

.post-info {
  padding: 10px; 
}

.post-image img {
  width: 100%; 
  height: auto; 
  object-fit: cover; 
}

.post-details {
  display: flex; 
}

.post-details button {
  margin-right: 10px; 
}
</style>
