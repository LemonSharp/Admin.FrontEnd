using BootstrapBlazorApp.POCO.VaccinationLocation;
using BootstrapBlazorApp.Proxy;
using System.Diagnostics.CodeAnalysis;

namespace BootstrapBlazorApp.Shared.Pages;

public partial class VaccinationPlace
{
    private readonly IVaccinationLocationProxy _vacc;

    public VaccinationPlace()
    {
        _vacc = new VaccinationLocationProxy();
    }

    [NotNull]
    private List<VaccinationLocationResponse>? Items { get; set; }

    /// <summary>
    /// OnInitialized 方法
    /// </summary>
    protected async override void OnInitialized()
    {
        base.OnInitialized();

        Items = await FillItems();
    }

    private async Task<List<VaccinationLocationResponse>> FillItems()
    {
        var items = new List<AddSiteRequestDTO>();
        var request = new VaccinationLocationRequest();

        return await _vacc.GetList(request);
    }
}
