namespace OpenTracing.Contrib.CAP.Tracer.Zipkin
{
    internal enum OtSpanKind
    {
        Server,
        Client,
        Producer,
        Consumer,
        Local
    }
}
