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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int max = 100;
        public int min = 0;
        public int nombre = 0;
        public int nombrePrevu = 0;
        public int nombreEssais = 0;
        public bool minMaxSetted=false;
     
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Arreter(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Recommencer()
        {
            nombreMax.IsEnabled = true;
            nombreMin.IsEnabled = true;

            nombreMin.Text = "0";
            nombreMax.Text = "100";
            choix.Text = "";

            max = 100;
            min = 0;
            nombre = 0;
            nombrePrevu = 0;
            nombreEssais = 0;
            minMaxSetted = false;

    }

        private void Soumettre(object sender, RoutedEventArgs e)
        {
            resultat.Content = "";

            if (!this.minMaxSetted)
            {
             

                if (nombreMin.Text == "")
                {
                    MessageBox.Show("Choisissez votre nombre minimal d'abord!");
                    goto end;
                }

                if (nombreMax.Text == "")
                {
                    MessageBox.Show("Choisissez votre nombre maximal d'abord!");
                    goto end;
                }

                if (choix.Text == "")
                {
                    MessageBox.Show("Choisissez votre nombre d'abord!");
                    goto end;
                }

                if (!int.TryParse(choix.Text, out this.nombrePrevu))
                {
                    MessageBox.Show("Seules les nombres entiers sont acceptés pour le choix!");
                    goto end;
                }
               

                if (!int.TryParse(nombreMin.Text, out this.min))
                {
                    MessageBox.Show("Seules les nombres entiers sont acceptés pour le nombre minimal!");
                    goto end;
                }

                if (!int.TryParse(nombreMax.Text, out this.max))
                {
                    MessageBox.Show("Seules les nombres entiers sont acceptés pour le nombre maximal!");
                    goto end;
                }


                if (this.min <= this.max)
                {
                    this.minMaxSetted = true;
                    nombreMax.IsEnabled = false;
                    nombreMin.IsEnabled = false;
                    Random rnd = new Random();
                    this.nombre = rnd.Next(this.min, this.max + 1);

                    if (this.nombrePrevu > this.max || this.nombrePrevu < this.min)
                    {
                        this.nombreEssais++;
                        essais.Content = this.nombreEssais;
                        resultat.Content = "Votre choix n'est pas dans la plage qui a été défini!";
                    }
                    else
                    {
                        this.nombreEssais++;
                        essais.Content = this.nombreEssais;
                        if (this.nombrePrevu > this.nombre)
                        {
                            resultat.Content = "C'est plus petit que ça!";

                        }
                        else if (this.nombrePrevu < this.nombre)
                        {
                            resultat.Content = "C'est plus grand que ça!";

                        }
                        else
                        {
                            resultat.Content = "Bravo vous l'avez trouvé!";
                            resultat.Content += "\n Le nombre était " + this.nombre;
                            this.Recommencer();
                            

                        }
                     
                    }


                }
                else
                {
                    MessageBox.Show("Le nombre minimal doit être inférieur au nombre maximal!");
                }
            }
            else
            {
                if (nombreMin.Text == "")
                {
                    MessageBox.Show("Choisissez votre nombre minimal d'abord!");
                    goto end;
                }

                if (nombreMax.Text == "")
                {
                    MessageBox.Show("Choisissez votre nombre maximal d'abord!");
                    goto end;
                }

                if (choix.Text == "")
                {
                    MessageBox.Show("Choisissez votre nombre d'abord!");
                    goto end;
                }

                if (!int.TryParse(choix.Text, out this.nombrePrevu))
                {
                    MessageBox.Show("Seules les nombres entiers sont acceptés pour le choix!");
                    goto end;
                }
                else if (this.nombrePrevu > this.max || this.nombrePrevu < this.min)
                {
                    this.nombreEssais++;
                    essais.Content = this.nombreEssais;
                    resultat.Content = "Votre choix n'est pas dans la plage qui a été défini!";
                }
                else
                {
                    this.nombreEssais++;
                    essais.Content = this.nombreEssais;

                    if (this.nombrePrevu > this.nombre)
                    {
                        resultat.Content = "C'est plus petit que ça!";

                    }
                    else if (this.nombrePrevu < this.nombre)
                    {
                        resultat.Content = "C'est plus grand que ça!";

                    }
                    else
                    {
                        resultat.Content = "Bravo vous l'avez trouvé!";
                        resultat.Content += "\n Le nombre était " + this.nombre;
                        this.Recommencer();

                    }
                    
                }
            }



        end:;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
