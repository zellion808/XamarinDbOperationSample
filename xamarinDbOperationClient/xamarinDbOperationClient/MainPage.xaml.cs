using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace xamarinDbOperationClient
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            getAsync();
        }

        public async Task getAsync()
        {
            var httpClient = new HttpClient();
            var res = await httpClient.GetAsync("https://xamarindboperationsample.azurewebsites.net/api/Sessions");
            var json = res.Content.ReadAsStringAsync();
        }
    }
}
