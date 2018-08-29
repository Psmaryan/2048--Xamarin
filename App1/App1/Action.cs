using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1
{
    public class Action
    {
        static Action()
        {
            oldA = new int[4, 4] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
        }
        public static int[,] oldA;
        public static void MoveSquareHorizontal(Grid grid, int fromColumn, int toColumn, int posRow, int value, bool increaseTwice)
        {
                ///////////////////////////////////////
                const int time = 60;

                bool OnTimerTick3()
                {
                    // grid.Children.Add(new BoxView() { Color = Color.White }, fromColumn + 2 * Math.Sign(toColumn - fromColumn), posRow);


                    if (!increaseTwice)
                    {
                        //grid.Children.Add(bx, fromColumn + 3 * Math.Sign(toColumn - fromColumn), posRow);
                        //grid.Children.Add(lb, fromColumn + 3 * Math.Sign(toColumn - fromColumn), posRow);
                        MainPage.listBox[posRow, fromColumn + 3 * Math.Sign(toColumn - fromColumn)].Color = GetColorValue(value);
                        MainPage.listLabel[posRow, fromColumn + 3 * Math.Sign(toColumn - fromColumn)].Text = value.ToString();
                    }
                    else
                    {
                        CreatSquare(fromColumn + 3 * Math.Sign(toColumn - fromColumn), posRow, value * 2, true);
                    }

                    return false;
                }

                bool OnTimerTick2()
                {
                    //grid.Children.Add(new BoxView() { Color = Color.White }, fromColumn + 1 * Math.Sign(toColumn - fromColumn), posRow);


                    if (toColumn - 2 * Math.Sign(toColumn - fromColumn) - fromColumn != 0)
                        Device.StartTimer(TimeSpan.FromMilliseconds(time), OnTimerTick3);
                    else
                    {
                        if (!increaseTwice)
                        {
                            //grid.Children.Add(bx, fromColumn + 2 * Math.Sign(toColumn - fromColumn), posRow);
                            // grid.Children.Add(lb, fromColumn + 2 * Math.Sign(toColumn - fromColumn), posRow);
                            MainPage.listBox[posRow, fromColumn + 2 * Math.Sign(toColumn - fromColumn)].Color = GetColorValue(value);
                            MainPage.listLabel[posRow, fromColumn + 2 * Math.Sign(toColumn - fromColumn)].Text = value.ToString();
                        }
                        else
                            CreatSquare(fromColumn + 2 * Math.Sign(toColumn - fromColumn), posRow, value * 2, true);
                    }


                    return false;
                }

                bool OnTimerTick()
                {
                    //grid.Children.Add(new BoxView() { Color = Color.White }, fromColumn, posRow);
                    MainPage.listBox[posRow, fromColumn].Color = Color.White;

                    if (toColumn - fromColumn - 1 * Math.Sign(toColumn - fromColumn) != 0)
                        Device.StartTimer(TimeSpan.FromMilliseconds(time), OnTimerTick2);
                    else
                    {
                        if (!increaseTwice)
                        {
                            //---------------------

                            //----------------------
                            //grid.Children.Add(bx, fromColumn + 1 * Math.Sign(toColumn - fromColumn), posRow);
                            // grid.Children.Add(lb, fromColumn + 1 * Math.Sign(toColumn - fromColumn), posRow);
                            MainPage.listBox[posRow, fromColumn + 1 * Math.Sign(toColumn - fromColumn)].Color = GetColorValue(value);
                            MainPage.listLabel[posRow, fromColumn + 1 * Math.Sign(toColumn - fromColumn)].Text = value.ToString();

                        }
                        else
                        {
                            //  grid.Children.RemoveAt(0);
                            CreatSquare(fromColumn + 1 * Math.Sign(toColumn - fromColumn), posRow, value * 2, true);
                        }
                    }

                    return false;
                }

                if (toColumn != fromColumn)
                {
                    MainPage.listLabel[posRow, fromColumn].Text = "";
                    Device.StartTimer(TimeSpan.FromMilliseconds(time), OnTimerTick);
            }

            }

        public static void MoveSquareVertical(Grid grid, int posColumn, int fromRow, int toRow, int value, bool increaseTwice)
        {
            ////////////////////////////////////////////
            const int time = 60;

            bool OnTimerTick3()
            {
                // grid.Children.Add(new BoxView() { Color = Color.White }, posColumn, fromRow + 2 * Math.Sign(toRow - fromRow));


                if (!increaseTwice)
                {
                    //grid.Children.Add(bx, posColumn, fromRow + 3 * Math.Sign(toRow - fromRow));
                    //grid.Children.Add(lb, posColumn, fromRow + 3 * Math.Sign(toRow - fromRow));
                    MainPage.listBox[fromRow + 3 * Math.Sign(toRow - fromRow), posColumn].Color = GetColorValue(value);
                    MainPage.listLabel[fromRow + 3 * Math.Sign(toRow - fromRow), posColumn].Text = value.ToString();
                }
                else
                {
                    CreatSquare(posColumn, fromRow + 3 * Math.Sign(toRow - fromRow), value * 2, true);
                }


                return false;
            }

            bool OnTimerTick2()
            {
                // grid.Children.Add(new BoxView() { Color = Color.White }, posColumn, fromRow + 1 * Math.Sign(toRow - fromRow));


                if (toRow - 2 * Math.Sign(toRow - fromRow) - fromRow != 0)
                    Device.StartTimer(TimeSpan.FromMilliseconds(time), OnTimerTick3);
                else
                {
                    if (!increaseTwice)
                    {
                        //grid.Children.Add(bx, posColumn, fromRow + 2 * Math.Sign(toRow - fromRow));
                        //grid.Children.Add(lb, posColumn, fromRow + 2 * Math.Sign(toRow - fromRow));
                        MainPage.listBox[fromRow + 2 * Math.Sign(toRow - fromRow), posColumn].Color = GetColorValue(value);
                        MainPage.listLabel[fromRow + 2 * Math.Sign(toRow - fromRow), posColumn].Text = value.ToString();
                    }
                    else
                        CreatSquare(posColumn, fromRow + 2 * Math.Sign(toRow - fromRow), value * 2, true);
                }


                return false;
            }

            bool OnTimerTick()
            {

                //grid.Children.Add(new BoxView() { Color = Color.White }, posColumn, fromRow);
                MainPage.listBox[fromRow, posColumn].Color = Color.White;

                if (toRow - fromRow - 1 * Math.Sign(toRow - fromRow) != 0)
                    Device.StartTimer(TimeSpan.FromMilliseconds(time), OnTimerTick2);
                else
                {
                    if (!increaseTwice)
                    {
                        //grid.Children.Add(bx, posColumn, fromRow + 1 * Math.Sign(toRow - fromRow));
                        //grid.Children.Add(lb, posColumn, fromRow + 1 * Math.Sign(toRow - fromRow));
                        MainPage.listBox[fromRow + 1 * Math.Sign(toRow - fromRow), posColumn].Color = GetColorValue(value);
                        MainPage.listLabel[fromRow + 1 * Math.Sign(toRow - fromRow), posColumn].Text = value.ToString();
                    }
                    else
                        CreatSquare(posColumn, fromRow + 1 * Math.Sign(toRow - fromRow), value * 2, true);
                }


                return false;
            }

            if (toRow != fromRow)
            {
                MainPage.listLabel[fromRow, posColumn].Text = "";
                Device.StartTimer(TimeSpan.FromMilliseconds(time), OnTimerTick);
            }

        }
        public static Color GetColorValue(int value)
        {
            switch (value)
            {
                case 0:
                    return Color.White;
                case 2:
                    return Color.FromHex("#FBE9E8");
                case 4:
                    return Color.FromHex("#FFCCBC");
                case 8:
                    return Color.FromHex("#FFAB91");
                case 16:
                    return Color.FromHex("#FF7043");
                case 32:
                    return Color.FromHex("#FF5722");
                case 64:
                    return Color.FromHex("#D84315");
                case 128:
                    return Color.FromHex("#FFF59D");
                case 256:
                    return Color.FromHex("#FFF176");
                case 512:
                    return Color.FromHex("#FFEE58");
                case 1024:
                    return Color.FromHex("#FFEB3B");
                case 2048:
                    return Color.FromHex("#FFB300");
                default:
                    return Color.FromHex("#616161");
            }
        }


        public static void CreatSquare(int posColumn, int posRow, int value, bool increaseTwice)
        {
          
            if (value == 0)
                MainPage.listLabel[posRow, posColumn].Text = "";

            bool OnTimerTick()
            {
                MainPage.listBox[posRow, posColumn].ScaleTo(1);
                MainPage.listLabel[posRow, posColumn].ScaleTo(1);

                return false;
            }

            MainPage.listLabel[posRow, posColumn].Text = value.ToString();
            MainPage.listBox[posRow, posColumn].Color = GetColorValue(value);

            if (increaseTwice)
            {
                MainPage.listBox[posRow, posColumn].ScaleTo(0.1);
                MainPage.listLabel[posRow, posColumn].ScaleTo(0.1);
                Device.StartTimer(TimeSpan.FromMilliseconds(100), OnTimerTick);
            }
            else
            {
                MainPage.listBox[posRow, posColumn].ScaleTo(0.1, length: 10);
                MainPage.listLabel[posRow, posColumn].ScaleTo(0.1, length: 10);
                Device.StartTimer(TimeSpan.FromMilliseconds(10), OnTimerTick);
            }
           // grid.Children.Add(bx, posColumn, posRow);
           // grid.Children.Add(lb, posColumn, posRow);

        }



        public static void MoveSquareHorizontal2(Grid grid, int fromColumn, int toColumn, int posRow, int value, bool increaseTwice)
        {
            const int time = 1;
           
            void OnTimerTick3()
            {
               // grid.Children.Add(new BoxView() { Color = Color.White }, fromColumn + 2 * Math.Sign(toColumn - fromColumn), posRow);


                if (!increaseTwice)
                {
                    //grid.Children.Add(bx, fromColumn + 3 * Math.Sign(toColumn - fromColumn), posRow);
                    //grid.Children.Add(lb, fromColumn + 3 * Math.Sign(toColumn - fromColumn), posRow);
                    MainPage.listBox[posRow, fromColumn + 3 * Math.Sign(toColumn - fromColumn)].Color = GetColorValue(value);
                    MainPage.listLabel[posRow, fromColumn + 3 * Math.Sign(toColumn - fromColumn)].Text = value.ToString();
                }
                else
                {
                    CreatSquare(fromColumn + 3 * Math.Sign(toColumn - fromColumn), posRow, value * 2, true);
                }

                return;
            }

            void OnTimerTick2()
            {
                //grid.Children.Add(new BoxView() { Color = Color.White }, fromColumn + 1 * Math.Sign(toColumn - fromColumn), posRow);


                if (toColumn - 2 * Math.Sign(toColumn - fromColumn) - fromColumn != 0)
                    OnTimerTick3();
                else
                {
                    if (!increaseTwice)
                    {
                        //grid.Children.Add(bx, fromColumn + 2 * Math.Sign(toColumn - fromColumn), posRow);
                       // grid.Children.Add(lb, fromColumn + 2 * Math.Sign(toColumn - fromColumn), posRow);
                        MainPage.listBox[posRow, fromColumn + 2 * Math.Sign(toColumn - fromColumn)].Color = GetColorValue(value);
                        MainPage.listLabel[posRow, fromColumn + 2 * Math.Sign(toColumn - fromColumn)].Text = value.ToString();
                    }
                    else
                        CreatSquare(fromColumn + 2 * Math.Sign(toColumn - fromColumn), posRow, value * 2, true);
                }


                return;
            }

            void OnTimerTick()
            {
               //grid.Children.Add(new BoxView() { Color = Color.White }, fromColumn, posRow);
                MainPage.listBox[posRow, fromColumn].Color = Color.White;

                if (toColumn - fromColumn - 1 * Math.Sign(toColumn - fromColumn) != 0)
                    OnTimerTick2();
                else
                {
                    if (!increaseTwice)
                    {
                        //---------------------

                        //----------------------
                       //grid.Children.Add(bx, fromColumn + 1 * Math.Sign(toColumn - fromColumn), posRow);
                       // grid.Children.Add(lb, fromColumn + 1 * Math.Sign(toColumn - fromColumn), posRow);
                        MainPage.listBox[posRow, fromColumn + 1 * Math.Sign(toColumn - fromColumn)].Color = GetColorValue(value);
                        MainPage.listLabel[posRow, fromColumn + 1 * Math.Sign(toColumn - fromColumn)].Text = value.ToString();

                    }
                    else
                    {
                        //  grid.Children.RemoveAt(0);
                        CreatSquare(fromColumn + 1 * Math.Sign(toColumn - fromColumn), posRow, value * 2, true);
                    }
                }

                return;
            }

            if (toColumn != fromColumn)
            {
                MainPage.listLabel[posRow, fromColumn].Text = "";
                OnTimerTick();
            }
        }

        public static void MoveSquareVertical2(Grid grid, int posColumn, int fromRow, int toRow, int value, bool increaseTwice)
        {
            const int time = 1;
           
            void OnTimerTick3()
            {
               // grid.Children.Add(new BoxView() { Color = Color.White }, posColumn, fromRow + 2 * Math.Sign(toRow - fromRow));


                if (!increaseTwice)
                {
                    //grid.Children.Add(bx, posColumn, fromRow + 3 * Math.Sign(toRow - fromRow));
                    //grid.Children.Add(lb, posColumn, fromRow + 3 * Math.Sign(toRow - fromRow));
                    MainPage.listBox[fromRow + 3 * Math.Sign(toRow - fromRow), posColumn].Color = GetColorValue(value);
                    MainPage.listLabel[fromRow + 3 * Math.Sign(toRow - fromRow), posColumn].Text = value.ToString();
                }
                else
                {
                    CreatSquare(posColumn, fromRow + 3 * Math.Sign(toRow - fromRow), value * 2, true);
                }


                return;
            }

            void OnTimerTick2()
            {
               // grid.Children.Add(new BoxView() { Color = Color.White }, posColumn, fromRow + 1 * Math.Sign(toRow - fromRow));


                if (toRow - 2 * Math.Sign(toRow - fromRow) - fromRow != 0)
                    OnTimerTick3();
                else
                {
                    if (!increaseTwice)
                    {
                        //grid.Children.Add(bx, posColumn, fromRow + 2 * Math.Sign(toRow - fromRow));
                        //grid.Children.Add(lb, posColumn, fromRow + 2 * Math.Sign(toRow - fromRow));
                        MainPage.listBox[fromRow + 2 * Math.Sign(toRow - fromRow), posColumn].Color = GetColorValue(value);
                        MainPage.listLabel[fromRow + 2 * Math.Sign(toRow - fromRow), posColumn].Text = value.ToString();
                    }
                    else
                        CreatSquare( posColumn, fromRow + 2 * Math.Sign(toRow - fromRow), value * 2, true);
                }


                return;
            }

            void OnTimerTick()
            {

                //grid.Children.Add(new BoxView() { Color = Color.White }, posColumn, fromRow);
                MainPage.listBox[fromRow, posColumn].Color = Color.White;

                if (toRow - fromRow - 1 * Math.Sign(toRow - fromRow) != 0)
                    OnTimerTick2();
                else
                {
                    if (!increaseTwice)
                    {
                        //grid.Children.Add(bx, posColumn, fromRow + 1 * Math.Sign(toRow - fromRow));
                        //grid.Children.Add(lb, posColumn, fromRow + 1 * Math.Sign(toRow - fromRow));
                        MainPage.listBox[fromRow + 1 * Math.Sign(toRow - fromRow), posColumn].Color = GetColorValue(value);
                        MainPage.listLabel[fromRow + 1 * Math.Sign(toRow - fromRow), posColumn].Text = value.ToString();
                    }
                    else
                        CreatSquare(posColumn, fromRow + 1 * Math.Sign(toRow - fromRow), value * 2, true);
                }


                return;
            }

            if (toRow != fromRow)
            {
                MainPage.listLabel[fromRow, posColumn].Text = "";
                OnTimerTick();
            }
        }

        public static void BackTo()
        {
            int a = 4;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    a = Matrix.oldA[i, j];
                    MainPage.listLabel[i, j].Text = "";
                    if (Matrix.oldA[i, j] != 0)
                       MainPage.listLabel[i, j].Text = a.ToString();

                    MainPage.listBox[i, j].Color = GetColorValue(Matrix.oldA[i, j]);
                }
            }
        }

    }
}