namespace UserManagement.Domain.Entities;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    // ارتباط چند به چند با User
    public List<UserRole> UserRoles { get; set; } = new();
}
