using NeighborhoodAds.Models;
using System.Text.Json;

namespace NeighborhoodAds.Services
{
    public class AdService : IAdService
    {
        private const string JsonFilePath = "./Data/ads.json";
        private readonly List<Ad> _ads;

        public AdService()
        {
            _ads = LoadAdsFromFile();
        }

        public IEnumerable<Ad> GetAllAds() => _ads;

        public Ad GetAdById(int id) => _ads?.FirstOrDefault(a => a.Id == id);

        public void AddAd(Ad ad)
        {
            ad.Id = _ads.Count > 0 ? _ads.Max(a => a.Id) + 1 : 1;
            ad.CreatedAt = DateTime.Now;
            _ads.Add(ad);
            SaveAdsToFile();
        }

        public void UpdateAd(int id, Ad updatedAd)
        {
            var ad = _ads.FirstOrDefault(a => a.Id == id);
            if (ad != null)
            {
                ad.Title = updatedAd.Title;
                ad.Description = updatedAd.Description;
                ad.Location = updatedAd.Location;
                ad.Category = updatedAd.Category;
                ad.CreatedBy = updatedAd.CreatedBy;
                ad.ImageUrl = updatedAd.ImageUrl;
                SaveAdsToFile();
            }
        }

        public void DeleteAd(int id)
        {
            var ad = _ads.FirstOrDefault(a => a.Id == id);
            if (ad != null)
            {
                _ads.Remove(ad);
                SaveAdsToFile();
            }
        }

        private static List<Ad> LoadAdsFromFile()
        {
            if (!File.Exists(JsonFilePath))
            {
                return [];
            }

            var json = File.ReadAllText(JsonFilePath);
            return JsonSerializer.Deserialize<List<Ad>>(json) ?? [];
        }

        private void SaveAdsToFile()
        {
            var json = JsonSerializer.Serialize(_ads, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(JsonFilePath, json);
        }
    }
}
