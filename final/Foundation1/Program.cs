using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        var videos = ReadVideosFromFile("videos.txt");

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}, Author: {video.Author}, Length: {video.GetLengthInSeconds()} seconds, Number of Comments: {video.GetNumberOfComments()}");
        }
    }

    public static List<VideoBase> ReadVideosFromFile(string filename)
    {
        var videos = new List<VideoBase>();

        using (var reader = new StreamReader(filename))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrEmpty(line))
                    continue;

                var videoData = ParseVideoData(line);
                if (videoData == null)
                    continue;

                var video = new VideoBase
                {
                    Title = videoData.Item1,
                    Author = videoData.Item2,
                    Length = videoData.Item3,
                    Comments = videoData.Item4
                };

                videos.Add(video);
            }
        }

        return videos;
    }

    public static Tuple<string, string, string, List<Comment>> ParseVideoData(string line)
    {
        var parts = line.Split('|');
        if (parts.Length != 4)
            return null;

        var title = parts[0].Trim().Split(',')[1].Trim();
        var author = parts[1].Trim().Split(',')[1].Trim();
        var length = parts[2].Trim().Split(',')[1].Trim();

        var commentsData = parts[3].Split(',');
        var comments = new List<Comment>();

        foreach (var commentData in commentsData)
        {
            var commentParts = commentData.Split('-');
            if (commentParts.Length == 2)
            {
                var name = commentParts[0].Trim();
                var text = commentParts[1].Trim();
                comments.Add(new Comment { Name = name, Text = text });
            }
        }

        return Tuple.Create(title, author, length, comments);
    }
}