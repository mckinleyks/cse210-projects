class Scripture
{
    private Reference Reference { get; }
    private List<Word> Words { get; }

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void DisplayScripture()
    {

        Console.WriteLine(Reference);
        Console.WriteLine(string.Join(" ", Words.Select(word => word.Display())));
    }

    public void HideRandomWords ()
    {
        Random random = new Random();
        var wordsToHide = Words.Where(word => !word.IsHidden).ToList();

        int wordsToHideCount = Math.Min(3, wordsToHide.Count);

        for (int i = 0; i < wordsToHideCount; i++)
        {
            int index = random.Next(wordsToHide.Count);
            wordsToHide[index].Hide();
            wordsToHide.RemoveAt(index);
        }
    }

    public bool IsFullyHidden()
    {
        return Words.All(word => word.IsHidden);
    }
}
