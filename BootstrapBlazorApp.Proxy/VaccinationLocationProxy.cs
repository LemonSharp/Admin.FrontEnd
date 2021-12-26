using BootstrapBlazorApp.POCO;
using BootstrapBlazorApp.POCO.VaccinationLocation;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System.Net.Http.Json;

namespace BootstrapBlazorApp.Proxy;

public interface IVaccinationLocationProxy
{
     Task<List<VaccinationLocationResponse>> GetList(VaccinationLocationRequest request);
     Task<BusinessResult> AddNewSite(AddSiteRequestDTO request);
}

public class VaccinationLocationProxy : IVaccinationLocationProxy
{
    public async Task<List<VaccinationLocationResponse>> GetList(VaccinationLocationRequest request)
    {
        var client = new RestClient(Constants.SiteRootUrl);
        var requestPrepare = new RestRequest("/api/Site/List", Method.GET);
        requestPrepare.AddParameter("content-type", "application/json");
        var result = client.Execute<List<VaccinationLocationResponse>>(requestPrepare).Data;

        return result;
    }

    public async Task<BusinessResult> AddNewSite(AddSiteRequestDTO request)
    {
        var client = new RestClient(Constants.SiteRootUrl);
        var requestPrepare = new RestRequest("api/Site/AddNewSite", Method.POST);
        requestPrepare.RequestFormat = DataFormat.Json;
        requestPrepare.AddJsonBody(request);
        return await client.PostAsync<BusinessResult>(requestPrepare);
    }
}
