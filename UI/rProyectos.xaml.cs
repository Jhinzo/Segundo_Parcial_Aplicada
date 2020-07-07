using Segundo_Parcial_Aplicada.BLL;
using Segundo_Parcial_Aplicada.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Segundo_Parcial_Aplicada.UI
{
    /// <summary>
    /// Interaction logic for rProyectos.xaml
    /// </summary>
    public partial class rProyectos : Window
    {
        private Proyectos Proyecto = new Proyectos();
        public rProyectos()
        {
            InitializeComponent();
            this.DataContext = Proyecto;
            LlnarLista();
        }
        private void LlnarLista()
        {
            TareaIdComboBox.ItemsSource = TareasBLL.GetList();
            TareaIdComboBox.SelectedValuePath = "TareaId";
            TareaIdComboBox.DisplayMemberPath = "TipoTarea";
            if (TareaIdComboBox.Items.Count > 0)
                TareaIdComboBox.SelectedIndex = 0;
        }
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Proyecto;
            LlnarLista();
        }

        private void Limpiar()
        {
            this.Proyecto = new Proyectos();
            this.DataContext = Proyecto;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Proyectos encontrado = BLL.ProyectoBLL.Buscar(Proyecto.ProyectoId);

            if (encontrado != null)
            {
                Proyecto = encontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Tarea no existe en la base de datos", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            Proyecto.Detalle.Add(new Entidades.ProyectosDetalle()
            {
                TareaId = Utilidades.ToInt(TareaIdComboBox.SelectedValue.ToString()),
                TipoTarea = TareaIdComboBox.Text,
                Requerimiento =RequerimientoTextBox.Text,
                Tiempo =Utilidades.ToDecimal(TiempoTextBox.Text)
            }

            );

            Cargar();


        }

        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                Proyecto.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Proyectos esValido = BLL.ProyectoBLL.Buscar(Proyecto.ProyectoId);

            return (esValido != null);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (Proyecto.ProyectoId == 0)
            {
                paso = ProyectoBLL.Guardar(Proyecto);
            }
            else
            {
                if (ExisteEnLaBaseDeDatos())
                {
                    paso = ProyectoBLL.Guardar(Proyecto);
                }
                else
                {
                    MessageBox.Show("No existe en la base de datos", "ERROR");
                }
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Fallo al guardar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Proyectos existe = ProyectoBLL.Buscar(Proyecto.ProyectoId);

            if (existe == null)
            {
                MessageBox.Show("No existe la tarea en la base de datos", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                ProyectoBLL.Eliminar(Proyecto.ProyectoId);
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
        }
    }
}
