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

        //public EmployeeViewModel()
        //{
        //    _employee = new EmployeeModel();
        //}

        //public void LoadEmployeeData()
        //{
        //    EmployeeModel = 
        //}
    }
}
