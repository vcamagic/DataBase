using DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using UserInterface;
using UserInterface.Views;
using System.Windows;

namespace UserInterface.ViewModels
{
    public class WriterViewModel : BaseViewModel
    {

        private List<Magazine> magazines;
        public WriterViewModel()
        {
            DeleteCommand = new MyICommand(Delete);
            AddCommand = new MyICommand(Add);
            EditCommand = new MyICommand(Edit);
            Magazines = new List<Magazine>(Service.ServiceInstance.GetAllMagazines());
            RefreshView();

        }


        public List<Magazine> Magazines
        {
            get { return magazines; }
            set
            {
                magazines = value;
                OnPropertyChanged(nameof(Magazines));
            }
        }

        private Magazine selectedMagazine;

        public Magazine SelectedMagazine
        {
            get { return selectedMagazine; }
            set
            {
                selectedMagazine = value;
                OnPropertyChanged(nameof(SelectedMagazine));
            }
        }


        private Magazine selectedMagazineS;

        public Magazine SelectedMagazineS
        {
            get { return selectedMagazineS; }
            set
            {
                selectedMagazineS = value;
                OnPropertyChanged(nameof(SelectedMagazineS));
            }
        }

        public MyICommand AddCommand { get; set; }
        public MyICommand EditCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }


        public void RefreshView()
        {
            Data = new ObservableCollection<Writer>(Service.ServiceInstance.GetAllWriters());
        }

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

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string selectedLastName;

        public string SelectedLastName
        {
            get { return selectedLastName; }
            set
            {
                selectedLastName = value;
                OnPropertyChanged(nameof(SelectedLastName));
            }
        }

        private string writerType;

        public string WriterType
        {
            get { return writerType; }
            set
            {
                writerType = value;
                OnPropertyChanged(nameof(WriterType));
            }
        }

        private string selectedWriterType;

        public string SelectedWriterType
        {
            get { return selectedWriterType; }
            set
            {
                selectedWriterType = value;
                //Cleanup();
                OnPropertyChanged(nameof(SelectedWriterType));
            }
        }

        private void Cleanup()
        {
            SelectedName = "";
            SelectedLastName = "";
            SelectedWriterType = "";
        }

        private ObservableCollection<Writer> data;
        


        public ObservableCollection<Writer> Data
        {
           
            get { return data; }
            set
            {
                data = value;
                OnPropertyChanged(nameof(Data));
            }
        }


        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }

        private Writer selectedWriter;

        public Writer SelectedWriter
        {
            get { return selectedWriter; }
            set
            {
                selectedWriter = value;
                IsSelected = true;
                //Cleanup();
                WriteSelected();
                OnPropertyChanged(nameof(SelectedWriter));
            }
        }

        private Visibility showFreelancer = Visibility.Collapsed;

        public Visibility ShowFreelancer
        {
            get { return showFreelancer; }
            set
            {
                showFreelancer = value;
                OnPropertyChanged(nameof(ShowFreelancer));
            }
        }


        private Visibility showFreelancerSelected = Visibility.Collapsed;

        public Visibility ShowFreelancerSelected
        {
            get { return showFreelancerSelected; }
            set
            {
                showFreelancerSelected = value;
                OnPropertyChanged(nameof(ShowFreelancerSelected));
            }
        }

        private Visibility showContract = Visibility.Collapsed;

        public Visibility ShowContract
        {
            get { return showContract; }
            set
            {
                showContract = value;
                OnPropertyChanged(nameof(ShowContract));
            }
        }

        private Visibility showContractSelected = Visibility.Collapsed;

        public Visibility ShowContractSelected
        {
            get { return showContractSelected; }
            set
            {
                showContractSelected = value;
                OnPropertyChanged(nameof(ShowContractSelected));
            }
        }


        public List<string> Types { get; set; } = new List<string>() { "WriterUnderContract", "WriterFreelancer" };

        private string salary;

        public string Salary
        {
            get { return salary; }
            set
            {
                salary = value;
                OnPropertyChanged(Salary);
                  
            }
        }

        private string salarySelected;

        public string SalarySelected
        {
            get { return salarySelected; }
            set
            {
                salarySelected = value;
                OnPropertyChanged(SalarySelected);

            }
        }

        private string hours;

        public string Hours
        {
            get { return hours; }
            set
            {
                hours = value;
                OnPropertyChanged(Hours);

            }
        }


        private string hoursSelected;

        public string HoursSelected
        {
            get { return hoursSelected; }
            set
            {
                hoursSelected = value;
                OnPropertyChanged(HoursSelected);

            }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged(Description);

            }
        }

        private string descriptionSelected;

        public string DescriptionSelected
        {
            get { return descriptionSelected; }
            set
            {
                descriptionSelected = value;
                OnPropertyChanged(DescriptionSelected);

            }
        }

        private string type;

        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                if (value == "WriterUnderContract")
                {
                    ShowContract = Visibility.Visible;
                    ShowFreelancer = Visibility.Collapsed;
                }
                else if (value == "WriterFreelancer")
                {
                    ShowFreelancer = Visibility.Visible;
                    ShowContract = Visibility.Collapsed;
                }
                else
                {
                    ShowFreelancer = Visibility.Collapsed;
                    ShowContract = Visibility.Collapsed;
                }
                OnPropertyChanged(nameof(Type));
            }
        }

        private string typeSelected;

        public string TypeSelected
        {
            get { return typeSelected; }
            set
            {
                typeSelected = value;
                OnPropertyChanged(nameof(TypeSelected));
            }
        }


        public void WriteSelected()
        {
            if (!(SelectedWriter == null))
            {
                SelectedName = SelectedWriter.Name;
                SelectedLastName = SelectedWriter.LastName;
                if(SelectedWriter is WriterUnderContract)
                {
                    ShowContractSelected = Visibility.Visible;
                    ShowFreelancerSelected = Visibility.Collapsed;
                    TypeSelected = "WriterUnderContract";
                    SelectedMagazineS = ((WriterUnderContract)SelectedWriter).Magazine;
                    SalarySelected = ((WriterUnderContract)SelectedWriter).Salary.ToString();
                    HoursSelected = ((WriterUnderContract)SelectedWriter).NumWorkHours.ToString();
                }
                else if(SelectedWriter is WriterFreelancer)
                {
                    ShowContractSelected = Visibility.Collapsed;
                    ShowFreelancerSelected = Visibility.Visible;
                    TypeSelected = "WriterFreelancer";

                    DescriptionSelected = ((WriterFreelancer)SelectedWriter).Description;
                }
              
                
            }
        }

        public void Add()
        {

            if (Type == "WriterUnderContract")
            {
                Service.ServiceInstance.AddWContract(new WriterUnderContract() { Name = Name, LastName = LastName, WriterType = "Under Contract", NumWorkHours = Int32.Parse(Hours), Salary = Int32.Parse(Salary), Magazine = SelectedMagazine });
            }
            else if(Type == "WriterFreelancer")
            {
                Service.ServiceInstance.AddWFreelancer(new WriterFreelancer() { Name = Name, LastName = LastName, WriterType = "Freelancer", Description = Description });
            }
            

            RefreshView();
    
        }

        public void Edit()
        {

            if(SelectedWriter.WriterType == "Under Contract")
            {
                Service.ServiceInstance.EditWContract(SelectedWriter.Id, new WriterUnderContract() { Id = SelectedWriter.Id, Name = SelectedName, LastName = SelectedLastName, Salary = Int32.Parse(SalarySelected), NumWorkHours = Int32.Parse(HoursSelected), Magazine = SelectedMagazineS });
            }
            else if (SelectedWriter.WriterType == "Freelancer")
            {
                Service.ServiceInstance.EditWFreelancer(SelectedWriter.Id, new WriterFreelancer() { Id = SelectedWriter.Id, Name = SelectedName, LastName = SelectedLastName, Description = DescriptionSelected });

            }
            RefreshView();
        }

        public void Delete()
        {
            Service.ServiceInstance.RemoveWriter(SelectedWriter.Id);
            RefreshView();
        }
    }
}
