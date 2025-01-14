using BBB.NET.CORE.BaseClasses;
using BBB.NET.CORE.BigBlueButtonAPIClients;
using BBB.NET.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BBB.NET.CORE.Helpers
{
    public class UrlBuilder
    {
        private readonly BigBlueButtonAPISettings settings;

        public UrlBuilder(BigBlueButtonAPISettings settings)
        {
            this.settings = settings;
        }

        private string Build(string method, string parameters, bool onlyQueryString = false)
        {
            if (parameters == null) parameters = string.Empty;

            // &amp; hatasını engellemek için burada düzeltme yapıyoruz
            parameters = parameters.Replace("&amp;", "&");

            var checksum = GetChecksum(method, parameters);

            string url;
            if (onlyQueryString)
            {
                if (string.IsNullOrEmpty(parameters))
                {
                    url = $"checksum={checksum}";
                }
                else
                {
                    url = $"{parameters}&checksum={checksum}";
                }
            }
            else
            {
                if (string.IsNullOrEmpty(parameters))
                {
                    url = $"{settings.ServerAPIUrl}{method}?checksum={checksum}";
                }
                else
                {
                    url = $"{settings.ServerAPIUrl}{method}?{parameters}&checksum={checksum}";
                }
            }

            // Son aşamada &amp;'ı & ile değiştir
            return url.Replace("&amp;", "&");
        }

        private string Build(string method, BaseRequest request, bool onlyQueryString = false)
        {
            string parameters = BuildParameters(method, request);
            return Build(method, parameters, onlyQueryString);
        }

        private string BuildMethodUrl(string method)
        {
            return settings.ServerAPIUrl + method;
        }

        private string BuildParameters(string method, BaseRequest request)
        {
            string parameters = string.Empty;
            if (request != null)
            {
                var items = new List<KeyValuePair<string, string>>();

                foreach (var p in request.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
                {
                    var value = p.GetValue(request, null);
                    if (value != null)
                    {
                        string sValue = value switch
                        {
                            bool boolValue => boolValue ? "true" : "false",
                            _ => Uri.EscapeDataString(value.ToString())  // Manuel URL encode
                        };

                        items.Add(new KeyValuePair<string, string>(p.Name, sValue));
                    }
                }

                if (items.Count > 0)
                {
                    items.Sort((x, y) => x.Key.CompareTo(y.Key));
                    parameters = string.Join("&", items.Select(i => $"{i.Key}={i.Value}"));
                }
            }

            // &amp; hatasını engellemek için burada düzeltme yapıyoruz
            parameters = parameters.Replace("&amp;", "&");

            return parameters;
        }

        private string GetChecksum(string method, string parameters)
        {
            if (parameters == null) parameters = string.Empty;

            // Checksum için method ve parametreler birleştiriliyor
            var checksumBase = $"{method}{parameters}";

            return HashHelper.Sha1Hash(checksumBase, settings.SharedSecret);
        }
    }
}
