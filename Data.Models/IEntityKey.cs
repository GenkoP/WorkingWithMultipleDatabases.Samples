namespace Data.Models
{
    public interface IEntityKey<TKey>
    {
        TKey Id { get; set; }
    }
}
