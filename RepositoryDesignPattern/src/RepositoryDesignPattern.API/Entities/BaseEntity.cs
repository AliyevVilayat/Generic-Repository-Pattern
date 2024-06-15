using RepositoryDesignPattern.API.Enums;

namespace RepositoryDesignPattern.API.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public DateTime DeletedDate { get; set; }
    public Status Status { get; set; }

}
