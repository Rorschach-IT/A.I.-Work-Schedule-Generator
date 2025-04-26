using System.Windows;
using System.Windows.Controls;

namespace GeneticAlgorithm
{
    /// <summary>
    /// Interaction logic for Prediction.xaml
    /// </summary>
    public partial class Prediction : Window
    {
        public Prediction()
        {
            InitializeComponent();

            Loaded += (s, e) => Window_SizeChanged(null, null);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (WorkScheduleListView.View is GridView gridView)
            {
                // Adjust width for padding and scrollbar
                double totalWidth = WorkScheduleListView.ActualWidth - 35;

                if (gridView.Columns.Count == 4)
                {
                    gridView.Columns[0].Width = totalWidth * 0.30; // Date
                    gridView.Columns[1].Width = totalWidth * 0.30; // Day
                    gridView.Columns[2].Width = totalWidth * 0.20; // Change ID
                    gridView.Columns[3].Width = totalWidth * 0.20; // Employees Counter
                }
            }
        }
    }
}
