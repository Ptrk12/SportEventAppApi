namespace Infrastructure.Entities
{
    public class TopObjectsEntity
    {
        public int Id { get; set; }
        public int Points { get; set; }
        public int ObjectId { get; set; }
        public ObjectEntity Object { get; set; }
    }
}
