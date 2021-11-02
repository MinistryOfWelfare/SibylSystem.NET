/*
    SibylSystem.NET - .NET library for the Sibyl System antispam API for telegram

    Copyright (C) 2021 Sayan Biswas

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using RestSharp;
using System;
using SibylSystem.NET.Types;

namespace SibylSystem.NET
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
