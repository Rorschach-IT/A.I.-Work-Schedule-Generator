using System.IO;
using System.Text.Json;
using GeneticAlgorithm.Model;
using GeneticAlgorithm.NVVM;

namespace GeneticAlgorithm.ViewModel
{
    public class EmployeeViewModel : ViewModelBase
    {
        private EmployeeModel _employee;
        public EmployeeModel EmployeeModel
        {
            get => _employee;
            set
            {
                _employee = value;
                OnPropertyChanged(nameof(EmployeeModel));
            }
        }

        public EmployeeViewModel()
        {
            _employee = new EmployeeModel();
        }

        public void LoadEmployeeData()
        {
            const string fileName = "../../../Data/EmployeeData.json";

            try
            {
                string jsonString = File.ReadAllText(fileName);
                EmployeeModel = JsonSerializer.Deserialize<EmployeeModel>(jsonString);
            }
            catch (Exception ex) when (ex is FileNotFoundException or JsonException)
            {
                throw new ApplicationException($"Failed to load employee data from {fileName}", ex);
            }
        }
    }
}
