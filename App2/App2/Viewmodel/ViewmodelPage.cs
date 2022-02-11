using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App2.Viewmodel
{
    public class Root
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }
    }

    public class ViewmodelPage:INotifyPropertyChanged
    {
        private const string url = "https://jsonplaceholder.typicode.com/todos";
        private HttpClient _Client = new HttpClient();
        private ObservableCollection<Root> _Todos;
        public ObservableCollection<Root> _todos
        {
            get => _Todos;
            set
            {
                _Todos = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public async Task Output()
        {
            var content = await _Client.GetStringAsync(url);
            var root = JsonConvert.DeserializeObject<List<Root>>(content);
            _todos = new ObservableCollection<Root>(root);
        }
        
        public ICommand LoadData => new Command(async value =>
        {
            await Output();
        });
    }
}
