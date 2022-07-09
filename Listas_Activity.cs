using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tienda_Tarea.adaptador;
using Tienda_Tarea.TiendaVServices;

namespace Tienda_Tarea
{
    [Activity(Label = "ListasActivity")]
    public class Listas_Activity : Activity
    {
        //  INSTANCIA DEL SERVICIO A CONSUMIR
        public static TiendaVServices.TiendaVirtualWS tienda = new TiendaVServices.TiendaVirtualWS();

        ListView lstCategoria;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.listas);
            // Create your application here

            lstCategoria = (ListView)FindViewById(Resource.Id.lstItem);

            //llamamos la instancia, luego al metodo que trae todas las categorias y las convertimos a lista 
            lstCategoria.Adapter = new adtCategoria(this,tienda.GetCategoria().ToList());

            lstCategoria.ItemClick += LstCategoria_ItemClick;

        }

        private void LstCategoria_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {

            Android.App.AlertDialog.Builder alerta = new Android.App.AlertDialog.Builder(this);

            alerta.SetTitle("Ver productos");
            alerta.SetMessage("¿Desea ver los productos de esta categoria?");
            alerta.SetIcon(Android.Resource.Drawable.IcDialogAlert);
            alerta.SetPositiveButton("si", delegate

          {

              //abrir nuevo layout

              var productos = tienda.GetCategoria()[e.Position]; //obtenemos la posicion de la categoria a la que se le 

              //almacenamos el id del producto al que se le dio click en el listview
              int ID = productos.Id;
              string Nombre = productos.Descripcion;

              Intent i = new Intent(this, typeof(ListaProducto_Activity));


              i.PutExtra("ID", ID);
              i.PutExtra("Nombre", Nombre);

              StartActivity(i);


           });

            alerta.SetNegativeButton("No", (senderAlert, args) => { });

            alerta.Show();
            
        }
    }
}