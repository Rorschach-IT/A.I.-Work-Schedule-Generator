using System.Windows;
using GeneticAlgorithm.ViewModel;

namespace GeneticAlgorithm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new WorkScheduleViewModel();  // Create an instance of WorkScheduleViewModel
            this.DataContext = viewModel;  // Set DataContext to the ViewModel
            viewModel.LoadWorkScheduleData();  // Load the data
        }
    }
}