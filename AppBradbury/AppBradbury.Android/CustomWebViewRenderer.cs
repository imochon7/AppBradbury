using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms.Platform.Android;
using AppBradbury.Droid;
using Xamarin.Forms;
using System.Net;
using AppBradbury;
using Android.Widget;

[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))]

namespace AppBradbury.Droid
{
    public class CustomWebViewRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            try
            {
                base.OnElementChanged(e);

                if (e.NewElement != null)
                {
                    var customWebView = Element as CustomWebView;
                    Control.Settings.AllowUniversalAccessFromFileURLs = true;
                    Control.LoadUrl(string.Format("file:///android_asset/pdfjs/web/viewer.html?file={0}", string.Format("file:///{0}", customWebView.Uri)));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("[CustomWebViewRenderer::OnElementChanged] Error: " + ex.Message);
            }
        }
    }
}