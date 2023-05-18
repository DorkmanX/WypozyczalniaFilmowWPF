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

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MoviesPage.xaml
    /// </summary>
    public partial class MoviesPage : Page
    {
        public MoviesPage()
        {
            InitializeComponent();


            List<Movie> movies = new List<Movie>();
            movies.Add(new Movie("Skazani na Shawshank", "Frank Darabont", "Adaptacja opowiadania Stephena Kinga. Niesłusznie skazany na dożywocie bankier, stara się przetrwać w brutalnym, więziennym świecie.", "Dramat", 142));
            movies.Add(new Movie("Ojciec chrzestny", "Francis Ford Coppola", "Opowieść o nowojorskiej rodzinie mafijnej. Starzejący się Don Corleone pragnie przekazać władzę swojemu synowi.", "Kryminał", 175));
            movies.Add(new Movie("Pulp Fiction", "Quentin Tarantino", "Przemoc i odkupienie w opowieści o dwóch płatnych mordercach pracujących na zlecenie mafii, żonie gangstera, bokserze i parze okradającej ludzi w restauracji.", "Kryminał", 154));
            movies.Add(new Movie("Mroczny rycerz", "Christopher Nolan", "Batman, z pomocą porucznika Gordona oraz prokuratora Harveya Denta, występuje przeciwko przerażającemu i nieobliczalnemu Jokerowi, który chce pogrążyć Gotham City w chaosie.", "Akcja", 152));
            movies.Add(new Movie("Władca Pierścieni: Drużyna Pierścienia", "Peter Jackson", "Podróż hobbita z Shire i jego ośmiu towarzyszy, której celem jest zniszczenie potężnego pierścienia pożądanego przez Czarnego Władcę - Saurona.", "Przygodowy", 178));
            movies.Add(new Movie("Podziemny krąg", "David Fincher", "Cierpiący na bezsenność mężczyzna poznaje gardzącego konsumpcyjnym stylem życia Tylera Durdena, który jest jego zupełnym przeciwieństwem.", "Dramat", 139));
            movies.Add(new Movie("Incepcja", "Christopher Nolan", "Czasy, gdy technologia pozwala na wchodzenie w świat snów. Złodziej Cobb ma za zadanie wszczepić myśl do śpiącego umysłu.", "Akcja", 148));
            movies.Add(new Movie("Matrix", "Lana Wachowski, Lilly Wachowski", "Haker komputerowy Neo dowiaduje się od tajemniczych rebeliantów, że świat, w którym żyje, jest tylko obrazem przesyłanym do jego mózgu przez roboty.", "Sci-Fi", 136));
            moviesListBox.ItemsSource = movies;
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = (sender as ListBox).SelectedItem as Movie;
            MessageBox.Show($"{selectedItem.title}\nReżyser: {selectedItem.director}\n\nOpis: {selectedItem.description}");
        }
    }
}
