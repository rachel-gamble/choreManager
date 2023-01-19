namespace choreManager.Repositories;

public class ChoresRepository
{

    private readonly IDbConnection _db;

    public ChoresRepository(IDbConnection db)
    {
        _db = db;
    }


    internal Chore Create(Chore choreData)
    {
        string sql = @"
        INSERT INTO chores
        (task, coverImg, minutes, completed, creatorId)
        VALUES (@task, @coverImg, @minutes, @completed, @creatorId);
        ";
        int id = _db.ExecuteScalar<int>(sql, choreData);
        choreData.Id = id;
        return choreData;
    }
    internal List<Chore> Get()
    {
        string sql = @"
        SELECT
        ch.*,
        ac.*
        FROM chores ch
        JOIN accounts ac ON ac.id = ch.creatorId;
        ";
        List<Chore> chores = _db.Query<Chore, Account, Chore>(sql, (chore, account) =>
        {
            chore.Creator = account;
            return chore;
        }).ToList();
        return chores;
    }

    internal Chore GetOne(int id)
    {
        string sql = @"
        SELECT
        ch.*,
        ac.*
        FROM chores ch
        JOIN accounts ac ON ac.id = ch.creatorId
        WHERE ch.id = @id;
        ";
        return _db.Query<Chore, Account, Chore>(sql, (chore, account) =>
        {
            chore.Creator = account;
            return chore;
        }, new { id }).FirstOrDefault();
    }
}
