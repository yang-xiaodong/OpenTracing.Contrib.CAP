using System.Collections.Generic;
using zipkin4net;

namespace OpenTracing.Contrib.CAP.Tracer.Zipkin
{
    internal class OtSpanContext : ISpanContext
    {
        public Trace Trace { get; }

        public OtSpanContext(Trace trace)
        {
            Trace = trace;
        }

        public IEnumerable<KeyValuePair<string, string>> GetBaggageItems()
        {
            throw new System.NotImplementedException();
        }
    }
}
