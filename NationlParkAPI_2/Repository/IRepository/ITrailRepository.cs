using NationlParkAPI_2.Models;

namespace NationlParkAPI_2.Repository.IRepository
{
    public interface ITrailRepository
    {

        ICollection<Trail> GetTrails();
        Trail GetTrail(int trailId);

        bool TrailExist(int trailId);
        bool TrailExist(string trailName);
        bool CreateTrail(Trail trail);
        bool UpdateTrail(Trail trail);
        bool DeleteTrail(Trail trail);
        bool Save();
        ICollection<Trail> GetTrailsInNationalPark(int nationalParkId);
    }
}
