using Optivem.OpenData.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Presentation.Windows
{
    public class MainViewModel
    {
        public ObservableCollection<MockStockDataRecord> StockData { get; set; }
    }

    // TOOD: Delete this dummy
    public class MockStockDataRecord
    {
        public string Date { get; set; }

        public double Open { get; set; }

        public double High { get; set; }

        public double Low { get; set; }

        public double Close { get; set; }

        public int Volume { get; set; }

        public double AdjustedClose { get; set; }
    }
}
