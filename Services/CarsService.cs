namespace gregSharp.Services;
public class CarsService
{

  private readonly CarsRepository _repo;

  public CarsService(CarsRepository repo)
  {
    _repo = repo;
  }

  internal Car Create(Car carData)
  {
    Car car = _repo.Create(carData);
    return car;
  }

  internal List<Car> Get()
  {
    List<Car> cars = _repo.Get();
    return cars;
  }

  internal Car Get(int id)
  {
    Car car = _repo.Get(id);
    if (car == null)
    {
      throw new Exception("no car by that id");
    }
    return car;
  }

  internal string Remove(int id)
  {
    Car car = Get(id);
    bool deleted = _repo.Remove(id);
    // NOTE this if is redundant, since what verified there was a car at that id on the line above, but still cool.
    if (deleted == false)
    {
      throw new Exception("no car was deleted");
    }
    // another if
    return $"{car.Make} {car.Model} was removed.";

  }

  internal Car Update(Car carUpdate, int id)
  {
    // NOTE null coalescence
    Car original = Get(id);
    original.Make = carUpdate.Make ?? original.Make;
    original.Model = carUpdate.Model ?? original.Model;
    // NOTE don't forget make your numbers nullable in your model
    original.Year = carUpdate.Year ?? original.Year;
    original.Price = carUpdate.Price ?? original.Price;
    original.Description = carUpdate.Description ?? original.Description;
    original.ImgUrl = carUpdate.ImgUrl ?? original.ImgUrl;
    original.Color = carUpdate.Color ?? original.Color;

    bool edited = _repo.Update(original);
    if (edited == false)
    {
      throw new Exception("Car was not edited");
    }
    return original;
  }
}