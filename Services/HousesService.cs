
namespace gregSharp.Services;

public class HousesService
{
    private readonly HousesRepository _repo;

    public HousesService(HousesRepository repo)
    {
        _repo = repo;
    }

    internal List<House> Get()
    {
        List<House> houses = _repo.Get();
        return houses;
    }

    internal House Create(House houseData)
    {
        House house = _repo.Create(houseData);
        return house;
    }

    internal House Get(int id)
    {
        House house = _repo.Get(id);
        return house;

    }

    internal string Remove(int id)
    {
        House foundHouse = Get(id);
        bool deleted = _repo.Remove(id);
        if (deleted == false)
        {
            throw new Exception("no house was deleted");
        }
        return $"The house at {foundHouse.address} was deleted";
    }

    internal House Update(House houseUpdate, int id)
    {
        House original = Get(id);
        original.address = houseUpdate.address ?? original.address;
        original.bathrooms = houseUpdate.bathrooms ?? original.bathrooms;
        original.bedrooms = houseUpdate.bedrooms ?? original.bedrooms;
        original.description = houseUpdate.description ?? original.description;
        original.squareft = houseUpdate.squareft ?? original.squareft;
        original.imgUrl = houseUpdate.imgUrl ?? original.imgUrl;
        original.price = houseUpdate.price ?? original.price;

        bool edited = _repo.Update(original);
        if (edited == false)
        {
            throw new Exception("House was not actually  edited");
        }
        return original;
    }
}
