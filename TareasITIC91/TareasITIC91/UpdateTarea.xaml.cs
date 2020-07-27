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
    public partial class UpdateTarea : ContentPage
    {
        private TareaManager manager;
        private string idaux;
        public UpdateTarea(TareaManager manager, string id)
        {
            InitializeComponent();
            this.idaux = id;
            //DisplayAlert("Alerta de actualiozacion", id.ToString(), "OK");
            this.manager = manager;
        }

        public async void OnUpdateTarea(object sender, EventArgs e)
        {
            await manager.Update(txtTitulo.Text, txtDetalle.Text, pickFecha.Date, txtAsignado.Text, this.idaux);
        }
    }
}