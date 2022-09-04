using Microsoft.Net.Http.Headers;
using MKasperczyk.Learning.TopicHttpClient.Constants;
using MKasperczyk.Learning.TopicHttpClient.Extensions;
using MKasperczyk.Learning.TopicHttpClient.Models;
using System.Net.Http;

namespace MKasperczyk.Learning.TopicHttpClient;

public class GitSecondClient: IGitSecondClient
{
    private static readonly HttpClient _httpClient;

    static GitSecondClient()
    {
        _httpClient = new();
        _httpClient.SetUpClient();
    }

    public async Task<IEnumerable<RepositoryInfo>> GetAsync() => await _httpClient.GetFromJsonAsync<IEnumerable<RepositoryInfo>>(GitHubConsts.RepoUrl);
}

public interface IGitSecondClient
{
    Task<IEnumerable<RepositoryInfo>> GetAsync();
}