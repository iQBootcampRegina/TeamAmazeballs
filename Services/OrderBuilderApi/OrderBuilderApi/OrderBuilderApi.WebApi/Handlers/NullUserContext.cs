using System;

namespace OrderBuilderApi.WebApi.Handlers
{
    public class NullUserContext : IDisposable
    {
        public void Dispose() { }
    }
}