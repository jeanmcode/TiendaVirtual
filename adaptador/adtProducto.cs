using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tienda_Tarea.TiendaVServices;

namespace Tienda_Tarea.adaptador
{
    public class adtProducto : BaseAdapter<TiendaVServices.ProductoSW>
    {
        Activity context;
        List<TiendaVServices.ProductoSW> productos; //Lista de categorias, consumidas por el servicio.

        public adtProducto(Activity context, List<ProductoSW> productos)
        {
            this.context = context;
            this.productos = productos;
        }


        public override ProductoSW this[int position]
        {

            get { return productos[position]; }
        }
        public override int Count => productos.Count();

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = productos[position];

            View view = convertView;

            Bitmap bitmap = BitmapFactory.DecodeByteArray(item.Imagen, 0, item.Imagen.Length);

            if (view == null)                                    
                view = context.LayoutInflater.Inflate(Resource.Layout.adtProducto, null);//asociamos el adaptador con el layout adaptador

            view.FindViewById<TextView>(Resource.Id.txtProductoN).Text = item.Descripcion;
            view.FindViewById<TextView>(Resource.Id.txtPrecio).Text = "C$"+ item.Precio.ToString();
            view.FindViewById<ImageView>(Resource.Id.imgProducto2).SetImageBitmap(bitmap);

            return view;
        }
    }
}