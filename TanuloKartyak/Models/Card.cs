namespace TanuloKartyak.Models
{
    public class Card
    {
        public Card(string imageFileName, string title)
        {
            ImageFileName = imageFileName;
            Title = title;
        }

        public string ImageFileName { get; set; }
        public string Title { get; set; }
    }
}