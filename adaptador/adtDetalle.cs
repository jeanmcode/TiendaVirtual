using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Tienda_Tarea.TiendaVServices;

namespace Tienda_Tarea.adaptador
{
    public class adtDetalle : BaseAdapter<TiendaVServices.CategoriaSW>

    {
        

        Activity context;
        List<TiendaVServices.CategoriaSW> categorias; //Lista de categorias, consumidas por el servicio.

        public adtDetalle(Activity context, List<CategoriaSW> categorias)
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
                view = context.LayoutInflater.Inflate(Resource.Layout.adtDetalle, null);//asociamos el adaptador con el layout adaptador

            view.FindViewById<TextView>(Resource.Id.txtDescripcionC).Text = item.Descripcion;
            view.FindViewById<TextView>(Resource.Id.txtCodigoC).Text = item.Codigo;
            

            return view;
        }
    }
}