namespace ClienteCRUD.Domain.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        public bool Active { get; set; } = true;
    }
}
