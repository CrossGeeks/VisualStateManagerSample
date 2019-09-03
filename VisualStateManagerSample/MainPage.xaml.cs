using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace VisualStateManagerSample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Label lastElementSelected;
        public MainPage()
        {
            InitializeComponent();

            for(int i=1; i<DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); i++)
            {
                mainLayout.Children.Add(new Label() {Text=$"{i}", TextColor=Color.White, VerticalOptions=LayoutOptions.Center});
            }

            foreach (var item in mainLayout.Children)
            {
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += Butto_Clicked;
                item.GestureRecognizers.Add(tapGestureRecognizer);
            }
        }

        private void Butto_Clicked(object sender, EventArgs e)
        {
            if (lastElementSelected != null)
                VisualStateManager.GoToState(lastElementSelected, "UnSelected");


            VisualStateManager.GoToState((Label)sender, "Selected");

            lastElementSelected = (Label)sender;
        }
    }
}
