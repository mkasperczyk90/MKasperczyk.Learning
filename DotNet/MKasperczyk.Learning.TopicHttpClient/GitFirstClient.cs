using Microsoft.Net.Http.Headers;
using MKasperczyk.Learning.TopicHttpClient.Constants;
using MKasperczyk.Learning.TopicHttpClient.Extensions;
using MKasperczyk.Learning.TopicHttpClient.Models;
using System.Net.Http;

namespace MKasperczyk.Learning.TopicHttpClient;

public class GitFirstClient: IGitFirstClient
{
    public async Task<IEnumerable<RepositoryInfo>> GetAsync()
    {
        using var httpClient = new HttpClient();
        httpClient.SetUpClient();

        return await httpClient.GetFromJsonAsync<IEnumerable<RepositoryInfo>>(GitHubConsts.RepoUrl);
    }
}

public interface IGitFirstClient
{
    Task<IEnumerable<RepositoryInfo>> GetAsync();
}