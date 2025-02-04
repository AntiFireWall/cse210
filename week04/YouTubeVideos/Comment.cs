namespace YouTubeVideos;

public class Comment
{
    private string _commentor;
    private string _comment;

    public Comment(string commentor, string comment)
    {
        _commentor = commentor;
        _comment = comment;
    }

    public void DisplayComment()
    {
        Console.WriteLine($"{_commentor}: '{_comment}'");
    }
}