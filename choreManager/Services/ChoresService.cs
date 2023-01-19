namespace choreManager.Services;

public class ChoresService
{

    private readonly ChoresRepository _repo;
    public ChoresService(ChoresRepository repo)
    {
        _repo = repo;
    }

    internal Chore Create(Chore choreData)
    {
        Chore chore = _repo.Create(choreData);
        return chore;
    }

    internal List<Chore> Get(string userId)
    {
        List<Chore> chores = _repo.Get();
        List<Chore> filtered = chores.FindAll(c => c.Archived == false || c.CreatorId == userId);
        return filtered;
        // return chores;
    }

}
