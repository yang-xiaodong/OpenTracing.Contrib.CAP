using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace OpenTracing.Contrib.CAP.Tracer.Zipkin
{
    public class SetOtIgnoreHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Properties["ot-ignore"] = true;

            return base.SendAsync(request, cancellationToken);
        }
    }
}
