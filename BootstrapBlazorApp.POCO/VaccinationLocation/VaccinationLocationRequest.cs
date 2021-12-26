namespace BootstrapBlazorApp.POCO.VaccinationLocation;

public class VaccinationLocationRequest
{
    public string Keyword { get; set; } = string.Empty;
    public double? AddressLatitude { get; set; }
    public double? AddressLongitude { get; set; }
}
