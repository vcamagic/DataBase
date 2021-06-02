using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserInterface.ViewModels;

namespace UserInterface.Commands
{
    public class UpdateViewCommand : ICommand
    {
       
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }


        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Writer")
            {
                viewModel.SelectedViewModel = new WriterViewModel();
            }
            if (parameter.ToString() == "WrittenPublication")
            {
                viewModel.SelectedViewModel = new WriterViewModel();
            }
            if (parameter.ToString() == "Publication")
            {
                viewModel.SelectedViewModel = new PublicationViewModel();
            }
            if (parameter.ToString() == "Field")
            {
                viewModel.SelectedViewModel = new FieldViewModel();
            }
            if (parameter.ToString() == "Book")
            {
                viewModel.SelectedViewModel = new WriterViewModel();
            }
            if (parameter.ToString() == "Article")
            {
                viewModel.SelectedViewModel = new WriterViewModel();
            }
            if (parameter.ToString() == "Publisher")
            {
                viewModel.SelectedViewModel = new PublisherViewModel();
            }
            if (parameter.ToString() == "Magazine")
            {
                viewModel.SelectedViewModel = new MagazineViewModel();
            }
            if (parameter.ToString() == "WritersUnderContract")
            {
                viewModel.SelectedViewModel = new WriterViewModel();
            }
            if (parameter.ToString() == "Freelancers")
            {
                viewModel.SelectedViewModel = new WriterViewModel();
            }
          
            
        }
    }
}
