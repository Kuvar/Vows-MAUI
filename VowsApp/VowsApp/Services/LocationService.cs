namespace VowsApp.Services
{
    public class LocationService
    {
        public static async Task<Location> GetCachedLocation()
        {
            Location location = new Location();
            try
            {
                location = await Geolocation.Default.GetLastKnownLocationAsync();
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
            return location;
        }

        public static async Task<IEnumerable<Placemark>> GetAddressesForPosition(double latitude, double longitude)
        {
            IEnumerable<Placemark> placemarks = new List<Placemark>();
            try
            {
                placemarks = await Geocoding.GetPlacemarksAsync(latitude, longitude);
            }
            catch (Exception ex)
            {

            }
            return placemarks;
        }

        public static async Task<IEnumerable<Placemark>> GetAddressesForPosition(Location location)
        {
            IEnumerable<Placemark> placemarks = new List<Placemark>();
            try
            {
                placemarks = await Geocoding.GetPlacemarksAsync(location);
            }
            catch (Exception ex)
            {

            }
            return placemarks;
        }
    
        public static async Task<IEnumerable<Placemark>> GetAddresses()
        {
            IEnumerable<Placemark> placemark = new List<Placemark>();
            try
            {
                var location = await Geolocation.Default.GetLastKnownLocationAsync();
                placemark = await Geocoding.GetPlacemarksAsync(location);
            }
            catch (Exception ex)
            {
                throw;
            }
            return placemark;
        }

        public static async Task<IEnumerable<Placemark>> GetLocations(string address) 
        {
            IEnumerable<Placemark> placemarks = new List<Placemark>();
            try
            {
                var locations = await Geocoding.GetLocationsAsync(address);

                var location = locations?.FirstOrDefault();
                if(location != null) 
                {
                     placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return placemarks;
        }
    }
}
