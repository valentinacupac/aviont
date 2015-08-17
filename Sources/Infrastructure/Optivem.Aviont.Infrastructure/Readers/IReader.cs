using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Aviont.Infrastructure.Readers
{
    /// <summary>
    /// Interface for reader
    /// </summary>
    /// <typeparam name="T">Type of the object being read</typeparam>
    public interface IReader<T> : IDisposable
    {
        T Read();
        List<T> ReadToEnd();
    }
}
