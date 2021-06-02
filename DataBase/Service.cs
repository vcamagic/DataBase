using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Service
    {
        private static Service serviceInstance = null;
        public ModelContainer DataBase { get; set; } = new ModelContainer();

        private Service() { }

        public static Service ServiceInstance
        {
            get
            {
                if (serviceInstance == null)
                {
                    serviceInstance = new Service();
                }

                return serviceInstance;
            }
        }


        #region writer service
        public List<Writer> GetAllWriters()
        {
            return DataBase.Writers.ToList();
        }

        /* public void AddWriter(Writer writer)
         {
             DataBase.Writers.Add(writer);
             DataBase.SaveChanges();
         }*/

        public void AddWContract(WriterUnderContract wContract)
        {
            DataBase.Writers.Add(wContract);
            DataBase.SaveChanges();
        }

        public void AddWFreelancer(WriterFreelancer f)
        {
            DataBase.Writers.Add(f);
            DataBase.SaveChanges();
        }

        public Writer GetWriter(int id)
        {
            return DataBase.Writers.FirstOrDefault(x => x.Id == id);
        }

        /* public void EditWriter(int id, Writer temp)
         {
             DataBase.Writers.FirstOrDefault(x => x.Id == id).Name = temp.Name;
             DataBase.Writers.FirstOrDefault(x => x.Id == id).LastName = temp.LastName;
             DataBase.Writers.FirstOrDefault(x => x.Id == id).WriterType = temp.WriterType;
             DataBase.SaveChanges();
         }*/


        public void EditWContract(int id, WriterUnderContract b)
        {
            DataBase.Writers.FirstOrDefault(x => x.Id == id).Name = b.Name;
            DataBase.Writers.FirstOrDefault(x => x.Id == id).LastName = b.LastName;
            //DataBase.Publications.FirstOrDefault(x => x.Id == id).PubType = b.PubType;
            (DataBase.Writers.FirstOrDefault(x => x.Id == id) as WriterUnderContract).Salary = b.Salary;
            (DataBase.Writers.FirstOrDefault(x => x.Id == id) as WriterUnderContract).NumWorkHours = b.NumWorkHours;
        }

        public void EditWFreelancer(int id, WriterFreelancer a)
        {
            DataBase.Writers.FirstOrDefault(x => x.Id == id).Name = a.Name;
            DataBase.Writers.FirstOrDefault(x => x.Id == id).LastName = a.LastName;
            //DataBase.Publications.FirstOrDefault(x => x.Id == id).PubType = b.PubType;
            (DataBase.Writers.FirstOrDefault(x => x.Id == id) as WriterFreelancer).Description = a.Description;
            
        }
        public void RemoveWriter(int id)
        {
            DataBase.Writers.Remove(DataBase.Writers.FirstOrDefault(x => x.Id == id));
            DataBase.SaveChanges();
        }
        #endregion

        #region publication service


        public List<Publication> GetAllPublications()
        {
            return DataBase.Publications.ToList();
        }

        public void AddBook(Book book)
        {
            DataBase.Publications.Add(book);
            DataBase.SaveChanges();
        }

        public void AddArticle(Article article)
        {
            DataBase.Publications.Add(article);
            DataBase.SaveChanges();
        }

        public Publication GetPublication(int id)
        {
            return DataBase.Publications.FirstOrDefault(x => x.Id == id);
        }

       /* public void EditPublication(int id, Publication temp)
        {
            DataBase.Publications.FirstOrDefault(x => x.Id == id).PubName = temp.PubName;
            DataBase.Publications.FirstOrDefault(x => x.Id == id).PubType = temp.PubType;
            //DataBase.Publications.FirstOrDefault(x => x.Id == id).WriterType = temp.WriterType;
            DataBase.SaveChanges();
        }*/

        public void EditBook(int id, Book b)
        {
            DataBase.Publications.FirstOrDefault(x => x.Id == id).PubName = b.PubName;
            //DataBase.Publications.FirstOrDefault(x => x.Id == id).PubType = b.PubType;
            (DataBase.Publications.FirstOrDefault(x => x.Id == id) as Book).Publisher = b.Publisher;
            (DataBase.Publications.FirstOrDefault(x => x.Id == id) as Book).NumOfCopies = b.NumOfCopies;
        }

        public void EditArticle(int id, Article a)
        {
            DataBase.Publications.FirstOrDefault(x => x.Id == id).PubName = a.PubName;
            //DataBase.Publications.FirstOrDefault(x => x.Id == id).PubType = b.PubType;
            (DataBase.Publications.FirstOrDefault(x => x.Id == id) as Article).Magazine = a.Magazine;
            (DataBase.Publications.FirstOrDefault(x => x.Id == id) as Article).NumLetters = a.NumLetters;
        }

        public void RemovePublication(int id)
        {
            DataBase.Publications.Remove(DataBase.Publications.FirstOrDefault(x => x.Id == id));
            DataBase.SaveChanges();
        }
        #endregion

        #region publisher service

        public List<Publisher> GetAllPublishers()
        {
            return DataBase.Publishers.ToList();
        }

        public void AddPublisher(Publisher p)
        {
            DataBase.Publishers.Add(p);
            DataBase.SaveChanges();
        }

        public Publisher GetPublisher(int id)
        {
            return DataBase.Publishers.FirstOrDefault(x => x.Id == id);
        }

        public void EditPublisher(int id, Publisher temp)
        {
            DataBase.Publishers.FirstOrDefault(x => x.Id == id).PublisherName = temp.PublisherName;
            DataBase.Publishers.FirstOrDefault(x => x.Id == id).Address = temp.Address;
           // DataBase.Publishers.FirstOrDefault(x => x.Id == id).WriterType = temp.WriterType;
            DataBase.SaveChanges();
        }

        public void RemovePublisher(int id)
        {
            DataBase.Publishers.Remove(DataBase.Publishers.FirstOrDefault(x => x.Id == id));
            DataBase.SaveChanges();
        }

        #endregion


        #region magazine service

        public List<Magazine> GetAllMagazines()
        {
            return DataBase.Magazines.ToList();
        }

        public void AddMagazine(Magazine m)
        {
            DataBase.Magazines.Add(m);
            DataBase.SaveChanges();
        }

        public Magazine GetMagazine(int num,int year)
        {
            return DataBase.Magazines.FirstOrDefault(x => x.NumMag == num && x.YearPublish == year);
        }

        public void EditMagazine(int num,int year, Magazine m )
        {
            DataBase.Magazines.FirstOrDefault(x => x.NumMag == num && x.YearPublish == year).MagazineName = m.MagazineName;
           // DataBase.Magazines.FirstOrDefault(x => x.NumMag == num && x.YearPublish == year).Address = temp.Address;
            // DataBase.Publishers.FirstOrDefault(x => x.Id == id).WriterType = temp.WriterType;
            DataBase.SaveChanges();
        }

        public void RemoveMagazine(int num,int year)
        {
            DataBase.Magazines.Remove(DataBase.Magazines.FirstOrDefault(x => x.NumMag == num && x.YearPublish == year));
            DataBase.SaveChanges();
        }

        #endregion


        #region field service

        public void AddField(Field f)
        {
            DataBase.Fields.Add(f);
            DataBase.SaveChanges();
        }

        public List<Field> GetAllFields()
        {
            return DataBase.Fields.ToList();
        }

        public List<Field> GetAllSuperFields()
        {
            List<Field> res = new List<Field>();

            foreach(Field f in DataBase.Fields.ToList())
            {
                if (f.Field1 == null)
                    res.Add(f);
            }

            return res;
        }

        public Field GetField(int id)
        {
            return DataBase.Fields.FirstOrDefault(x => x.Id == id);
        }

        public void EditField(int id, Field f)
        {
            DataBase.Fields.FirstOrDefault(x => x.Id == id).FieldName = f.FieldName;
            DataBase.SaveChanges();
        }

        public void RemoveField(int id)
        {
            DataBase.Fields.Remove(DataBase.Fields.FirstOrDefault(x => x.Id == id));
            DataBase.SaveChanges();
        }

        #endregion
    }
}
