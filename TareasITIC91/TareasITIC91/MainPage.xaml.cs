using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareasITIC91.Data;
using Xamarin.Forms;

namespace TareasITIC91
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private IList<Tarea> tareas = new ObservableCollection<Tarea>();
        private TareaManager manager = new TareaManager();

        public MainPage()
        {
            BindingContext = tareas;
            InitializeComponent();
            Refresh();
        }

         void OnRefresh(object sender, EventArgs e)
        {
            Refresh();
        }

        async private void Refresh()
        {
            var tareasCollection = await manager.GetAll();
            foreach (Tarea tarea in tareasCollection)
            {
                if (tareas.All(t => t.Id != tarea.Id))
                {
                    tareas.Add(tarea);
                }
            }
        }

        async private void OnAddTarea(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddTarea(manager));
        }
    }
}
