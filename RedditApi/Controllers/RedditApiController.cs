using HtmlAgilityPack; // Library for parsing HTML content
using Microsoft.AspNetCore.Mvc; // Namespace for ASP.NET Core MVC
using RedditScrape007.Models; // Namespace containing RedditPost model



[ApiController] // Attribute to indicate that the class is an API controller
[Route("api/[controller]")] // Route , API endpoints
public class RedditApiController : ControllerBase // Inherits from ControllerBase for API controllers
{

    // GET: api/reddit/posts
    [HttpGet]
    [Route("posts")]
    public async Task<IActionResult> GetFirst10Posts() // Action method to get the first 10 posts
    {
        var redditUrl = "https://www.reddit.com/r/all/"; // URL of the Reddit ALL page to scrape

        try 
        {
            using (var httpClient = new HttpClient()) // Create an instance of HttpClient
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", "RedditScrape007"); // Add a user-agent header, This is mandotory due to Reddit rules and limitations 

                var htmlContent = await httpClient.GetStringAsync(redditUrl); // Fetch HTML content asynchronously

                await Task.Delay(5000); // Delay for 5 seconds for dynamic content creation

               // HtmlAgilityPack to parse the HTML content
                var htmlDocument = new HtmlDocument(); // Create an instance of HtmlDocument
                htmlDocument.LoadHtml(htmlContent); // Load HTML content into the document

                // Select post link elements using XPath
                var postLinkNodes = htmlDocument.DocumentNode.SelectNodes("//article[contains(@class, 'w-full')]"); // Select post nodes

                var posts = new List<RedditPost>(); // Initialize a list to store Reddit posts

                if (postLinkNodes != null) // Check if there are post nodes
                {
                    // Iterate through the post link nodes to extract the post details
                    foreach (var postLinkNode in postLinkNodes.Take(5)) // Limit to the first 5 posts
                    {
                        var titleNode = postLinkNode.SelectSingleNode(".//a[@slot='title']"); // Select the post title node
                        var title = titleNode?.InnerText.Trim(); // Get the inner text of the title node

                        var subredditImg = postLinkNode.SelectSingleNode(".//shreddit-post")?.GetAttributeValue("content-href", ""); // Get the image link

                        var isVideo = subredditImg.EndsWith(".jpeg"); // Check if the link is a video

                        if (!isVideo) // If it's not a video
                        {
                            // Placeholder image for videos // Could not figure out how to get the videos from Reddit...
                            subredditImg = "https://via.placeholder.com/1500x2100";
                        }

                        // Extract subreddit title
                        var subredditTitle = postLinkNode.SelectSingleNode(".//shreddit-post")?.GetAttributeValue("subreddit-prefixed-name", "");

                        // Extract upvote count
                        var upvoteCount = postLinkNode.SelectSingleNode(".//shreddit-post")?.GetAttributeValue("score", "");

                        // Extract comment count
                        var commentCount = postLinkNode.SelectSingleNode(".//shreddit-post")?.GetAttributeValue("comment-count", "");

                        // Extract age
                        var age = postLinkNode.SelectSingleNode(".//shreddit-post")?.GetAttributeValue("created-timestamp", "");

                        // Parse the datetime attribute value into a DateTime object
                        if (DateTime.TryParse(age, out DateTime datetime))
                        {
                            // Display only the date part in the desired format
                            var datePart = datetime.Date.ToString("yyyy-MM-dd");
                            age = datePart; 
                        }
                        else
                        {
                            Console.WriteLine("Failed to parse datetime attribute value.");
                        }

                        // Create a RedditPost object with extracted details
                        var post = new RedditPost
                        {
                            Title = title,
                            SubredditTitle = subredditTitle,
                            UpvoteCount = upvoteCount,
                            CommentCount = commentCount,
                            Age = age,
                            imagelink = subredditImg
                        };

                        posts.Add(post); // Add the post to the list
                    }
                }

                return Ok(posts); // Return OK response with the list of posts
            }
        }
        catch (Exception ex) // Catch any exceptions
        {
            return StatusCode(500, $"An error occurred: {ex.Message}"); 
    }
} // End of class RedditApiController



