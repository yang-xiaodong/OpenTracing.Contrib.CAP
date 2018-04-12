using System;
using System.Collections;
using System.Collections.Generic;
using DotNetCore.CAP.Diagnostics;
using OpenTracing.Propagation;

namespace OpenTracing.Contrib.CAP
{
    internal sealed class BrokerHeadersInjectAdapter : ITextMap
    {
        private readonly TracingHeaders _headers;

        public BrokerHeadersInjectAdapter(TracingHeaders headers)
        {
            _headers = headers ?? throw new ArgumentNullException(nameof(headers));
        }

        public void Set(string key, string value)
        {
            if (_headers.Contains(key))
            {
                _headers.Remove(key);
            }

            _headers.Add(key, value);
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            throw new NotSupportedException("This class should only be used with ITracer.Inject");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
