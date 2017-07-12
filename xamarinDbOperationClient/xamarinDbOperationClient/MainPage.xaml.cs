using Newtonsoft.Json;
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
        HttpClient httpClient = new HttpClient();

        public MainPage()
        {
            InitializeComponent();
        }

        // GET（全件取得）
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var res = await httpClient.GetAsync("https://xamarindboperationsample.azurewebsites.net/api/Sessions");
            var json = res.Content.ReadAsStringAsync();
        }

        // POST
        private async void Button_Clicked2(object sender, EventArgs e)
        {
            var participatingSession = new ParticipatingSession()
            {
                RegistersId = int.Parse(rID.Text),
                SessionId = int.Parse(sID.Text),
                HallId = int.Parse(hID.Text),
            };

            var data = JsonConvert.SerializeObject(participatingSession);
            var content = new StringContent(data, Encoding.UTF8, "application/json");

            var res = await httpClient.PostAsync("https://xamarindboperationsample.azurewebsites.net/api/ParticipatingSessions", content);
        }

        // GET（ID指定）
        private async void Button_Clicked3(object sender, EventArgs e)
        {
            var res = await httpClient.GetAsync("https://xamarindboperationsample.azurewebsites.net/api/ParticipatingSessions/" + rrID.Text);
            var json = res.Content.ReadAsStringAsync();
        }

        // DELETE（ID指定）
        private async void Button_Clicked4(object sender, EventArgs e)
        {
            var res = await httpClient.DeleteAsync("https://xamarindboperationsample.azurewebsites.net/api/ParticipatingSessions/" + rrrID.Text + "?id2=" + ssID.Text);
            var json = res.Content.ReadAsStringAsync();
        }
    }
}
