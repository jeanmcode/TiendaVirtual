using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Tienda_Tarea.adaptador;

namespace Tienda_Tarea
{


    [Activity(Label = "DetalleActivity")]
    public class DetalleActivity : Activity
    {

        //  INSTANCIA DEL SERVICIO A CONSUMIR
        public static TiendaVServices.TiendaVirtualWS tienda = new TiendaVServices.TiendaVirtualWS();

        EditText edtPrecio, edtCodigo, edtNombre;
        Spinner spnCategoria;
        Button btnFoto, btnGuardar;
        ImageView imgProd;

        //arreglo declarado para guardar la conversion de la imagen
        private byte[] imagen;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.detalle);

            edtCodigo = (EditText)FindViewById(Resource.Id.edtCodigo);
            edtPrecio = (EditText)FindViewById(Resource.Id.edtPrecio);
            edtNombre = (EditText)FindViewById(Resource.Id.edtProducto);
            spnCategoria = (Spinner)FindViewById(Resource.Id.spCategoria);
            btnFoto = (Button)FindViewById(Resource.Id.btnFoto);
            btnGuardar = (Button)FindViewById(Resource.Id.btnGuardar);
            imgProd = (ImageView)FindViewById(Resource.Id.imgProd);
            //metemos dentro de un adaptador las categorias
            var adaptador = new adapDetalle(this, tienda.GetCategoria().ToList());

            //cargamos el spinner
            spnCategoria.Adapter=adaptador;

            btnFoto.Click += BtnFoto_Click;
            btnGuardar.Click += BtnGuardar_Click;




        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {

            //se pone el  más uno porque las posiciones del spiner inician en cero y los id de la DB en 1
            int CategoriaId = spnCategoria.SelectedItemPosition  + 1;


            try
            {


                if (!string.IsNullOrWhiteSpace(edtCodigo.Text) && !string.IsNullOrWhiteSpace(edtNombre.Text)
               && !string.IsNullOrWhiteSpace(edtPrecio.Text) && imagen != null)
                {

                    //Se setean los datos, si se agregan regresa true
               if (tienda.SetProducto(edtCodigo.Text, edtNombre.Text, double.Parse(edtPrecio.Text),
                imagen, CategoriaId ))
                    {

                        Toast.MakeText(this, "Producto Agegado con exito", ToastLength.Long).Show();
                        StartActivity(typeof(MenuActivity));
                        this.Finish();

                    }

                    else
                    {
                        Toast.MakeText(this, "El Producto no ha podido ser agregado", ToastLength.Long).Show();

                    }




                }

                else
                {

                    Toast.MakeText(this, "Debe de llenar todos los campos y agregar una fotografia del producto", ToastLength.Long).Show();
                }

            }
            catch (Exception ex)
            {


                Toast.MakeText(this, "No posee conexión a internet", ToastLength.Long).Show();

            }




        }

        private void BtnFoto_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(intent, 0);

        }


        //metodo creado para hacer la conversion de la imagen a mapa de bits
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);


            Android.Graphics.Bitmap bitmap = (Android.Graphics.Bitmap)data.Extras.Get("data");
            imgProd.SetImageBitmap(bitmap);
            //bitmap to byte

            //convertimos a byte para luego almacenarlo

            using (var stream = new MemoryStream())
            {

                bitmap.Compress(Android.Graphics.Bitmap.CompressFormat.Png, 0, stream);

                //metemols el arreglo de bits en el array 
                imagen = stream.ToArray();

            }

        }
           
        }
}