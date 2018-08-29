using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
	public partial class MainPage : ContentPage, ISwipeCallBack
    {

        public static BoxView[,] listBox;
        public static Label[,] listLabel;
        public MainPage()
		{
            listBox = new BoxView[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    listBox[i, j] = new BoxView() { Color = Color.White};

            listLabel = new Label[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    listLabel[i, j] = new Label()
                    {
                        Text = "",
                        WidthRequest = 70,
                        HeightRequest = 70,
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                        TextColor = Color.Black,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    };

            InitializeComponent();
            


            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    grid.Children.Add(listBox[i, j], j, i);

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    grid.Children.Add(listLabel[i, j], j, i);
            SwipeListener swipeListener = new SwipeListener(mainStckCube, this);

        }

        private async void button2_Clicked(object sender, EventArgs e)
        {

            Matrix.GoToRight(grid);
            var vRecord = this.Resources["vRecord"] as ValRec;

            if (vRecord.ValueRecord != Matrix.newRec)
                vRecord.ValueRecord = Matrix.newRec;

            bool res1 = await Matrix.isGameOverAsync();
            if (res1)
              await  DisplayAlert("GAME OVER", "Your record " + Matrix.newRec.ToString(), "ОK");
        }

        private async void button3_Clicked(object sender, EventArgs e)
        {
            Matrix.GoToLeft(grid);
            var vRecord = this.Resources["vRecord"] as ValRec;

            if (vRecord.ValueRecord != Matrix.newRec)
                vRecord.ValueRecord = Matrix.newRec;

            bool res1 = await Matrix.isGameOverAsync();
            if (res1)
                await DisplayAlert("GAME OVER", "Your record " + Matrix.newRec.ToString(), "ОK");
        }

        private async void button4_Clicked(object sender, EventArgs e)
        {
            Matrix.GoToUp(grid);
            var vRecord = this.Resources["vRecord"] as ValRec;

            if (vRecord.ValueRecord != Matrix.newRec)
                vRecord.ValueRecord = Matrix.newRec;

            bool res1 = await Matrix.isGameOverAsync();
            if (res1)
               await DisplayAlert("GAME OVER", "Your record " + Matrix.newRec.ToString(), "ОK");
        }

        private async void button_Clicked(object sender, EventArgs e)
        {
            Matrix.GoToDown(grid);

            var vRecord = this.Resources["vRecord"] as ValRec;

            if(vRecord.ValueRecord != Matrix.newRec)
               vRecord.ValueRecord = Matrix.newRec;

            bool res1 = await Matrix.isGameOverAsync();
            if (res1)
               await DisplayAlert("GAME OVER", "Your record " + Matrix.newRec.ToString(), "ОK");

        }

        private void butto5_Clicked(object sender, EventArgs e)
        {
            var vRecord = this.Resources["vRecord"] as ValRec;

            if (vRecord.ValueRecord != Matrix.oldnewRec)
                vRecord.ValueRecord = Matrix.oldnewRec;

            Matrix.Back();
        }
        public static void SetListLabelIndex(int i, int j, string s)
        {
            listLabel[i, j].Text = s;
        }

        private async void button7_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        public void onLeftSwipe(View view)
        {
            button3_Clicked(null, null);
        }
        public void onRightSwipe(View view)
        {
            button2_Clicked(null, null);
        }
        public void onTopSwipe(View view)
        {
            button4_Clicked(null, null);
        }
        public void onBottomSwipe(View view)
        {
            button_Clicked(null, null);
        }
       
        public void onNothingSwiped(View view)
        {

        }
    }
}
