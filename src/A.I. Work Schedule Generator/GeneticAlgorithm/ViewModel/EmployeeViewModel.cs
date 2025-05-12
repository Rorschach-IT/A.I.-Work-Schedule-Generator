﻿using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using GeneticAlgorithm.Model;
using GeneticAlgorithm.NVVM;

namespace GeneticAlgorithm.ViewModel
{
    public class EmployeeViewModel : ViewModelBase
    {
        private ObservableCollection<EmployeeModel> _employee = new();
        public ObservableCollection<EmployeeModel> Employees
        {
            get => _employee;
            set
            {
                _employee = value;
                OnPropertyChanged(nameof(Employees));
            }
        }

        public void LoadEmployeeData()
        {
            const string fileName = "../../../Data/Employee.json";

            try
            {
                string jsonString = File.ReadAllText(fileName);

                var employees = JsonSerializer.Deserialize<List<EmployeeModel>>(jsonString);

                if (employees is not null)
                    Employees = new ObservableCollection<EmployeeModel>(employees);
                //EmployeeModel = JsonSerializer.Deserialize<EmployeeModel>(jsonString);
            }
            catch (Exception ex) when (ex is FileNotFoundException or JsonException)
            {
                throw new ApplicationException($"Failed to load employee data from {fileName}", ex);
            }

            if (Employees.Count == 0)
            {
                throw new Exception("No employee data found.");
            }
        }
    }
}
