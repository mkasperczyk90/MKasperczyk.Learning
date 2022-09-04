using Microsoft.Net.Http.Headers;
using MKasperczyk.Learning.TopicHttpClient.Constants;

namespace MKasperczyk.Learning.TopicHttpClient.Extensions;
public static class GitHubClientExtensions
{
    public static void SetUpClient(this HttpClient client)
    {
        client.BaseAddress = new Uri(GitHubConsts.BaseUrl);
        client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/vnd.github.v3+json");
        client.DefaultRequestHeaders.Add(HeaderNames.UserAgent, "Other");
    }
}
