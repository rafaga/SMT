using System;

/// <summary>
/// Class Github Release (we are using System.text.json to deserialize the objects)
/// </summary>
namespace SMTx.Models
{
    internal class GithubRelease
    {
        public Uri? url { get; set; }

        public Uri? assts_url { get; set; }

        public string upload_url { get; set; }

        public Uri? html_url { get; set; }

        public long id { get; set; }

        public string node_id { get; set; }

        public string tag_name { get; set; }

        public string target_commitish { get; set; }

        public string name { get; set; }

        public bool draft { get; set; }

        public GitHubAuthor? author { get; set; }

        public bool prerelease { get; set; }

        public DateTimeOffset created_at { get; set; }

        public DateTimeOffset published_at { get; set; }

        public GitHubAsset[]? assets { get; set; }

        public Uri? tarball_url { get; set; }

        public Uri? zipball_url { get; set; }

        public string body { get; set; }

    }
    public class GitHubAsset
    {
        public Uri? url { get; set; }

        public long id { get; set; }

        public string node_id { get; set; }

        public string name { get; set; }

        public object label { get; set; }

        public GitHubAuthor uploader { get; set; }

        public string content_type { get; set; }

        public string state { get; set; }

        public long size { get; set; }

        public long download_count { get; set; }

        public DateTimeOffset created_at { get; set; }

        public DateTimeOffset updated_at { get; set; }

        public Uri? browser_download_url { get; set; }
    }

    public class GitHubAuthor
    {
        public string login { get; set; }

        public long id { get; set; }

        public string node_id { get; set; }

        public Uri? avatar_url { get; set; }

        public string gravatar_id { get; set; }

        public Uri? url { get; set; }

        public Uri? html_url { get; set; }

        public Uri? followers_url { get; set; }

        public string following_url { get; set; }

        public string gists_url { get; set; }

        public string starred_url { get; set; }

        public Uri? subscriptions_url { get; set; }

        public Uri? organizations_url { get; set; }

        public Uri? repos_url { get; set; }

        public string events_url { get; set; }

        public Uri? received_events_url { get; set; }

        public string type { get; set; }

        public bool site_admin { get; set; }
    }
}