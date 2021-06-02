using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserInterface.Commands;

namespace UserInterface.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel selectedViewModel;

        public MainViewModel()
        {
            SelectedViewModel = new WriterViewModel();
            UpdateViewCommand = new UpdateViewCommand(this);
        }

        public ICommand UpdateViewCommand { get; set; }
        public BaseViewModel SelectedViewModel
        {
            get { return selectedViewModel; }
            set
            {
                selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
    }
}
