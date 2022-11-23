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
    /// Interaction logic for PeopleForm.xaml
    /// </summary>
    public partial class PeopleForm : Page
    {

        public int Id { get; set; }
        public PeopleForm(int Id = 0)
        {
            InitializeComponent();

            if (Id != 0)
            {
                this.Id = Id;

                using (Model.CrudWPFEntities db = new Model.CrudWPFEntities())
                {
                    var updatedPerson = db.Person.Find(Id);

                    txtName.Text = updatedPerson.Name;

                    txtAge.Text = updatedPerson.Age.ToString();
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Id == 0)
            {
                using (Model.CrudWPFEntities db = new Model.CrudWPFEntities())
                {
                    var newPerson = new Model.Person();
                    newPerson.Name = txtName.Text;
                    newPerson.Age = Int32.Parse(txtAge.Text);

                    db.Person.Add(newPerson);

                    db.SaveChanges();

                    MainWindow.StaticMainFrame.Content = new MenuLista();
                }
            }
            else
            {
                using (Model.CrudWPFEntities db = new Model.CrudWPFEntities())
                {
                    var editedPerson = db.Person.Find(Id);

                    editedPerson.Name = txtName.Text;
                    editedPerson.Age = Int32.Parse(txtAge.Text);

                    db.Entry(editedPerson).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();

                    MainWindow.StaticMainFrame.Content = new MenuLista();
                }
            }
        }
    }
}
