using System;

/* **************************************************
 *  Class Github Release (we are using System.text.json
 *  to deserialize the objects)
 * **************************************************
 * */
namespace SMTn
{
    internal class GithubRelease
    {
        public Uri url { get; set; }

        public Uri assts_url { get; set; }

        public string upload_url { get; set; }

        public Uri html_url { get; set; }

        public long id { get; set; }

        public string node_id { get; set; }

        public string tag_name { get; set; }

        public string target_commitish { get; set; }

        public string name { get; set; }

        public bool draft { get; set; }

        public GitHubAuthor author { get; set; }

        public bool prerelease { get; set; }

        public DateTimeOffset created_at { get; set; }

        public DateTimeOffset published_at { get; set; }

        public GitHubAsset[] assets { get; set; }

        public Uri tarball_url { get; set; }

        public Uri zipball_url { get; set; }

        public string body { get; set; }

    }
    public class GitHubAsset
    {
        public Uri url { get; set; }

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

        public Uri browser_download_url { get; set; }
    }

    public class GitHubAuthor
    {
        public string login { get; set; }

        public long id { get; set; }

        public string node_id { get; set; }

        public Uri avatar_url { get; set; }

        public string gravatar_id { get; set; }

        public Uri url { get; set; }

        public Uri html_url { get; set; }

        public Uri followers_url { get; set; }

        public string following_url { get; set; }

        public string gists_url { get; set; }

        public string starred_url { get; set; }

        public Uri subscriptions_url { get; set; }

        public Uri organizations_url { get; set; }

        public Uri repos_url { get; set; }

        public string events_url { get; set; }

        public Uri received_events_url { get; set; }

        public string type { get; set; }

        public bool site_admin { get; set; }
    }
}

/*namespace GitHubRelease
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Release
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("assets_url")]
        public Uri AssetsUrl { get; set; }

        [JsonProperty("upload_url")]
        public string UploadUrl { get; set; }

        [JsonProperty("html_url")]
        public Uri HtmlUrl { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("node_id")]
        public string NodeId { get; set; }

        [JsonProperty("tag_name")]
        public string TagName { get; set; }

        [JsonProperty("target_commitish")]
        public string TargetCommitish { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("draft")]
        public bool Draft { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("prerelease")]
        public bool Prerelease { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("published_at")]
        public DateTimeOffset PublishedAt { get; set; }

        [JsonProperty("assets")]
        public Asset[] Assets { get; set; }

        [JsonProperty("tarball_url")]
        public Uri TarballUrl { get; set; }

        [JsonProperty("zipball_url")]
        public Uri ZipballUrl { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }

    public partial class Asset
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("node_id")]
        public string NodeId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("label")]
        public object Label { get; set; }

        [JsonProperty("uploader")]
        public Author Uploader { get; set; }

        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("download_count")]
        public long DownloadCount { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("browser_download_url")]
        public Uri BrowserDownloadUrl { get; set; }
    }

    public partial class Author
    {
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("node_id")]
        public string NodeId { get; set; }

        [JsonProperty("avatar_url")]
        public Uri AvatarUrl { get; set; }

        [JsonProperty("gravatar_id")]
        public string GravatarId { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("html_url")]
        public Uri HtmlUrl { get; set; }

        [JsonProperty("followers_url")]
        public Uri FollowersUrl { get; set; }

        [JsonProperty("following_url")]
        public string FollowingUrl { get; set; }

        [JsonProperty("gists_url")]
        public string GistsUrl { get; set; }

        [JsonProperty("starred_url")]
        public string StarredUrl { get; set; }

        [JsonProperty("subscriptions_url")]
        public Uri SubscriptionsUrl { get; set; }

        [JsonProperty("organizations_url")]
        public Uri OrganizationsUrl { get; set; }

        [JsonProperty("repos_url")]
        public Uri ReposUrl { get; set; }

        [JsonProperty("events_url")]
        public string EventsUrl { get; set; }

        [JsonProperty("received_events_url")]
        public Uri ReceivedEventsUrl { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("site_admin")]
        public bool SiteAdmin { get; set; }
    }

    public partial class Release
    {
        public static Release FromJson(string json) => JsonConvert.DeserializeObject<Release>(json, GitHubRelease.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Release self) => JsonConvert.SerializeObject(self, GitHubRelease.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}*/