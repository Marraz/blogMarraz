namespace blogMarraz.Models
{
    public class Post : Model
    {
        internal int _id;

        public string Title { get; set; }
        public int Views {  get; set; } = 0;
        public string Content { get; set; }
        public string Excerpt { get; set; }
        public string CoverImagePath { get; set; }
        public bool Public { get; set; }
    }
}
