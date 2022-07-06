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

namespace Tienda_Tarea
{
    [Activity(Label = "MenuActivity")]
    public class MenuActivity : Activity
    {
        Button btnAgregar,btnListar,btnEditar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.menu);
            // Create your application here


            btnAgregar = (Button)FindViewById(Resource.Id.btnAgregar);
            btnListar = (Button)FindViewById(Resource.Id.btnListar);
            btnEditar = (Button)FindViewById(Resource.Id.btnEditar);

            btnAgregar.Click += BtnAgregar_Click;
            btnListar.Click += BtnListar_Click;
            btnEditar.Click += BtnEditar_Click;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnListar_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ListasActivity));
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(DetalleActivity));
        }
    }
}