using System;

namespace Namespace
{
    public class Defer : IDisposable
    {
        readonly Action action;

        public Defer(Action action)
        {
            this.action = action;
        }

        public void Dispose()
        {
            action?.Invoke();
        }
    }
}
