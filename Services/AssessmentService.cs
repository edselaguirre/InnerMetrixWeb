using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using InnerMetrixWeb.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;


namespace InnerMetrixWeb.Services
{
    public class AssessmentService
    {
        public string Url { get; set; }

        public AssessmentService(string url)
        {
            Url = url;
        }

        public AssessmentResponse IntializeAssessment()
        {
            var client = new RestClient(Url);
            var request = new RestRequest(Method.GET);
            IRestResponse<Code> response = client.Execute<Code>(request);
            int responsecode = (int)response.StatusCode;
            return new AssessmentResponse()
            {
                ResponseCode = responsecode,
                Message = response.Content.ToString()
            };
        }

        public void SaveRawScores(string token)
        {
            var client = new RestClient(Url + string.Format("remote/AI/{0}/rawscores/", token));
            var request = new RestRequest(Method.GET);
            IRestResponse<RawScores> response = client.Execute<RawScores>(request);
            RawScores values = JsonConvert.DeserializeObject<RawScores>(response.Content);
            JToken outer = JToken.Parse(response.Content);
            JObject inner = outer["results"].Value<JObject>();
            JObject value = inner["attributes"].Value<JObject>();
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            foreach (var item in value)
            {
                var key = item.Key;
                var val = item.Value.ToString();
                list.Add(new KeyValuePair<string, string>(key, val));
            }
            values.results.attributes.AttributeScores = list;

            var tokenService = new TokenService();
            var tokenData = tokenService.GetTokenByTokenCode(token);

            RawScoresResponseService rawScoresResponseService = new RawScoresResponseService();
            rawScoresResponseService.SaveRawScores(values, values.results.attributes, token, inner);
            rawScoresResponseService.SaveURL(Url + string.Format("report/AI/{0}/{1}/",token, tokenData.Lang), token);
        }
    }

    public class Code
    {
        public int code { get; set; }
    }
}