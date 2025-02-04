using System;
using YouTubeVideos;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();
        Video video1 = new Video("The Secret Life of Black Holes", "SpaceTime Academy", 12.75);
        Comment comment1 = new Comment("AstroNerd99", "Mind-blowing! The way they explained time dilation made it so much clearer.");
        Comment comment2 = new Comment("GalacticGazer", "I never knew black holes could 'spaghettify' objects. Terrifying yet fascinating!");
        Comment comment3 = new Comment("PhysicsFan88", "Great visuals! I wish they had covered Hawking radiation in more detail.");
        video1.AddComment(comment1);
        video1.AddComment(comment2);
        video1.AddComment(comment3);
 
        
        Video video2 = new Video("How to Cook the Perfect Steak", "ChefMaster", 8.5);
        Comment comment4 = new Comment("GrillKing23", "Tried this today—absolute perfection! The butter trick really works.");
        Comment comment5 = new Comment("FoodieLover", "Wish they had included a temperature guide for different doneness levels.");
        Comment comment6 = new Comment("BBQBoss", "Great tutorial! Now I just need to convince my family to like medium-rare.");
        video2.AddComment(comment4);
        video2.AddComment(comment5);
        video2.AddComment(comment6);
        
        Video video3 = new Video("The History of Ancient Egypt in 10 Minutes", "HistoryExplained", 10);
        Comment comment7 = new Comment("TimelessTraveler", "So much info packed in 10 minutes! Loved the pyramids section.");
        Comment comment8 = new Comment("HistoryBuff42", "They really skipped over the role of women in Egyptian society, though.");
        Comment comment9 = new Comment("MuseumGeek", "I appreciate the effort, but they could have talked about daily life more.");
        video3.AddComment(comment7);
        video3.AddComment(comment8);
        video3.AddComment(comment9);
        
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            video.DisplayAllInfo();
        }
    }
}