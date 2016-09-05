using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using WMTPresentation.Common;
using WMTPresentation.Entities;
using WMTPresentation.Services.Intarfaces;

namespace WMTPresentation.Services
{
    public class HttpService : IHttpService
    {
        private static string authUri;
        private static string presentationsUri;

        public static CancellationToken ct;

        public object HttpUtility { get; private set; }

        public HttpService()
        {
            authUri = "https://dev.prezentor.com/auth/local";
            presentationsUri = "https://apidev.prezentor.com";
        }

        public async Task<string> GetToken(string email, string password)
        {
            ct = new CancellationToken();

            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("email", email),
                new KeyValuePair<string, string>("password", password)
            });

            try
            {
                var client = new HttpClient();

                HttpResponseMessage response = await client.PostAsync(new Uri(authUri), formContent, ct);
                var task = response.Content.ReadAsStringAsync();
                var content = await task;

                AuthorizationToken t = JsonConvert.DeserializeObject<AuthorizationToken>(content);

                string token = t.Token;
                string message = t.Message;

                if (!string.IsNullOrEmpty(token))
                {
                    return token;
                }
                else
                {
                    return "Error: " + message;
                }
            }

            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        async public Task<Presentation> GetPresentationById(string id, string token)
        {
            if (!String.IsNullOrEmpty(token))
            {
                string presentationTotalJson = await GetPresentationByIdRequest(id, token);

                return DeserializePresentationJson(presentationTotalJson);
            }
            else
            {
                return null;
            }
        }

        async public Task<List<Presentation>> GetPresentations(string token)
        {
            if (!String.IsNullOrEmpty(token))
            {
                string presentationsListJson = await GetPresentationsRequest(token);

                return DeserializePresentationsListJson(presentationsListJson);
                //return new List<Presentation>();
            }
            else
            {
                return null;
            }
        }

        private List<Presentation> DeserializePresentationsListJson(string presentationsListJson)
        {
            List<Presentation> pList;
            try
            {
                pList = JsonConvert.DeserializeObject<List<Presentation>>(presentationsListJson);
            }
            catch (Exception)
            {
                throw;
            }

            foreach (var p in pList)
            {
                p.Chapters = new List<Chapter>();

                //JObject pJsonObject = JObject.Parse(p.ToString());
                //p.PresentationJson = RemoveIdenticalFields(p, p.ToString());
            }

            return pList;
        }

        async private Task<string> GetPresentationsRequest(string token)
        {
            ct = new CancellationToken();

            try
            {
                var client = new HttpClient();

                client.BaseAddress = new Uri(presentationsUri);

                HttpResponseMessage response = await client.GetAsync(String.Format("api/presentations/?access_token={0}", token), ct);

                if (response.IsSuccessStatusCode)
                {
                    var task = response.Content.ReadAsStringAsync();
                    var content = await task;
                    return content;
                }

                return "Error";
            }
            catch (Exception ex)
            {
                return "Error" + ex.Message;
            }
        }

        async private Task<string> GetPresentationByIdRequest(string presentationId, string token)
        {
            ct = new CancellationToken();

            try
            {
                var client = new HttpClient();

                client.BaseAddress = new Uri(presentationsUri);

                HttpResponseMessage response = await client.GetAsync(String.Format("api/presentations/{0}/?access_token={1}", presentationId, token), ct);

                if (response.IsSuccessStatusCode)
                {
                    var task = response.Content.ReadAsStringAsync();
                    var content = await task;
                    return content;
                }

                return "Error";
            }
            catch (Exception ex)
            {
                return "Error" + ex.Message;
            }
        }

        private Presentation DeserializePresentationJson(string presentationTotalJson)
        {
            Presentation p = JsonConvert.DeserializeObject<Presentation>(presentationTotalJson);

            p.Chapters = new List<Chapter>();

            JObject presentationTotalJsonObject = JObject.Parse(presentationTotalJson);

            p.PresentationJson = RemoveIdenticalFields(p, presentationTotalJson);

            IList<JToken> chaptersJsonObject = presentationTotalJsonObject["chapters"].Children().ToList();

            foreach (var c in chaptersJsonObject)
            {
                var chapterJsonStr = c.ToString();
                Chapter deserializedChapter = JsonConvert.DeserializeObject<Chapter>(chapterJsonStr);
                deserializedChapter.ChapterJson = RemoveIdenticalFields(deserializedChapter, chapterJsonStr);
                deserializedChapter.Slides = new List<Slide>();

                JObject chapterJsonObject = JObject.Parse(chapterJsonStr);
                IList<JToken> slidesJsonObject = chapterJsonObject["slides"].Children().ToList();

                foreach (var s in slidesJsonObject)
                {
                    var slideJsonStr = s.ToString();
                    Slide deserializedSlide = JsonConvert.DeserializeObject<Slide>(slideJsonStr);
                    deserializedSlide.SlideJson = RemoveIdenticalFields(deserializedSlide, slideJsonStr);

                    deserializedChapter.Slides.Add(deserializedSlide);
                }

                p.Chapters.Add(deserializedChapter);
            }

            return p;
        }

        private string RemoveIdenticalFields<T>(T instance, string jsonStr)
        {
            // instance properties names are obtained
            Type t = instance.GetType();
            PropertyInfo[] properties = t.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

            List<string> propertiesNames = new List<string>();

            foreach (var p in properties)
            {
                if (!string.Equals(p.Name, "id", StringComparison.OrdinalIgnoreCase))
                {
                    propertiesNames.Add(p.Name);
                }
            }

            // JSON properties which list 'propertiesNames' contains are removed from file
            JObject jsonObj = JObject.Parse(jsonStr);
            JContainer container = jsonObj as JContainer;
            List<JToken> removeList = new List<JToken>();

            if (container == null) return "";

            foreach (JToken el in container)
            {
                JProperty p = el as JProperty;
                if (p != null && propertiesNames.Any(s => s.Equals(p.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    removeList.Add(el);
                }
            }

            foreach (JToken el in removeList)
            {
                el.Remove();
            }

            return container.ToString();
        }
    }
}
