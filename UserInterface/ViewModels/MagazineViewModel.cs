using DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface.ViewModels
{
    public class MagazineViewModel: BaseViewModel
    {



        public MagazineViewModel()
        {
            DeleteCommand = new MyICommand(Delete);
            AddCommand = new MyICommand(Add);
            EditCommand = new MyICommand(Edit);

            RefreshView();
        }
        public MyICommand AddCommand { get; set; }
        public MyICommand EditCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string selectedName;

        public string SelectedName
        {
            get { return selectedName; }
            set
            {
                selectedName = value;
                OnPropertyChanged(nameof(SelectedName));
            }

        }

        private string number;

        public string Number
        {
            get { return number; }
            set
            {
                number = value;
                OnPropertyChanged(nameof(Number));
            }
        }

        private string selectedNumber;

        public string SelectedNumber
        {
            get { return selectedNumber; }
            set
            {
                selectedNumber = value;
                OnPropertyChanged(nameof(SelectedNumber));
            }
        }

        private string yearPub;

        public string YearPub
        {
            get { return yearPub; }
            set
            {
                yearPub = value;
                OnPropertyChanged(nameof(YearPub));
            }
        }

        private string selectedYearPub;

        public string SelectedYearPub
        {
            get { return selectedYearPub; }
            set
            {
                selectedYearPub = value;
                OnPropertyChanged(nameof(SelectedYearPub));
            }
        }

        private ObservableCollection<Magazine> data;

        public ObservableCollection<Magazine> Data
        {

            get { return data; }
            set
            {
                data = value;
                OnPropertyChanged(nameof(Data));
            }
        }

        private Magazine selectedMagazine;

        public Magazine SelectedMagazine
        {
            get { return selectedMagazine; }
            set
            {
                selectedMagazine = value;
                //IsSelected = true;
                //Cleanup();
                WriteSelected();
                OnPropertyChanged(nameof(SelectedMagazine));
            }
        }

        public void WriteSelected()
        {
            if (SelectedMagazine != null)
            {
                SelectedName = SelectedMagazine.MagazineName;
                
            }
        }

        public void RefreshView()
        {
            Data = new ObservableCollection<Magazine>(Service.ServiceInstance.GetAllMagazines());
        }

        public void Add()
        {

            Service.ServiceInstance.AddMagazine(new Magazine() { MagazineName = Name, YearPublish = Int32.Parse(YearPub), NumMag = Int32.Parse(Number) });
            RefreshView();

        }

        public void Edit()
        {
            Service.ServiceInstance.EditMagazine(SelectedMagazine.NumMag,SelectedMagazine.YearPublish, new Magazine() { NumMag = SelectedMagazine.NumMag, YearPublish = SelectedMagazine.YearPublish , MagazineName = SelectedName });
            RefreshView();
        }

        public void Delete()
        {
            Service.ServiceInstance.RemoveMagazine(SelectedMagazine.NumMag, SelectedMagazine.YearPublish);
            RefreshView();
        }


    }
}
