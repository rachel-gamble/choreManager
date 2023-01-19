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

    internal Chore GetOne(int id, string userId)
    {
        Chore chore = _repo.GetOne(id);
        if (chore == null)
        {
            throw new Exception("no chore at that id");
        }
        if (chore.Archived == true && chore.CreatorId != userId)
        {
            throw new Exception("you don't own that");
        }
        return chore;
    }

}
