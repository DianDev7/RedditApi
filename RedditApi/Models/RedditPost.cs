namespace RedditScrape007.Models // Namespace for the RedditPost model
{
    public class RedditPost // Class representing a Reddit post
    {
        // Properties of the RedditPost class
        public string Title { get; set; } // Title of the post
        public string SubredditTitle { get; set; } // Title of the subreddit
        public string CommentCount { get; set; } // Number of comments on the post
        public string UpvoteCount { get; set; } // Number of upvotes on the post
        public string Age { get; set; } // Age of the post
        public string imagelink { get; set; } // URL of the post image
    }
}
