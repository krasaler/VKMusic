using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VKMusic
{
    /// <summary>
    /// Логика взаимодействия для WebAuthorized.xaml
    /// </summary>
    public partial class WebAuthorized : Window
    {
        public delegate void Succes(Uri result);
        public event Succes SuccesEvent;
        private Uri requestUri;
        private Uri callbackUri;
        public WebAuthorized()
        {
            InitializeComponent();
        }
        public WebAuthorized(Uri requestUri, Uri callbackUri)
            : this()
        {
            this.callbackUri = callbackUri;
            this.requestUri = requestUri;
            webBrowser1.Source = requestUri;
        }

        private void WebBrowser_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (webBrowser1.Source.ToString().IndexOf(callbackUri.ToString()) == -1)
            {
                SuccesEvent(e.Uri);
            }
        }
    }
}
