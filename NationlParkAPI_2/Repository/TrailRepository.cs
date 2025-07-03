using Microsoft.EntityFrameworkCore;
using NationlParkAPI_2.Data;
using NationlParkAPI_2.Models;
using NationlParkAPI_2.Repository.IRepository;

namespace NationlParkAPI_2.Repository
{
    public class TrailRepository : ITrailRepository
    {
        private readonly ApplicationDbContext _context;
        public TrailRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CreateTrail(Trail trail)
        {
            _context.Trails.Add(trail);
            return Save();
        }

        public bool DeleteTrail(Trail trail)
        {
            _context.Trails.Remove(trail);
            return Save();
        }

        public Trail GetTrail(int trailId)
        {
            return _context.Trails.Include(t => t.NationalPark)
                .FirstOrDefault(t => t.Id == trailId);
        }

        public ICollection<Trail> GetTrails()
        {
            return _context.Trails.Include(t => t.NationalPark).ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;

        }

        public bool TrailExist(int trailId)
        {
            return _context.Trails.Any(t => t.Id == trailId);

        }

        public bool TrailExist(string trailName)
        {
            return _context.Trails.Any(t => t.Name == trailName);

        }

        public bool UpdateTrail(Trail trail)
        {
            _context.Trails.Update(trail);
            return Save();
        }

        ICollection<Trail> ITrailRepository.GetTrailsInNationalPark(int nationalParkId)
        {
            return _context.Trails.Include(t => t.NationalPark)
                .Where(t => t.NationalParkId == nationalParkId).ToList();
        }
    }
}
