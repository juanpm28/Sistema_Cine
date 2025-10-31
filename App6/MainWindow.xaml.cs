using System;
using System.Collections.Generic;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using DB;
using System.Threading.Tasks;


namespace App6
{
    public sealed partial class MainWindow : Window
    {

        public MainWindow()
        {
            this.InitializeComponent();
        }

        static async Task Main(string[] args)
        {
            await DB.Consultas.ObtenerPeliculasAsync();

        }

        private void PeliculasList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Asegurarse de que hay selección
            if (PeliculasList.SelectedItem is ListViewItem selectedItem)
            {
                string titulo = selectedItem.Name?.ToString() ?? "Película";

                // Mostrar título en el panel derecho
                //txtPelicula.Text = $"Horarios para: {titulo}";

                // Limpiar horarios anteriores
                HorariosList.Items.Clear();

                // Simular horarios según la película
                if (titulo.Contains("Spiderman"))
                {
                    HorariosList.Items.Add("12:00 PM");
                    HorariosList.Items.Add("3:00 PM");
                    HorariosList.Items.Add("6:00 PM");
                }
                else if (titulo.Contains("KungFuPanda"))
                {
                    HorariosList.Items.Add("1:00 PM");
                    HorariosList.Items.Add("4:00 PM");
                    HorariosList.Items.Add("7:00 PM");
                }
                else if (titulo.Contains("Totoro"))
                {
                    HorariosList.Items.Add("2:00 PM");
                    HorariosList.Items.Add("5:00 PM");
                    HorariosList.Items.Add("8:00 PM");
                }
            }
            else
            {
                // Si no hay selección
                txtPelicula.Text = "Selecciona una película";
                HorariosList.Items.Clear();
            }
        }

        private void BtnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            // Ocultar panel de películas y mostrar panel de asientos
            Peliculas.Visibility = Visibility.Collapsed;
            Horarios.Visibility = Visibility.Collapsed;
            Asientos.Visibility = Visibility.Visible;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Login",
                Content = "Aquí irá la pantalla de login.",
                CloseButtonText = "Cerrar",
                XamlRoot = this.Content.XamlRoot
            };
            _ = dialog.ShowAsync();
        }

        private void Ventas_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Ventas",
                Content = "Aquí irá la pantalla de ventas.",
                CloseButtonText = "Cerrar",
                XamlRoot = this.Content.XamlRoot
            };
            _ = dialog.ShowAsync();
        }

        private void BtnContinuar_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Confirmación",
                Content = "Aquí irá la confirmación de asientos seleccionados.",
                CloseButtonText = "Cerrar",
                XamlRoot = this.Content.XamlRoot
            };
            _ = dialog.ShowAsync();
        }

    }
}
