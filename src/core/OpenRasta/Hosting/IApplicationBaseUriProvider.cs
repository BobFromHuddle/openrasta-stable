using System;
using OpenRasta.Web;

namespace OpenRasta.Hosting
{
    public interface IApplicationBaseUriProvider
    {
        Uri GetBaseUri(IRequest request);
        void SetHost(string host);
        void SetScheme(string scheme);
        void SetPort(int port);
    }

    public class ApplicationBaseUriProvider : IApplicationBaseUriProvider
    {
        int? _port;
        string _host;
        string _scheme;

        public Uri GetBaseUri(IRequest request)
        {
            return new Uri("{0}://{1}{2}/".With(
                            _scheme ?? request.Uri.Scheme,
                            _host ?? request.Uri.Host,
                            GetPort(request)), UriKind.Absolute);     
        }

        string GetPort(IRequest request)
        {
            if (_port.HasValue)
                return ":"+_port;
            if (request.Uri.IsDefaultPort) 
                return string.Empty;
            return ":" + request.Uri.Port;
        }

        public void SetHost(string host)
        {
            _host = host;
        }

        public void SetScheme(string scheme)
        {
            _scheme = scheme;
        }

        public void SetPort(int port)
        {
            _port = port;
        }
    }
}