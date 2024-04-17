<template>
  <div id="app">
    <RedditPosts :posts="redditPosts" />
  </div>
</template>

<script>
import RedditPosts from './components/RedditPosts.vue'; // Import the RedditPosts component
import axios from 'axios'; // Import Axios library

export default {
  name: 'App',
  data() {
    return {
      redditPosts: []
    };
  },
  mounted() {
    this.fetchRedditPosts();
  },
  methods: {
    async fetchRedditPosts() {
      try {
        const response = await axios.get('https://localhost:7050/api/RedditApi/posts'); // Use Axios to make the request
        this.redditPosts = response.data; // Access response data directly
      } catch (error) {
        console.error('Error fetching Reddit posts:', error);
      }
    }
  },
  components: {
    RedditPosts
  }
}
</script>
