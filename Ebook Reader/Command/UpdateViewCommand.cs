using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ebook_Reader.ViewModel;
using Ebook_Reader.Model;

namespace Ebook_Reader.Command
{
    public class UpdateViewCommand : ICommand
    {
        private MainWindowViewModel viewModel;
        public UpdateViewCommand(MainWindowViewModel viewModel) => this.viewModel = viewModel;


        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;


        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Library")
                viewModel.SelectedViewModel = new LibraryViewModel();
            if (parameter.ToString() == "Statistics")
                viewModel.SelectedViewModel = new StatisticsViewModel();
            if (parameter.ToString() == "Settings")
                viewModel.SelectedViewModel = new SettingsViewModel();
        }
    }
}
