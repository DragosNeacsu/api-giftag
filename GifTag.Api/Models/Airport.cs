using System.Collections.Generic;

public class AirportDto
{
    public string PlaceId { get; set; }
    public string PlaceName { get; set; }
    public string LocalizedPlaceName { get; set; }
    public string CountryId { get; set; }
    public string CityId { get; set; }
    public string CountryName { get; set; }
    public string PlaceNameEn { get; set; }
    public string RegionId { get; set; }
    public string CityName { get; set; }
    public string CityNameEn { get; set; }
    public string GeoId { get; set; }
    public string GeoContainerId { get; set; }
    public string Location { get; set; }
    public string ResultingPhrase { get; set; }
    public List<List<int>> Highlighting { get; set; }
}
