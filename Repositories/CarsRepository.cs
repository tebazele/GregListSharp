namespace gregSharp.Repositories;
public class CarsRepository
{
  // NOTE repo layer needs access to the MySQL database through IDbConnection
  private readonly IDbConnection _db;

  public CarsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal List<Car> Get()
  {
    string sql = @"
    SELECT
    *
    FROM cars;
    ";
    List<Car> cars = _db.Query<Car>(sql).ToList();
    return cars;
  }

  internal Car Create(Car carData)
  {
    string sql = @"
    INSERT INTO cars
    (make, model, year, price, imgUrl, description, color)
    VALUES
    (@make, @model, @year, @price, @imgUrl, @description, @color);

    SELECT LAST_INSERT_ID();
    ";
    int id = _db.ExecuteScalar<int>(sql, carData);
    carData.Id = id;
    return carData;
  }

  internal Car Get(int id)
  {
    string sql = @"
    SELECT
    *
    FROM cars
    WHERE id = @id;
    ";
    Car car = _db.Query<Car>(sql, new { id }).FirstOrDefault();
    return car;
  }

  internal bool Remove(int id)
  {
    string sql = @"
    DELETE FROM cars
    WHERE id = @id;
    ";
    int rows = _db.Execute(sql, new { id });
    // NOTE returns to the service a bool if it deleted anything from the table or not
    return rows > 0;
  }

  internal bool Update(Car original)
  {
    string sql = @"
    UPDATE cars
        SET
        make = @make,
        model = @model,
        year = @year,
        price = @price,
        imgUrl = @imgUrl,
        description = @description,
        color = @color
    WHERE id = @id;
    ";
    int rows = _db.Execute(sql, original);
    return rows > 0;
  }
}