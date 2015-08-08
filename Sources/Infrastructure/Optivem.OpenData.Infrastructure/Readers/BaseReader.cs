using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Infrastructure.Readers
{
    /// <summary>
    /// Base implementation of a typed-object reader
    /// </summary>
    /// <typeparam name="T">Type of the object being read</typeparam>
    /// <typeparam name="U">Type of the inner reader used</typeparam>
    public abstract class BaseReader<T, U> : IReader<T> where U : IDisposable
    {
        protected BaseReader(U reader, bool disposeReader = false)
        {
            this.Reader = reader;
            this.DisposeReader = disposeReader;
        }

        public U Reader { get; private set; }

        protected bool DisposeReader { get; private set; }

        public abstract T Read();

        public abstract List<T> ReadToEnd();

        public void Dispose()
        {
            PreDispose();

            if (DisposeReader)
            {
                Reader.Dispose();
            }
        }

        protected virtual void PreDispose()
        {
            // Implemented only by subclasses, if need to execute custom disposal actions
        }
    }
}
