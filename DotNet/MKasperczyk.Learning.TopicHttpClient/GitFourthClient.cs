using Microsoft.Net.Http.Headers;
using MKasperczyk.Learning.TopicHttpClient.Constants;
using MKasperczyk.Learning.TopicHttpClient.Models;
using System.Net.Http;

namespace MKasperczyk.Learning.TopicHttpClient;

public class GitFourthClient : IGitFourthClient
{
    private readonly IHttpClientFactory _httpClientFactory;

    public GitFourthClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<RepositoryInfo>> GetAsync() => await _httpClientFactory
        .CreateClient("githubapi")
        .GetFromJsonAsync<IEnumerable<RepositoryInfo>>(GitHubConsts.RepoUrl);
}

public interface IGitFourthClient
{
    Task<IEnumerable<RepositoryInfo>> GetAsync();
}