using BootstrapBlazorApp.POCO;
using BootstrapBlazorApp.POCO.VaccinationLocation;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System.Net.Http.Json;
using Dapr.Client;

namespace BootstrapBlazorApp.Proxy;

public interface IVaccinationLocationProxy
{
     Task<List<VaccinationLocationResponse>> GetList(VaccinationLocationRequest request);
     Task<BusinessResult> AddNewSite(AddSiteRequestDTO request);
}

public class VaccinationLocationProxy : IVaccinationLocationProxy
{
    private readonly DaprClient _daprClient;

    public VaccinationLocationProxy(DaprClient daprClient)
    {
        _daprClient = daprClient;
    }

    public async Task<List<VaccinationLocationResponse>> GetList(VaccinationLocationRequest request)
    {
        var result = await _daprClient.InvokeMethodAsync<List<VaccinationLocationResponse>>
            ("vaccination-site", "/api/Site/List");
        return result;
    }

    public async Task<BusinessResult> AddNewSite(AddSiteRequestDTO request)
    {
        var result = await _daprClient.InvokeMethodAsync<AddSiteRequestDTO, BusinessResult>
            ("vaccination-site", "api/Site/AddNewSite", request);
        return result;
    }
}
