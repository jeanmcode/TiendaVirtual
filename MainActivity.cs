using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using Xamarin.Essentials;

namespace Tienda_Tarea
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        //  INSTANCIA DEL SERVICIO A CONSUMIR
        public static TiendaVServices.TiendaVirtualWS tienda = new TiendaVServices.TiendaVirtualWS();

        EditText edtUser, edtPass;
        Button btnIngresar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            btnIngresar = (Button)FindViewById(Resource.Id.btnIngresar);
            edtUser = (EditText)FindViewById(Resource.Id.edtUser);
            edtPass = (EditText)FindViewById(Resource.Id.edtPass);

            Android.App.AlertDialog.Builder alerta = new Android.App.AlertDialog.Builder(this);

            if(Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                alerta.SetMessage("No internet connection");
                alerta.SetIcon(Android.Resource.Drawable.IcDialogAlert);
                alerta.Show();

            }

            

            btnIngresar.Click += BtnIngresar_Click;

    
        }

        private void BtnIngresar_Click(object sender, System.EventArgs e)
        {
            Android.App.AlertDialog.Builder alerta = new Android.App.AlertDialog.Builder(this);

            //string user = "Jean";
            //string pass = "18040491";

            if(Connectivity.NetworkAccess == NetworkAccess.Internet)
            { 

                //mandamos los datos de logueo al servicio web
                if (tienda.Logueo(edtUser.Text, edtPass.Text))
                {

                    StartActivity(typeof(MenuActivity));
                    this.Finish();
                    Toast.MakeText(this, "Bienvenido", ToastLength.Long).Show();

                }
                else
                {
                    alerta.SetMessage("Verifique su contraseña o Usuario");
                    alerta.SetIcon(Android.Resource.Drawable.IcDialogAlert);
                    alerta.Show();




                }


            }
            else
            {
                alerta.SetMessage("No internet connection");
                alerta.SetIcon(Android.Resource.Drawable.IcDialogAlert);
                alerta.Show();

            }

           
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}