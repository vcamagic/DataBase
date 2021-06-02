using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace UserInterface.ViewModels
{
    public class PublisherViewModel: BaseViewModel
    {
        
     
        public PublisherViewModel()
        {
            DeleteCommand = new MyICommand(Delete);
            AddCommand = new MyICommand(Add);
            EditCommand = new MyICommand(Edit);
            
            RefreshView();
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

        private string address;

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged(nameof(Address));
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

        private string selectedAddress;

        public string SelectedAddress
        {
            get { return selectedAddress; }
            set
            {
                selectedAddress = value;
                OnPropertyChanged(nameof(SelectedAddress));
            }
        }

        public MyICommand AddCommand { get; set; }
        public MyICommand EditCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }

        private ObservableCollection<Publisher> data;

        public ObservableCollection<Publisher> Data
        {

            get { return data; }
            set
            {
                data = value;
                OnPropertyChanged(nameof(Data));
            }
        }



        private Publisher selectedPublisher;

        public Publisher SelectedPublisher
        {
            get { return selectedPublisher; }
            set
            {
                selectedPublisher = value;
                //IsSelected = true;
                //Cleanup();
                WriteSelected();
                OnPropertyChanged(nameof(SelectedPublisher));
            }
        }

      

        public void WriteSelected()
        {
            if (!(SelectedPublisher == null))
            {
                SelectedName = SelectedPublisher.PublisherName;
                SelectedAddress = SelectedPublisher.Address;

            }
        }

        public void RefreshView()
        {
            Data = new ObservableCollection<Publisher>(Service.ServiceInstance.GetAllPublishers());
        }


        public void Add()
        {

            Service.ServiceInstance.AddPublisher(new Publisher() { PublisherName = Name, Address = Address });
            RefreshView();

        }

        public void Edit()
        {
            Service.ServiceInstance.EditPublisher(SelectedPublisher.Id, new Publisher() { Id = SelectedPublisher.Id, PublisherName = SelectedName, Address = SelectedAddress });
            RefreshView();
        }

        public void Delete()
        {
            Service.ServiceInstance.RemovePublisher(SelectedPublisher.Id);
            RefreshView();
        }

    }
}
