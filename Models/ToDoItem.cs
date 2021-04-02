namespace CheckpointWebAPI.Models
{
    public class ToDoItem
    {
        public long Id { get; set; }
        public string Owner { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public float Price { get; set; }
        public string User { get; set; }
        public string Img { get; set; }
        public string SecretNotes { get; set; }
    }
}