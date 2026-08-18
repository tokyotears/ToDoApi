namespace Api.Models;

public class User(Guid id, string name, string hashedPassword) {
    public Guid Id { get; init; } = id;
    public string Name { get; set; } = name;
    public string HashedPassword { get; set; } = hashedPassword;
}