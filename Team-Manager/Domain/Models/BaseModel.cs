namespace Team_Manager.Domain.Models;

public class BaseModel
{
    public BaseModel()
    {
        Id = Guid.NewGuid();
        CreateAt = DateTime.Now;
    }

    public Guid Id { get; set; }
    public DateTime CreateAt { get; set; }
}
