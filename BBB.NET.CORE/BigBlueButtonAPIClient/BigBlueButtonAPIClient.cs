using BBB.NET.CORE.BaseClasses;
using BBB.NET.CORE.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.BigBlueButtonAPIClient
{
    public class BigBlueButtonAPIClient
    {
        #region Common
        private readonly HttpClient httpClient;
        private readonly UrlBuilder urlBuilder;


        public BigBlueButtonAPIClient(BigBlueButtonAPISettings settings, HttpClient httpClient)
        {
            this.urlBuilder = new UrlBuilder(settings);
            this.httpClient = httpClient;
        }

        private async Task<T> HttpGetAsync<T>(string method, BaseRequest request)
        {
            var url = urlBuilder.Build(method, request);
            var result = await HttpGetAsync<T>(url);
            return result;
        }


        private async Task<T> HttpGetAsync<T>(string url)
        {
            // HTTP isteği gönder
            var response = await httpClient.GetAsync(url);

            // Yanıtı metin olarak oku
            var xmlOrJson = await response.Content.ReadAsStringAsync();

            // Yanıtı logla
            Console.WriteLine("Response XML/JSON: " + xmlOrJson);

            // Eğer tip string ise yanıtı direkt döndür
            if (typeof(T) == typeof(string)) return (T)(object)xmlOrJson;

            // Eğer XML ise deserialize et
            if (xmlOrJson.StartsWith("<"))
            {
                return XmlHelper.FromXml<T>(xmlOrJson);
            }
            else
            {
                // JSON formatı varsa işle
                var wrapper = JsonConvert.DeserializeObject<ResponseJsonWrapper<T>>(xmlOrJson);
                return wrapper.response;
            }
        }


        private async Task<T> HttpPostAsync<T>(string method, BaseRequest request)
        {
            var formData = urlBuilder.Build(method, request, true);
            var formDataBytes = System.Text.Encoding.UTF8.GetBytes(formData);

            var cts = new CancellationTokenSource();
            using (var content = new ByteArrayContent(formDataBytes))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                var response = await httpClient.PostAsync(urlBuilder.BuildMethodUrl(method), content, cts.Token);
                var xmlOrJson = await response.Content.ReadAsStringAsync();
                if (typeof(T) == typeof(string)) return (T)(object)xmlOrJson;

                // Most APIs return XML string.
                // The getRecordingTextTracks API may return JSON string.
                if (xmlOrJson.StartsWith("<"))
                {
                    return XmlHelper.FromXml<T>(xmlOrJson);
                }
                else
                {
                    var wrapper = JsonConvert.DeserializeObject<ResponseJsonWrapper<T>>(xmlOrJson);
                    return wrapper.response;
                }

            }

        }


        private async Task<T> HttpPostFileAsync<T>(string method, BasePostFileRequest request)
        {
            var url = urlBuilder.Build(method, request);
            var cts = new CancellationTokenSource();
            using (var content = new MultipartFormDataContent())
            {
                content.Add(new ByteArrayContent(request.file.FileData), request.file.Name, request.file.FileName);

                var response = await httpClient.PostAsync(url, content, cts.Token);
                var xmlOrJson = await response.Content.ReadAsStringAsync();
                if (typeof(T) == typeof(string)) return (T)(object)xmlOrJson;

                // Most APIs return XML string.
                // The getRecordingTextTracks API may return JSON string.
                if (xmlOrJson.StartsWith("<"))
                {
                    return XmlHelper.FromXml<T>(xmlOrJson);
                }
                else
                {
                    var wrapper = JsonConvert.DeserializeObject<ResponseJsonWrapper<T>>(xmlOrJson);
                    return wrapper.response;
                }

            }

        }
        #endregion







        #region Meeting Management
        public async Task<string> CreateMeetingAsync(CreateMeetingRequest request)
        {
            return await HttpGetAsync<string>("create", request);
        }

        public async Task<string> EndMeetingAsync(EndMeetingRequest request)
        {
            return await HttpGetAsync<string>("end", request);
        }

        public async Task<GetMeetingInfoResponse> GetMeetingInfoAsync(GetMeetingInfoRequest request)
        {
            return await HttpGetAsync<GetMeetingInfoResponse>("getMeetingInfo", request);
        }

        public async Task<IsMeetingRunningResponse> IsMeetingRunningAsync(IsMeetingRunningRequest request)
        {
            return await HttpGetAsync<IsMeetingRunningResponse>("isMeetingRunning", request);
        }

        public async Task<string> JoinMeetingAsync(JoinMeetingRequest request)
        {
            return await HttpGetAsync<string>("join", request);
        }

        public async Task<GetMeetingsResponse> GetMeetingsAsync()
        {
            return await HttpGetAsync<GetMeetingsResponse>("getMeetings");
        }
        #endregion







    }
}
