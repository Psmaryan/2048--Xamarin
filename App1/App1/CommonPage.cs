using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
//using System.Reflection.Emit;
using System.Text;

namespace App1
{
    public class CommonPage : ContentPage
    {
        public CommonPage()
        {
            FormattedString formattedString = new FormattedString();
            formattedString.Spans.Add(new Span
            {
                Text = "Marian Pshyk\n",
                ForegroundColor = Color.Red,
                FontAttributes = FontAttributes.Italic,
                FontSize = 50,
                
            });
            formattedString.Spans.Add(new Span
            {
                Text = "2048",
                ForegroundColor = Color.Black,
                FontAttributes = FontAttributes.Bold,
                FontSize = 120,
            });
            Label lb = new Label()
            {
                //Text = "Marian Pshyk\n2048",
                //TextColor = Color.Yellow,
                //FontSize = 50,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontAttributes = FontAttributes.Italic,
            };
            lb.FormattedText = formattedString;

            Title = "2048";
            Button toCommonPageBtn = new Button
            {
                Text = "Play",
                TextColor = Color.Blue,
                HeightRequest = 70,
                WidthRequest = 200,
                BackgroundColor = Color.Yellow,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            toCommonPageBtn.Clicked += ToCommonPage;

            
            Content = new StackLayout { Children = {lb,  toCommonPageBtn}, BackgroundColor = Color.Orange };
           
        }

        private async void ToCommonPage(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    Matrix.A[i, j] = 0;
                    Matrix.oldA[i, j] = 0;
                    Matrix.newRec = 0;
                    Matrix.oldnewRec = 0;

                    MainPage.listBox[i, j].Color = Color.White;
                    MainPage.listLabel[i, j].Text = "";
                }
            Matrix.CreateSquare();
            Matrix.CreateSquare();
        }

    }
}
