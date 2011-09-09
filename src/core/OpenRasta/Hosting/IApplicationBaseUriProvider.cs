using System;
using OpenRasta.Web;

namespace OpenRasta.Hosting
{
    public interface IApplicationBaseUriProvider
    {
        Uri GetBaseUri(UriKind uriKind);
    }

    public class ApplicationBaseUriProvider : IApplicationBaseUriProvider
    {
        readonly IRequest _request;

        public ApplicationBaseUriProvider(IRequest request)
        {
            _request = request;
        }

        public Uri GetBaseUri(UriKind uriKind)
        {
            return new Uri("{0}://{1}{2}/".With(
                            _request.Uri.Scheme,
                            _request.Uri.Host,
                            _request.Uri.IsDefaultPort ? string.Empty : ":" + _request.Uri.Port), uriKind);     
        }
    }
}