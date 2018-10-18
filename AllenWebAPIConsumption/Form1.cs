using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AllenWebAPIConsumption
{
    public partial class Form1 : Form
    {
        static HttpClient _client;
        public string _currentToken;
        public List<SmallSchool> _schoolNames;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri("https://techtoriumportal-api.azurewebsites.net/api/SW/")
            };
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            _currentToken = await GetTokenAsync();
            label1.Text = $"Token <{_currentToken}>";
        }

        async Task<string> GetTokenAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("GetToken");
            if (response.IsSuccessStatusCode)
            {
                var rsp = await response.Content.ReadAsStringAsync();
                rsp = rsp.Remove(0, 1);
                rsp = rsp.Remove(rsp.Length - 1, 1);
                return rsp;
            }

            return "";
        }
        async Task<List<SmallSchool>> GetSchoolNamesAsync()
        {

            HttpResponseMessage response = await _client.GetAsync($"GetAllSchoolNames/{_currentToken}");


            if (response.IsSuccessStatusCode)
            {
                var ServerRsp = await response.Content.ReadAsStringAsync();
                var rsp = JArray.Parse(ServerRsp).ToObject<List<SmallSchool>>();

                return rsp;
            }

            return null;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            _schoolNames = await GetSchoolNamesAsync();

            foreach (var item in _schoolNames)
            {
                comboBox1.Items.Add(item);
            }            
        }
    }
}
