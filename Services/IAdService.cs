using NeighborhoodAds.Models;

namespace NeighborhoodAds.Services
{
    public interface IAdService
    {
        IEnumerable<Ad> GetAllAds();
        Ad GetAdById(int id);
        void AddAd(Ad ad);
        void UpdateAd(int id, Ad ad);
        void DeleteAd(int id);
    }
}
