using RestSharp;
using System;

namespace SibylSytem.NET
{
    public class PsychoPass
    {
        public virtual string Host { get; protected set; }
        public virtual string Token { get; protected set; }
        public virtual RestClient HttpClient { get; protected set; }


        protected PsychoPass(string host, string token)
        {
            if (!host.EndsWith("/"))
            {
                host += "/";
            }
            Host = host;
            Token = token;
            HttpClient = new();

        }


        public virtual bool IsValid()
        {
            HttpClient.BaseUrl = new Uri(Host + "checkToken?");
            var request = new RestRequest(Method.GET);
            request.AddQueryParameter("token", Token);
            var resp = HttpClient.Execute<CheckTokenResult>(request);
            return (bool)resp.Data.Success;
        }


        public virtual BanResult AddBan(long user_id, string reason, string message, string source_url)
        {
            HttpClient.BaseUrl = new Uri(Host + "addBan?");
            var request = new RestRequest(Method.GET);
            request.AddQueryParameter("token", Token);
            request.AddQueryParameter("user-id", user_id.ToString());
            request.AddQueryParameter("reason", reason);
            request.AddQueryParameter("src", source_url);
            request.AddQueryParameter("message", message);
            return (BanResult)HttpClient.Execute<BanResult>(request);
        }

        public virtual GetInfoResult GetInfo(long user_id)
        {
            HttpClient.BaseUrl = new Uri(Host + "getInfo?");
            var request = new RestRequest(Method.GET);
            request.AddQueryParameter("token", Token);
            request.AddQueryParameter("user-id", user_id.ToString());
            return (GetInfoResult)HttpClient.Execute<GetInfoResult>(request);
        }

        public virtual UnbanResult DeleteBan(long user_id)
        {
            HttpClient.BaseUrl = new Uri(Host + "getInfo?");
            var request = new RestRequest(Method.GET);
            request.AddQueryParameter("token", Token);
            request.AddQueryParameter("user-id", user_id.ToString());
            return (UnbanResult)HttpClient.Execute<UnbanResult>(request);
        }

    }
}
