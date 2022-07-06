using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;

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

            btnIngresar.Click += BtnIngresar_Click;

    
        }

        private void BtnIngresar_Click(object sender, System.EventArgs e)
        {
            string user = "admin";
            string pass = "123";

            if (edtPass.Text == pass && edtUser.Text == user)
            {

                StartActivity(typeof(MenuActivity));
                Toast.MakeText(this, "Bienvenido", ToastLength.Long).Show();

            }
            else
            {
                Toast.MakeText(this, "Verifique su contraseña o Usuario", ToastLength.Long).Show();

            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}