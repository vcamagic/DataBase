using DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UserInterface.ViewModels
{
    public class FieldViewModel : BaseViewModel
    {

        private List<Field> superfields;
        public FieldViewModel()
        {

            DeleteCommand = new MyICommand(Delete);
            AddCommand = new MyICommand(Add);
            //EditCommand = new MyICommand(Edit);
            Superfields = Service.ServiceInstance.GetAllSuperFields();
            RefreshView();
        }

        public List<Field> Superfields
        {
            get { return superfields; }
            set
            {
                superfields = value;
                OnPropertyChanged(nameof(Superfields));
            }
        }

        private Field selectedSuperField;

        public Field SelectedSuperField
        {
            get { return selectedSuperField; }
            set
            {
                selectedSuperField = value;
                OnPropertyChanged(nameof(SelectedSuperField));
            }
        }

        private Field selectedField;

        public Field SelectedField
        {
            get { return selectedField; }
            set
            {
                selectedField = value;
                OnPropertyChanged(nameof(SelectedField));
            }
        }

        public void RefreshView()
        {
            Data = new ObservableCollection<Field>(Service.ServiceInstance.GetAllFields());
            Superfields = new List<Field>(Service.ServiceInstance.GetAllSuperFields());
        }

        public MyICommand AddCommand { get; set; }
        public MyICommand EditCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }

        private ObservableCollection<Field> data;

        public ObservableCollection<Field> Data
        {

            get { return data; }
            set
            {
                data = value;
                OnPropertyChanged(nameof(Data));
            }
        }

        private string fieldName;

        public string FieldName
        {
            get { return fieldName; }
            set
            {
                fieldName = value;
                OnPropertyChanged(nameof(FieldName));
            }

        }

        private string selectedFieldName;

        public string SelectedFieldName
        {
            get { return selectedFieldName; }
            set
            {
                selectedFieldName = value;
                OnPropertyChanged(nameof(SelectedFieldName));
            }

        }

        private int fieldId;

        public int FieldId
        {
            get { return fieldId; }
            set
            {
                fieldId = value;
                OnPropertyChanged(nameof(FieldId));
            }
        }

        private string selectedFieldId;

        public string SelectedFieldId
        {
            get { return selectedFieldId; }
            set
            {
                selectedFieldId = value;
                OnPropertyChanged(nameof(SelectedFieldId));
            }
        }

        private string selectedType;

        public string SelectedType
        {
            get { return selectedType; }
            set
            {
                if (value == "Subfield")
                {
                    ShowSubfield = Visibility.Visible;
                }
                else if (value == "Superfield")
                {
                    ShowSubfield = Visibility.Collapsed;
                }
                selectedType = value;
                OnPropertyChanged(nameof(SelectedType));
            }
        }

        public List<string> FieldType { get; set; } = new List<string>() { "Subfield", "Superfield" };

        private Visibility showSubfield= Visibility.Collapsed;

        public Visibility ShowSubfield
        {
            get { return showSubfield; }
            set
            {
                showSubfield = value;
                OnPropertyChanged(nameof(ShowSubfield));
            }
        }

        public void Add()
        {
            if (SelectedType == "Subfield")
            {
                Field field = new Field() { FieldName = FieldName, Field1 = SelectedSuperField };
                Field superField = Service.ServiceInstance.GetField(SelectedSuperField.Id);
                superField.Fields.Add(field);
                Service.ServiceInstance.AddField(field);
            }
            else if(SelectedType == "Superfield")
            {

                Service.ServiceInstance.AddField(new Field() { FieldName = FieldName });
            }
            
            RefreshView();

        }

       /* public void Edit()
        {
            Service.ServiceInstance.EditPublisher(SelectedPublisher.Id, new Publisher() { Id = SelectedPublisher.Id, PublisherName = SelectedName, Address = SelectedAddress });
            RefreshView();
        }*/

        public void Delete()
        {
            Service.ServiceInstance.RemoveField(SelectedField.Id);
            RefreshView();
        }
    }
}
