using System;
using UniRx;

namespace Storage
{
    public abstract class BaseStorage : IDisposable
    {
        protected CompositeDisposable Disposables = new();

        public virtual void Dispose()
        {
            Disposables.Dispose();
        }
    }
}