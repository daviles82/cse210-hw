using System;
using System.Collections.Generic;
using System.IO;

public class VideoBase
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Length { get; set; }
    public List<Comment> Comments { get; set; }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    public int GetLengthInSeconds()
    {
        if (!Length.Contains(":"))
            return 0;

        var parts = Length.Split(':');
        int minutes = int.Parse(parts[0]);
        int seconds = int.Parse(parts[1]);
        return minutes * 60 + seconds;
    }
}