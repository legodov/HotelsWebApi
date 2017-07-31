namespace HotelsWebApi.Models
{
    public class Hotel : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Stars { get; set; }
    }
}