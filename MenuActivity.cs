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
using Xamarin.Essentials; //libreria para checar conexion a internet

namespace Tienda_Tarea
{
    [Activity(Label = "MenuActivity")]
    public class MenuActivity : Activity
    {
        Button btnAgregar,btnListar,btnEditar;
        ImageButton btnLogout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.menu);
            // Create your application here


            btnAgregar = (Button)FindViewById(Resource.Id.btnAgregar);
            btnListar = (Button)FindViewById(Resource.Id.btnListar);
            btnEditar = (Button)FindViewById(Resource.Id.btnEditar);
            btnLogout = (ImageButton)FindViewById(Resource.Id.btnLogout);

            btnAgregar.Click += BtnAgregar_Click;
            btnListar.Click += BtnListar_Click;
            btnEditar.Click += BtnEditar_Click;
            btnLogout.Click += BtnLogout_Click;
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {

            StartActivity(typeof(MainActivity));
            this.Finish();

        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnListar_Click(object sender, EventArgs e)
        {

            //Checa la conexion a internet
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {

                StartActivity(typeof(Listas_Activity));
            }


            else
            {
                Toast.MakeText(this, "No posee conexión a internet", ToastLength.Short).Show();

            }

                
            
            
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {

            //Checa la conexion a internet
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {

                StartActivity(typeof(DetalleActivity));
            }


            else
            {
                Toast.MakeText(this, "No posee conexión a internet", ToastLength.Short).Show();

            }

                
            
        }
    }
}