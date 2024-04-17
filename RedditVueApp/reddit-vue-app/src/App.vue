<template>
 
  <div id="app">
    
    <RedditPosts :posts="redditPosts" /> <!-- Pass redditPosts data to RedditPosts component -->
  </div>
</template>

<script>

import RedditPosts from './components/RedditPosts.vue'; // Import the RedditPosts component
import axios from 'axios'; // Import Axios library

export default {
  name: 'App', 
  data() {
    return {
      redditPosts: [] // Initialize redditPosts data as an empty array
    };
  },
  mounted() {
    // Lifecycle hook: mounted
    this.fetchRedditPosts(); // Call fetchRedditPosts method when component is mounted
  },
  methods: {
    // Method to fetch Reddit posts
    async fetchRedditPosts() {
      try {
        const response = await axios.get('https://localhost:7050/api/RedditApi/posts'); // Make GET request to fetch Reddit posts
        this.redditPosts = response.data; // Assign retrieved data to redditPosts
      } catch (error) {
        console.error('Error fetching Reddit posts:', error); // Log error if fetching fails
      }
    }
  },
  components: {
    RedditPosts // Register RedditPosts component
  }
}
</script>
