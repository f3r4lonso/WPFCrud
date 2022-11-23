using CrudWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CrudWPF
{
    /// <summary>
    /// Interaction logic for MenuLista.xaml
    /// </summary>
    public partial class MenuLista : Page
    {
        public MenuLista()
        {
            InitializeComponent();
            Refresh();
        }

        private void Refresh()
        {
            List<PersonViewModel> peopleList = new List<PersonViewModel>();
            using (Model.CrudWPFEntities db = new Model.CrudWPFEntities())
            {
                peopleList = (from d in db.Person
                              select new PersonViewModel
                              {
                                  Id = d.Id,
                                  Name = d.Name,
                                  Age = d.Age
                              }).ToList();

            }

            PeopleDG.ItemsSource = peopleList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.StaticMainFrame.Content = new PeopleForm();
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;

            using (Model.CrudWPFEntities db = new Model.CrudWPFEntities())
            {

                var deletePerson = db.Person.Find(Id);

                if (deletePerson != null)
                {
                    db.Person.Remove(deletePerson);
                    db.SaveChanges();
                }
            }

            Refresh();
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;

            PeopleForm peopleForm = new PeopleForm(Id);

            MainWindow.StaticMainFrame.Content = peopleForm;

        }
    }
}
