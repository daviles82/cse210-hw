
class Scripture
{
  Reference reference;
  List<Word> words;

  public Scripture(Reference _reference, string _text)
  {
    reference = _reference;
    words = new List<Word>();

    List<string> allWords = _text.Split(' ').ToList();
    foreach(string wordString in allWords)
    {
      Word newWword = new Word(wordString);
      words.Add(newWword);
    }
  }

  public void HideRandomWords()
    {
      Random random = new Random();
      foreach (Word word in words)
      {
        double randomNumber = random.NextDouble();
        if (randomNumber < 0.2)
        {
          word.Hide();
        }
    }
  }

  public string GetDisplayText()
  {
    string scriptureText = "";

    foreach (Word word in words)
    {
      if (word.GetIsHidden() == false)
      {
        scriptureText += word.GetDisplayText() + " ";
      }
      else
      {
        scriptureText += new string('_', word.GetDisplayText().Length) + " ";
      }
    }

    return ($"{reference.GetDisplayText()} {scriptureText}");
  }

  public bool IsCompletelyHidden()
  {
    return true;
  }
}