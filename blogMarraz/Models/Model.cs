using System;
namespace blogMarraz.Models
{
    public class Model
    {
        public int ID { get; set; }
        public DateTime Created {  get; set; } = DateTime.UtcNow;

        public DateTime Updated { get; set; } = DateTime.UtcNow;

        public bool Deleted { get; set; } = false;
    }
}
