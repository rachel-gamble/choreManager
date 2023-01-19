namespace choreManager.Models;

public class Chore
{
    public int Id { get; set; }
    public string Task { get; set; }
    public string CoverImg { get; set; } = "https://images.unsplash.com/photo-1484887603430-371459454eed?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1156&q=80";
    public int Minutes { get; set; }
    public bool Completed { get; set; }
    public bool Archived { get; set; }
    public string CreatorId { get; set; }
    public Account Creator { get; set; }
}
