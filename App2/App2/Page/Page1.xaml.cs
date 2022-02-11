using App2.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Page1 : ContentPage
    {
        private ViewmodelPage viewmodel = new ViewmodelPage();

        public Page1()
        {
            InitializeComponent();
            BindingContext = viewmodel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}