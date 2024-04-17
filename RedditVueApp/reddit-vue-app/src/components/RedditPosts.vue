<template>
  <div class="reddit-posts">
    <h1>Reddit Posts</h1>
    <ul>
      <li v-for="post in posts" :key="post.title">
        <div class="post-container">
          <div class="post-content">
            <div class="post-info">
              <p>Age: {{ post.age }}</p>
              <p>Subreddit: {{ post.subredditTitle }}</p>
              <h2>{{ post.title }}</h2>
            </div>
            <div class="post-image">
              <img :src="post.imagelink" alt="Post Image">
            </div>
          </div>
          <div class="post-details">
            <button class="upvote-button">Upvote {{ post.upvoteCount }}</button>
            <button class="downvote-button">Downvote</button>
            <button class="Comments-button">Comments {{ post.commentCount }}</button>
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
body {
  background-color: #0000009d; /* Set background color to light gray */
}

.reddit-posts {
  max-width: 900px;
  margin: 0 auto;

}

.post-container {
  background-color: #f4f4f4b4; /* Set background color to light gray */

  border: 1px solid #ccc;
  border-radius: 5px;
  margin-bottom: 20px;
}

.post-content {
  display: flex;
  flex-direction: column; /* Display children in column layout */
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







