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

namespace Tienda_Tarea
{
    [Activity(Label = "ListaProActivity")]
    public class ListaProActivity : Activity
    {
        //  INSTANCIA DEL SERVICIO A CONSUMIR
        public static TiendaVServices.TiendaVirtualWS tienda = new TiendaVServices.TiendaVirtualWS();

        int ID;
        string Nombre;
        ListView lstProducto;
        TextView txtTituloP;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.listaProductos);

            // Create your application here

            lstProducto = (ListView)FindViewById(Resource.Id.lstPro);
            txtTituloP = (TextView)FindViewById(Resource.Id.txtListaP);



            

            //Recibimos el id del layaout anterior, siempre los enteros se reciben con GetIntExtra
           ID= Intent.GetIntExtra("ID",ID);
           Nombre = Intent.GetStringExtra("Nombre");

            txtTituloP.Text = txtTituloP.Text + " de " + Nombre;


            //se envia el ID+1 porque en los listview las posiciones inician en cero y en las DB en uno
            lstProducto.Adapter = new adapProducto(this,tienda.GetProductosByCategoria(ID).ToList());

        }
    }
}