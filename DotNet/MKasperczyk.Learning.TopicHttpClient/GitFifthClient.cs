using Microsoft.Net.Http.Headers;
using MKasperczyk.Learning.TopicHttpClient.Constants;
using MKasperczyk.Learning.TopicHttpClient.Models;
using System.Net.Http;

namespace MKasperczyk.Learning.TopicHttpClient;

public class GitFifthClient : IGitFifthClient
{
    private readonly IHttpClientFactory _httpClientFactory;

    public GitFifthClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<RepositoryInfo>> GetAsync() => await _httpClientFactory
        .CreateClient("githubapiwithPolly")
        .GetFromJsonAsync<IEnumerable<RepositoryInfo>>(GitHubConsts.RepoUrl);
}

public interface IGitFifthClient
{
    Task<IEnumerable<RepositoryInfo>> GetAsync();
}