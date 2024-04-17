# RedditScraper

## Description
RedditScraper is a web application that fetches and displays Reddit posts from the r/all subreddit. It provides users with a simple interface to view the latest posts, including their titles, subreddit titles, upvote counts, comment counts, and post ages.

## Setup and Installation
To set up and run the RedditScraper project, follow these steps:

1. **Clone the Repository**: 


2. **Navigate to the Project Directory**:

3. **Backend Setup**:
- Navigate to the `RedditScraper.API` directory:
  ```
  cd RedditScraper.API
  ```
- Install dependencies:
  ```
  dotnet restore
  ```
- Run the backend server:
  ```
  dotnet run
  ```
- The backend server will run on `https://localhost:7050`.
4. **Frontend Setup**:
- Navigate to the `RedditScraper.Client` directory:
  ```
  cd ../RedditScraper.Client
  ```
- Install dependencies:
  ```
  npm install
  ```
- Run the frontend server:
  ```
  npm run serve
  ```
- The frontend server will run on `http://localhost:8080`.
5. **Access the Application**:
- Open your web browser and go to `http://localhost:8080` to access the RedditScraper application.

## Usage
- Upon accessing the application, you will see a list of the latest Reddit posts from the r/all subreddit.
- Each post includes its title, subreddit title, upvote count, comment count, and age.
- You can scroll through the posts and interact with the buttons provided for each post.

That's it! You have successfully set up and run the RedditScraper project. Enjoy exploring the latest Reddit posts!
