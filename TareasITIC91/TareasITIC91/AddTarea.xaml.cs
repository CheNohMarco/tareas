using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareasITIC91.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareasITIC91
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTarea : ContentPage
    {
        private TareaManager manager;
        private Date  fecha;
        
        public AddTarea(TareaManager manager)
        {
            InitializeComponent();
            this.manager = manager;
        }

        public async void OnSaveTarea(object sender, EventArgs e)
        {
            await manager.Add(txtTitulo.Text , txtDetalle.Text, fecha  );
        }

        private void pickFecha_DateSelected(object sender, DateChangedEventArgs e)
        {
            fecha = new Date();
            fecha.Anio = (ushort)e.NewDate.Year;
            fecha.Mes = (byte)e.NewDate.Month;
            fecha.Dia = (byte)e.NewDate.Day;

        }
    }
}