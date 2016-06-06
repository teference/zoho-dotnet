namespace Teference.Zoho.Api
{
    using System;

    internal class ProcessEntity<T>
    {
        public Exception Error { get; set; }
        public T Data { get; set; }
    }
}