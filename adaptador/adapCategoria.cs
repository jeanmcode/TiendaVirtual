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
using Tienda_Tarea.TiendaVServices;

namespace Tienda_Tarea.adaptador
{
    public class adapCategoria : BaseAdapter<TiendaVServices.CategoriaSW>
    {
        Activity context;
        List<TiendaVServices.CategoriaSW> categorias; //Lista de categorias, consumidas por el servicio.

        public adapCategoria(Activity context, List<CategoriaSW> categorias)
        {
            this.context = context;
            this.categorias = categorias;
        }


        public override CategoriaSW this[int position]
        {
            get { return categorias[position]; }

        }

        public override int Count => categorias.Count();

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = categorias[position];

            View view = convertView;

            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.adtCategoria, null);//asociamos el adaptador con el layout adaptador

            view.FindViewById<TextView>(Resource.Id.txtNombre).Text = item.Codigo;
            view.FindViewById<TextView>(Resource.Id.txtDetalle).Text = item.Descripcion;
            view.FindViewById<ImageView>(Resource.Id.imgProducto).SetImageResource(Resource.Drawable.category);

            return view; throw new NotImplementedException();
        }
    }
}