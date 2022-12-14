using Microsoft.Net.Http.Headers;
using MKasperczyk.Learning.TopicHttpClient.Constants;
using MKasperczyk.Learning.TopicHttpClient.Models;
using System.Net.Http;

namespace MKasperczyk.Learning.TopicHttpClient;

public class GitThirdClient : IGitThirdClient
{
    private readonly HttpClient _httpClient;

    public GitThirdClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<RepositoryInfo>> GetAsync() => await _httpClient.GetFromJsonAsync<IEnumerable<RepositoryInfo>>(GitHubConsts.RepoUrl);
}

public interface IGitThirdClient
{
    Task<IEnumerable<RepositoryInfo>> GetAsync();
}