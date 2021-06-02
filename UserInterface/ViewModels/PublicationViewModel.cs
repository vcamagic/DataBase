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
    public class PublicationViewModel : BaseViewModel
    {

        private List<Publisher> publishers;
        private List<Magazine> magazines;
        public PublicationViewModel()
        {
            DeleteCommand = new MyICommand(Delete);
            AddCommand = new MyICommand(Add);
            EditCommand = new MyICommand(Edit);
            Publishers = new List<Publisher>(Service.ServiceInstance.GetAllPublishers());
            Magazines = new List<Magazine>(Service.ServiceInstance.GetAllMagazines());
            RefreshView();

        }


        public MyICommand AddCommand { get; set; }
        public MyICommand EditCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }


        public void RefreshView()
        {
            Data = new ObservableCollection<Publication>(Service.ServiceInstance.GetAllPublications());
        }

        private string pubName;

        public string PubName
        {
            get { return pubName; }
            set
            {
                pubName = value;
                OnPropertyChanged(nameof(PubName));
            }
        }


        private string selectedPubName;

        public string SelectedPubName
        {
            get { return selectedPubName; }
            set
            {
                selectedPubName = value;
                OnPropertyChanged(nameof(SelectedPubName));
            }
        }

        private string pubType;

        public string PubType
        {
            get { return pubType; }
            set
            {
                pubType = value;
                OnPropertyChanged(nameof(PubType));
            }
        }

        private string selectedPubType;

        public string SelectedPubType
        {
            get { return selectedPubType; }
            set
            {
                selectedPubType = value;
                OnPropertyChanged(nameof(SelectedPubType));
            }
        }

        private Visibility showBook = Visibility.Collapsed;

        public Visibility ShowBook
        {
            get { return showBook; }
            set
            {
                showBook = value;
                OnPropertyChanged(nameof(ShowBook));
            }
        }


        private Visibility showBookSelected = Visibility.Collapsed;

        public Visibility ShowBookSelected
        {
            get { return showBookSelected; }
            set
            {
                showBookSelected = value;
                OnPropertyChanged(nameof(ShowBookSelected));
            }
        }

        private Visibility showArticle = Visibility.Collapsed;

        public Visibility ShowArticle
        {
            get { return showArticle; }
            set
            {
                showArticle = value;
                OnPropertyChanged(nameof(ShowArticle));
            }
        }

        private Visibility showArticleSelected = Visibility.Collapsed;

        public Visibility ShowArticleSelected
        {
            get { return showArticleSelected; }
            set
            {
                showArticleSelected = value;
                OnPropertyChanged(nameof(ShowArticleSelected));
            }
        }

        private string numCopies;

        public string NumCopies
        {
            get { return numCopies; }
            set
            {
                numCopies = value;
                OnPropertyChanged(nameof(NumCopies));
            }
        }


        private string numCopiesSelected;

        public string NumCopiesSelected
        {
            get { return numCopiesSelected; }
            set
            {
                numCopiesSelected = value;
                OnPropertyChanged(nameof(NumCopiesSelected));
            }
        }

        private string numLetters;

        public string NumLetters
        {
            get { return numLetters; }
            set
            {
                numLetters = value;
                OnPropertyChanged(nameof(NumLetters));
            }
        }

        private string numLettersSelected;

        public string NumLettersSelected
        {
            get { return numLettersSelected; }
            set
            {
                numLettersSelected = value;
                OnPropertyChanged(nameof(NumLettersSelected));
            }
        }


        /*   private void Cleanup()
           {
               SelectedName = "";
               SelectedLastName = "";
               SelectedPublicationType = "";
           }*/

        private ObservableCollection<Publication> data;



        public ObservableCollection<Publication> Data
        {

            get { return data; }
            set
            {
                data = value;
                OnPropertyChanged(nameof(Data));
            }
        }


        public List<string> Types { get; set; } = new List<string>() { "Book", "Article"};


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

        private string type;

        public string Type
        {
            get { return type;}
            set
            {
                type = value;
                if (value == "Book")
                {
                    ShowBook = Visibility.Visible;
                    ShowArticle = Visibility.Collapsed;
                }
                else if (value == "Article")
                {
                    ShowArticle = Visibility.Visible;
                    ShowBook = Visibility.Collapsed;
                }
                else
                {
                    ShowArticle = Visibility.Collapsed;
                    ShowBook = Visibility.Collapsed;
                }
                OnPropertyChanged(nameof(Type));
            }
        }

        private Publication selectedPublication;

        public Publication SelectedPublication
        {
            get { return selectedPublication; }
            set
            {
                selectedPublication = value;
                IsSelected = true;
                //Cleanup();
                WriteSelected();
                OnPropertyChanged(nameof(SelectedPublication));
            }
        }

        public List<Publisher> Publishers
        {
            get { return publishers; }
            set
            {
                publishers = value;
                OnPropertyChanged(nameof(Publishers));
            }
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

        private Publisher selectedPublisher;

        public Publisher SelectedPublisher
        {
            get { return selectedPublisher; }
            set
            {
                selectedPublisher = value;
                IsSelected = true;
                //Cleanup();
                //WriteSelected();
                OnPropertyChanged(nameof(SelectedPublisher));
            }
        }


        private Publisher selectedPublisherS;

        public Publisher SelectedPublisherS
        {
            get { return selectedPublisherS; }
            set
            {
                selectedPublisherS = value;
                IsSelected = true;
                //Cleanup();
                //WriteSelected();
                OnPropertyChanged(nameof(SelectedPublisherS));
            }
        }

        private Magazine selectedMagazine;

        public Magazine SelectedMagazine
        {
            get { return selectedMagazine; }
            set
            {
                selectedMagazine = value;
                IsSelected = true;
                //Cleanup();
                //WriteSelected();
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
                IsSelected = true;
                //Cleanup();
                //WriteSelected();
                OnPropertyChanged(nameof(SelectedMagazineS));
            }
        }

        public void WriteSelected()
        {
            if (!(SelectedPublication == null))
            {
                if(SelectedPublication is Book)
                {
                    SelectedPubName = SelectedPublication.PubName;
                    ShowBookSelected = Visibility.Visible;
                    ShowArticleSelected = Visibility.Collapsed;
                    SelectedPublisherS = ((Book)SelectedPublication).Publisher;
                    NumCopiesSelected = ((Book)SelectedPublication).NumOfCopies.ToString();

                }
                else if (SelectedPublication is Article)
                {
                    SelectedPubName = SelectedPublication.PubName;
                    ShowBookSelected = Visibility.Collapsed;
                    ShowArticleSelected = Visibility.Visible;
                    SelectedMagazineS = ((Article)SelectedPublication).Magazine;
                    NumLettersSelected = ((Article)SelectedPublication).NumLetters.ToString();
                }
               
            }
        }

        public void Add()
        {
            if(Type == "Book")
            {
                Service.ServiceInstance.AddBook(new Book { PubName = PubName, PubType = "Book", NumOfCopies = Int32.Parse(NumCopies), Publisher = SelectedPublisher  });
            }
            else if (Type == "Article")
            {
                Service.ServiceInstance.AddArticle(new Article { PubName = PubName, PubType = "Article", NumLetters = Int32.Parse(NumLetters), Magazine = SelectedMagazine });
            }
           
            RefreshView();

        }

        public void Edit()
        {
            if (SelectedPublication.PubType == "Book")
            {
                Service.ServiceInstance.EditBook(SelectedPublication.Id, new Book() { Id = SelectedPublication.Id, PubName = SelectedPubName, PubType = "Book", NumOfCopies = Int32.Parse(NumCopiesSelected), Publisher = SelectedPublisherS });
            }
            else if (SelectedPublication.PubType == "Article")
            {
                Service.ServiceInstance.EditArticle(SelectedPublication.Id, new Article() { Id = SelectedPublication.Id, PubName = SelectedPubName, PubType = "Article", NumLetters = Int32.Parse(NumLettersSelected), Magazine = SelectedMagazineS });
            }
            RefreshView();
        }

        public void Delete()
        {
            Service.ServiceInstance.RemovePublication(SelectedPublication.Id);
            RefreshView();
        }
    }
}
