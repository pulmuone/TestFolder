using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using AndroidX.Core.App;
using System.IO;
using Android;

namespace TestFolder.Droid
{
    [Activity(Label = "TestFolder", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private string externalPublicFolderRoot;
        private string externalPrivateFolder;
        static string[] PERMISSIONS = {
            Manifest.Permission.ForegroundService,
            Manifest.Permission.ReadExternalStorage,
            Manifest.Permission.WriteExternalStorage,
            Manifest.Permission.Camera,
            Manifest.Permission.RecordAudio
       };
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);


            externalPublicFolderRoot = Android.OS.Environment.GetExternalStoragePublicDirectory("").AbsolutePath;

            externalPrivateFolder = GetExternalFilesDir(null).AbsolutePath;

            // 23 이상부터
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                ActivityCompat.RequestPermissions(this, PERMISSIONS, 0);
            }
            if (!Directory.Exists(externalPublicFolderRoot + "/Pictures/PowerScribo"))
                Directory.CreateDirectory(externalPublicFolderRoot + "/Pictures/PowerScribo");
            //Android10 : Denied  Android9 : OK  
            if (!Directory.Exists(externalPublicFolderRoot + "/PowerScribo"))
                Directory.CreateDirectory(externalPublicFolderRoot + "/PowerScribo"); 
                //Android9 : Denied 

            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}