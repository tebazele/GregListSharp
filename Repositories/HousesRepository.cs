namespace gregSharp.Repositories;

public class HousesRepository
{
    private readonly IDbConnection _db;

    public HousesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal List<House> Get()
    {
        string sql = @"
        SELECT 
        *
        FROM houses;
        ";
        List<House> houses = _db.Query<House>(sql).ToList();
        return houses;
    }

    internal House Create(House houseData)
    {
        string sql = @"
        INSERT INTO houses
        (squareft, bedrooms, bathrooms, description, imgUrl, address, price)
        VALUES
        (@squareft, @bedrooms, @bathrooms, @description, @imgUrl, @address, @price);

        SELECT LAST_INSERT_ID();
        ";
        int id = _db.ExecuteScalar<int>(sql, houseData);
        houseData.Id = id;
        return houseData;
    }

    internal House Get(int id)
    {
        string sql = @"
        SELECT 
        * 
        FROM houses
        WHERE id = @id;
        ";
        House house = _db.Query<House>(sql, new { id }).FirstOrDefault();
        return house;
    }

    internal bool Remove(int id)
    {
        string sql = @"
        DELETE FROM houses
        WHERE id = @id;
        ";
        int rows = _db.Execute(sql, new { id });
        return rows > 0;
    }

    internal bool Update(House original)
    {
        string sql = @"
        UPDATE houses
            SET
                squareft = @squareft,
                bedrooms = @bedrooms,
                bathrooms = @bathrooms,
                description = @description,
                imgUrl = @imgUrl,
                address = @address,
                price = @price
            WHERE id = @id;
        ";
        int rows = _db.Execute(sql, original);
        return rows > 0;
    }
}
