using NationlParkAPI_2.Models;

namespace NationlParkAPI_2.Repository.IRepository
{
    public interface INationalParkRepository
    {

        ICollection<NationalPark> GetNationalParks();
        NationalPark GetNationalPark(int nationalParkid);
        bool NationalParkExists(int nationalParkid);
        bool NationalParkExists(string nationalParkName);
        bool CreateNationalPark(NationalPark nationalPark);
        bool UpdateNationalPark(NationalPark nationalPark);
        bool DeleteNationalPark(NationalPark nationalPark);
        bool Save();
    }
}
