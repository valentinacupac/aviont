using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Optivem.OpenData.Presentation.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SampleInitialize();
        }

        // TODO: This is only sample, delete it
        private void SampleInitialize()
        {
            MainViewModel viewModel = new MainViewModel();

            viewModel.StockData = CreateMockData();
            this.DataContext = viewModel;
        }


        private static ObservableCollection<MockStockDataRecord> CreateMockData()
        {
            return new ObservableCollection<MockStockDataRecord>
            {
                new MockStockDataRecord { Date = "14-08-15", Open = 114.32,  High = 116.309998, Low = 114.010002, Close = 115.959999, Volume = 42693,  AdjustedClose = 115.959999,},
                new MockStockDataRecord { Date = "13-08-15", Open = 116.040001,  High = 116.400002, Low = 114.540001, Close = 115.150002, Volume = 48336,  AdjustedClose = 115.150002,},
                new MockStockDataRecord { Date = "12-08-15", Open = 112.529999,  High = 115.419998, Low = 109.629997, Close = 115.239998, Volume = 101218,  AdjustedClose = 115.239998,},
                new MockStockDataRecord { Date = "11-08-15", Open = 117.809998,  High = 118.18, Low = 113.330002, Close = 113.489998, Volume = 95712,  AdjustedClose = 113.489998,},
                new MockStockDataRecord { Date = "10-08-15", Open = 116.529999,  High = 119.989998, Low = 116.529999, Close = 119.720001, Volume = 54539,  AdjustedClose = 119.720001,},
                new MockStockDataRecord { Date = "07-08-15", Open = 114.580002,  High = 116.25, Low = 114.5, Close = 115.519997, Volume = 38421,  AdjustedClose = 115.519997,},
                new MockStockDataRecord { Date = "06-08-15", Open = 115.970001,  High = 116.5, Low = 114.120003, Close = 115.129997, Volume = 52903,  AdjustedClose = 115.129997,},
                new MockStockDataRecord { Date = "05-08-15", Open = 112.949997,  High = 117.440002, Low = 112.099998, Close = 115.400002, Volume = 99313,  AdjustedClose = 114.880003,},
                new MockStockDataRecord { Date = "04-08-15", Open = 117.419998,  High = 117.699997, Low = 113.25, Close = 114.639999, Volume = 124139,  AdjustedClose = 114.123426,},
                new MockStockDataRecord { Date = "03-08-15", Open = 121.5,  High = 122.57, Low = 117.519997, Close = 118.440002, Volume = 69976,  AdjustedClose = 117.906306,},
                new MockStockDataRecord { Date = "31-07-15", Open = 122.599998,  High = 122.639999, Low = 120.910004, Close = 121.300003, Volume = 42885,  AdjustedClose = 120.753419,},
                new MockStockDataRecord { Date = "30-07-15", Open = 122.32,  High = 122.57, Low = 121.709999, Close = 122.370003, Volume = 33628,  AdjustedClose = 121.818597,},
                new MockStockDataRecord { Date = "29-07-15", Open = 123.150002,  High = 123.5, Low = 122.269997, Close = 122.989998, Volume = 37012,  AdjustedClose = 122.435799,},
                new MockStockDataRecord { Date = "28-07-15", Open = 123.379997,  High = 123.910004, Low = 122.550003, Close = 123.379997, Volume = 33618,  AdjustedClose = 122.824041,},
                new MockStockDataRecord { Date = "27-07-15", Open = 123.089996,  High = 123.610001, Low = 122.120003, Close = 122.769997, Volume = 44456,  AdjustedClose = 122.216789,},
                new MockStockDataRecord { Date = "24-07-15", Open = 125.32,  High = 125.739998, Low = 123.900002, Close = 124.5, Volume = 42162,  AdjustedClose = 123.938997,},
                new MockStockDataRecord { Date = "23-07-15", Open = 126.199997,  High = 127.089996, Low = 125.059998, Close = 125.160004, Volume = 51000,  AdjustedClose = 124.596026,},
                new MockStockDataRecord { Date = "22-07-15", Open = 121.989998,  High = 125.5, Low = 121.989998, Close = 125.220001, Volume = 115451,  AdjustedClose = 124.655753,},
                new MockStockDataRecord { Date = "21-07-15", Open = 132.850006,  High = 132.919998, Low = 130.320007, Close = 130.75, Volume = 76756,  AdjustedClose = 130.160834,},
                new MockStockDataRecord { Date = "20-07-15", Open = 130.970001,  High = 132.970001, Low = 130.699997, Close = 132.070007, Volume = 58900,  AdjustedClose = 131.474893,},
                new MockStockDataRecord { Date = "17-07-15", Open = 129.080002,  High = 129.619995, Low = 128.309998, Close = 129.619995, Volume = 46165,  AdjustedClose = 129.035921,},
                new MockStockDataRecord { Date = "16-07-15", Open = 127.739998,  High = 128.570007, Low = 127.349998, Close = 128.509995, Volume = 36222,  AdjustedClose = 127.930922,},
                new MockStockDataRecord { Date = "15-07-15", Open = 125.720001,  High = 127.150002, Low = 125.580002, Close = 126.82, Volume = 33649,  AdjustedClose = 126.248542,},
                new MockStockDataRecord { Date = "14-07-15", Open = 126.040001,  High = 126.370003, Low = 125.040001, Close = 125.610001, Volume = 31768,  AdjustedClose = 125.043995,},
                new MockStockDataRecord { Date = "13-07-15", Open = 125.029999,  High = 125.760002, Low = 124.32, Close = 125.660004, Volume = 41441,  AdjustedClose = 125.093773,},
                new MockStockDataRecord { Date = "10-07-15", Open = 121.940002,  High = 123.849998, Low = 121.209999, Close = 123.279999, Volume = 61355,  AdjustedClose = 122.724493,},
                new MockStockDataRecord { Date = "09-07-15", Open = 123.849998,  High = 124.059998, Low = 119.220001, Close = 120.07, Volume = 78595,  AdjustedClose = 119.528958,},
                new MockStockDataRecord { Date = "08-07-15", Open = 124.480003,  High = 124.639999, Low = 122.540001, Close = 122.57, Volume = 60762,  AdjustedClose = 122.017693,},
                new MockStockDataRecord { Date = "07-07-15", Open = 125.889999,  High = 126.150002, Low = 123.769997, Close = 125.690002, Volume = 46947,  AdjustedClose = 125.123637,},
                new MockStockDataRecord { Date = "06-07-15", Open = 124.940002,  High = 126.230003, Low = 124.849998, Close = 126, Volume = 28060,  AdjustedClose = 125.432238,},
                new MockStockDataRecord { Date = "02-07-15", Open = 126.43,  High = 126.690002, Low = 125.769997, Close = 126.440002, Volume = 27211,  AdjustedClose = 125.870257,},
                new MockStockDataRecord { Date = "01-07-15", Open = 126.900002,  High = 126.940002, Low = 125.989998, Close = 126.599998, Volume = 30239,  AdjustedClose = 126.029532,},
                new MockStockDataRecord { Date = "30-06-15", Open = 125.57,  High = 126.120003, Low = 124.860001, Close = 125.43, Volume = 44371,  AdjustedClose = 124.864806,},
                new MockStockDataRecord { Date = "29-06-15", Open = 125.459999,  High = 126.470001, Low = 124.480003, Close = 124.529999, Volume = 49161,  AdjustedClose = 123.96886,},
                new MockStockDataRecord { Date = "26-06-15", Open = 127.669998,  High = 127.989998, Low = 126.510002, Close = 126.75, Volume = 44067,  AdjustedClose = 126.178858,},
                new MockStockDataRecord { Date = "25-06-15", Open = 128.860001,  High = 129.199997, Low = 127.5, Close = 127.5, Volume = 31938,  AdjustedClose = 126.925478,},
                new MockStockDataRecord { Date = "24-06-15", Open = 127.209999,  High = 129.800003, Low = 127.120003, Close = 128.110001, Volume = 55281,  AdjustedClose = 127.53273,},
                new MockStockDataRecord { Date = "23-06-15", Open = 127.480003,  High = 127.610001, Low = 126.879997, Close = 127.029999, Volume = 30269,  AdjustedClose = 126.457595,},
                new MockStockDataRecord { Date = "22-06-15", Open = 127.489998,  High = 128.059998, Low = 127.080002, Close = 127.610001, Volume = 34039,  AdjustedClose = 127.034983,},
                new MockStockDataRecord { Date = "19-06-15", Open = 127.709999,  High = 127.82, Low = 126.400002, Close = 126.599998, Volume = 54717,  AdjustedClose = 126.029532,},
                new MockStockDataRecord { Date = "18-06-15", Open = 127.230003,  High = 128.309998, Low = 127.220001, Close = 127.879997, Volume = 35407,  AdjustedClose = 127.303763,},
                new MockStockDataRecord { Date = "17-06-15", Open = 127.720001,  High = 127.879997, Low = 126.739998, Close = 127.300003, Volume = 32918,  AdjustedClose = 126.726383,},
                new MockStockDataRecord { Date = "16-06-15", Open = 127.029999,  High = 127.849998, Low = 126.370003, Close = 127.599998, Volume = 31494,  AdjustedClose = 127.025026,},
                new MockStockDataRecord { Date = "15-06-15", Open = 126.099998,  High = 127.239998, Low = 125.709999, Close = 126.919998, Volume = 43989,  AdjustedClose = 126.34809,},
                new MockStockDataRecord { Date = "12-06-15", Open = 128.190002,  High = 128.330002, Low = 127.110001, Close = 127.169998, Volume = 36886,  AdjustedClose = 126.596964,},
                new MockStockDataRecord { Date = "11-06-15", Open = 129.179993,  High = 130.179993, Low = 128.479996, Close = 128.589996, Volume = 35391,  AdjustedClose = 128.010563,},
                new MockStockDataRecord { Date = "10-06-15", Open = 127.919998,  High = 129.339996, Low = 127.849998, Close = 128.880005, Volume = 39087,  AdjustedClose = 128.299265,},
                new MockStockDataRecord { Date = "09-06-15", Open = 126.699997,  High = 128.080002, Low = 125.620003, Close = 127.419998, Volume = 56075,  AdjustedClose = 126.845837,},
                new MockStockDataRecord { Date = "08-06-15", Open = 128.899994,  High = 129.210007, Low = 126.830002, Close = 127.800003, Volume = 52675,  AdjustedClose = 127.22413,},
                new MockStockDataRecord { Date = "05-06-15", Open = 129.5,  High = 129.690002, Low = 128.360001, Close = 128.649994, Volume = 35627,  AdjustedClose = 128.07029,},
                new MockStockDataRecord { Date = "04-06-15", Open = 129.580002,  High = 130.580002, Low = 128.910004, Close = 129.360001, Volume = 38450,  AdjustedClose = 128.777098,},
                new MockStockDataRecord { Date = "03-06-15", Open = 130.660004,  High = 130.940002, Low = 129.899994, Close = 130.119995, Volume = 30984,  AdjustedClose = 129.533668,},
                new MockStockDataRecord { Date = "02-06-15", Open = 129.860001,  High = 130.660004, Low = 129.320007, Close = 129.960007, Volume = 33668,  AdjustedClose = 129.3744,},
                new MockStockDataRecord { Date = "01-06-15", Open = 130.279999,  High = 131.389999, Low = 130.050003, Close = 130.539993, Volume = 32113,  AdjustedClose = 129.951773,},
                new MockStockDataRecord { Date = "29-05-15", Open = 131.229996,  High = 131.449997, Low = 129.899994, Close = 130.279999, Volume = 50885,  AdjustedClose = 129.69295,},
                new MockStockDataRecord { Date = "28-05-15", Open = 131.860001,  High = 131.949997, Low = 131.100006, Close = 131.779999, Volume = 30733,  AdjustedClose = 131.186191,},
                new MockStockDataRecord { Date = "27-05-15", Open = 130.339996,  High = 132.259995, Low = 130.050003, Close = 132.039993, Volume = 45833,  AdjustedClose = 131.445014,},
                new MockStockDataRecord { Date = "26-05-15", Open = 132.600006,  High = 132.910004, Low = 129.119995, Close = 129.619995, Volume = 70698,  AdjustedClose = 129.035921,},
                new MockStockDataRecord { Date = "22-05-15", Open = 131.600006,  High = 132.970001, Low = 131.399994, Close = 132.539993, Volume = 45596,  AdjustedClose = 131.942761,},
                new MockStockDataRecord { Date = "21-05-15", Open = 130.070007,  High = 131.630005, Low = 129.830002, Close = 131.389999, Volume = 39730,  AdjustedClose = 130.797949,},
                new MockStockDataRecord { Date = "20-05-15", Open = 130,  High = 130.979996, Low = 129.339996, Close = 130.059998, Volume = 36455,  AdjustedClose = 129.473941,},
                new MockStockDataRecord { Date = "19-05-15", Open = 130.690002,  High = 130.880005, Low = 129.639999, Close = 130.070007, Volume = 44633,  AdjustedClose = 129.483905,},
                new MockStockDataRecord { Date = "18-05-15", Open = 128.380005,  High = 130.720001, Low = 128.360001, Close = 130.190002, Volume = 50883,  AdjustedClose = 129.60336,},
                new MockStockDataRecord { Date = "15-05-15", Open = 129.070007,  High = 129.490005, Low = 128.210007, Close = 128.770004, Volume = 38208,  AdjustedClose = 128.18976,},
                new MockStockDataRecord { Date = "14-05-15", Open = 127.410004,  High = 128.949997, Low = 127.160004, Close = 128.949997, Volume = 45204,  AdjustedClose = 128.368942,},

            };
        }

    }
}
