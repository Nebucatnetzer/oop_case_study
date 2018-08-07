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
using WpfWebClient.ServiceReferenceEHEC;

namespace WpfWebClient
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
            
        }

        private void btnRandomStrainGenerator_Click(object sender, RoutedEventArgs e)
        {
            // create new client connection
            WpfWebClient.ServiceReferenceEHEC.ServiceClient client = new WpfWebClient.ServiceReferenceEHEC.ServiceClient();


            // Get the number of words and letters per word.
            int num_letters = int.Parse(txtNumLetters.Text);
            int num_words = int.Parse(txtNumStrains.Text);

            // Make an array of the letters we will use.
            char[] letters = "AEIOUBRFTDAEIOU".ToCharArray();

            // Make a random number generator.
            Random rand = new Random();

            // Make the words.
            for (int i = 1; i <= num_words; i++)
            {
                // Make a word.
                string word = "";
                for (int j = 1; j <= num_letters; j++)
                {
                    // Pick a random number between 0 and 25
                    // to select a letter from the letters array.
                    int letter_num = rand.Next(0, letters.Length - 1);

                    // Append the letter.
                    word += letters[letter_num];
                }

                // Write the strains into a list
                List<string> generatedStrains = new List<string>();

                generatedStrains.Add(word);

                foreach (var item in generatedStrains)
                {
                    Strain s = new Strain();
                    s.Name = item;
                    client.WriteStrain(s);
                }

            }

            client.Close();
        }   
    }
}
