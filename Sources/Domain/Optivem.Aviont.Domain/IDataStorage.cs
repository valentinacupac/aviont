using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Aviont.Domain
{
    /// <summary>
    /// Represents internal storage of data
    /// </summary>
    public interface IDataStorage
    {
        /// <summary>
        /// Reads data from internal data storage
        /// </summary>
        /// <param name="request">Represents request for data to be read from internal storage</param>
        /// <returns></returns>
        DataSet ReadData(DataRequest request);

        /// <summary>
        /// Writes data to internal data storage
        /// </summary>
        /// <param name="data">Represents the data set which will be stored in internal storage</param>
        void WriteData(DataSet data);
    }
}
