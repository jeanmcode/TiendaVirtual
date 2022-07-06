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


        ListView lstProducto;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.listaProductos);

            // Create your application here

            lstProducto = (ListView)FindViewById(Resource.Id.lstProducto);

            

            int indice=0;

            //Recibimos el id del layaout anterior, siempre los enteros se reciben con GetIntExtra
            indice= Intent.GetIntExtra("ID",indice);

            //se envia el ID+1 porque en los listview las posiciones inician en cero y en las DB en uno
            lstProducto.Adapter = new adapProducto(this,tienda.GetProductosByCategoria(2).ToList());

        }
    }
}