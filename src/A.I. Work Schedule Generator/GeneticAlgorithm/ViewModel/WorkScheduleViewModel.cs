using GeneticAlgorithm.Model;
using GeneticAlgorithm.NVVM;

namespace GeneticAlgorithm.ViewModel
{
    public class WorkScheduleViewModel : ViewModelBase
    {
        private WorkScheduleModel _workSchedule;
        public WorkScheduleModel WorkScheduleModel
        {
            get => _workSchedule;
            set
            {
                _workSchedule = value;
                OnPropertyChanged(nameof(WorkScheduleModel));
            }
        }

        //public WorkScheduleViewModel()
        //{
        //    _workSchedule = new WorkScheduleModel();
        //}

        //public void LoadWorkScheduleData()
        //{
        //    EmployeeModel = 
        //}
    }
}
