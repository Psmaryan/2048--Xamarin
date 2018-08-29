using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public class ValRec : INotifyPropertyChanged
    {
        private int valueRecord;

        public int ValueRecord
        {
            get { return valueRecord; }
            set
            {
                if (valueRecord != value)
                {
                    valueRecord = value;
                    OnPropertyChanged("ValueRecord");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    public static class Matrix
    {
        static Matrix()
        {
            A = new int[4, 4] { {0, 0, 0, 0 }, { 0, 0, 0, 0}, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }};
            newRec = 0;
            oldA = new int[4, 4] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
            oldnewRec = 0;
        }
        public static int[,] A;
        public static int newRec;

        public static int[,] oldA;
        public static int oldnewRec;

        public static void CreateSquare()
        {
            int count = 0;
            var freeElement = new List<int>();
            foreach (int a in A)
            {
                if (a == 0)
                    freeElement.Add(count);
                ++count;
            }
            if (freeElement.Count == 0)
                return;

            Random random = new Random();
            int addValue;
            if (random.Next(4) != 1)
                addValue = 2;
            else
                addValue = 4;

            count = freeElement[random.Next(freeElement.Count)];

            A[count / 4, count % 4] = addValue;
            Action.CreatSquare((int)(count % 4), (int)(count / 4), addValue, false);
        }

        public static void MoveSquareVertical(Grid grid, int posColumn, int fromRow, int toRow, int value, bool increaseTwice)
        {
            Action.MoveSquareVertical2(grid, posColumn, fromRow, toRow, value, increaseTwice);

            A[fromRow, posColumn] = 0;

            if (!increaseTwice)
                A[toRow, posColumn] = value;
            else
            {
                if (fromRow != toRow)
                    A[toRow, posColumn] = value * 2;
                else
                    A[toRow, posColumn] = value;
            }
        }

        public static void MoveSquareHorizontal(Grid grid, int fromColumn, int toColumn, int posRow, int value, bool increaseTwice)
        {
            Action.MoveSquareHorizontal2(grid, fromColumn, toColumn, posRow, value, increaseTwice);

            //A[fromColumn, posRow] = 0;
            A[posRow, fromColumn] = 0;

            if (!increaseTwice)
                A[posRow, toColumn] = value;
            else
            {
                if (fromColumn != toColumn)
                    A[posRow, toColumn] = value * 2;
                else
                    A[posRow, toColumn] = value;
            }
        }

        private static void GetColor(Grid grid)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    Label lb = new Label()
                    {
                        Text = "" + A[i, j].ToString(),
                        WidthRequest = 70,
                        HeightRequest = 70,
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                        TextColor = Color.Black,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    };
                    BoxView bx = new BoxView() { Color = Action.GetColorValue(A[i, j]) };
                    
                    grid.Children.Add(bx, j, i);
                    grid.Children.Add(lb, j, i);
                }
        }

        public static void GoToRight(Grid grid)
        {
            SaveOld();
            int count = 0;
            for (int k = 3; k >= 0; k--)
            {
                for (int j = 0; j < 4; j++)
                {
                    int i = k - 1;
                    while (i >= 0)
                    {
                        if (A[j, i] == 0)
                        {
                            --i;
                           // continue;
                        }
                        else
                        {

                            if (A[j, k] == 0)
                            {
                                MoveSquareHorizontal(grid, i, k, j, A[j, i], false);
                                ++count;
                            }
                            else
                            {
                                if (A[j, k] == A[j, i])
                                {
                                    MoveSquareHorizontal(grid, i, k, j, A[j, i], true);
                                    newRec += (A[j, k]);
                                    ++count;
                                }
                                else
                                {
                                    MoveSquareHorizontal(grid, i, k - 1, j, A[j, i], false);
                                    if (i != k - 1)
                                        count++;
                                }
                                break;
                            }
                            
                        }
                    }
                }
            }

            if(count != 0)
                Device.StartTimer(TimeSpan.FromMilliseconds(200), OnTimerTick);

            bool OnTimerTick()
            {
                CreateSquare();
             //   GetColor(grid);
                return false;
            }
        }

        public static void GoToLeft(Grid grid)
        {
            SaveOld();
            int count = 0;
            for (int k = 0; k <= 3; k++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int i = k + 1;
                    while (i <= 3)
                    {
                        if (A[j, i] == 0)
                        {
                            ++i;
                            // continue;
                        }
                        else
                        {

                            if (A[j, k] == 0)
                            {
                                MoveSquareHorizontal(grid, i, k, j, A[j, i], false);
                                ++count;
                                
                            }
                            else
                            {
                                if (A[j, k] == A[j, i])
                                {
                                    MoveSquareHorizontal(grid, i, k, j, A[j, i], true);
                                    newRec += (A[j, k]);
                                    ++count;
                                }
                                else
                                {
                                    MoveSquareHorizontal(grid, i, k + 1, j, A[j, i], false);
                                    if (i != k + 1)
                                        count++;
                                }
                                break;
                            }

                        }
                    }
                }
            }

            if (count != 0)
                Device.StartTimer(TimeSpan.FromMilliseconds(200), OnTimerTick);

            bool OnTimerTick()
            {
                CreateSquare();
              //  GetColor(grid);
                return false;
            }
        }

        public static void GoToUp(Grid grid)
        {
            SaveOld();
            int count = 0;
            for (int k = 0; k <= 3; k++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int i = k + 1;
                    while (i <= 3)
                    {
                        if (A[i, j] == 0)
                        {
                            ++i;
                            // continue;
                        }
                        else
                        {

                            if (A[k, j] == 0)
                            {
                               // MoveSquareHorizontal(grid, i, k, j, A[j, i], false);
                                MoveSquareVertical(grid, j, i, k, A[i, j], false);
                                ++count;
                            }
                            else
                            {
                                if (A[k, j] == A[i, j])
                                {
                                    MoveSquareVertical(grid, j, i, k, A[i, j], true);
                                    newRec += (A[k, j]);
                                    ++count;
                                }
                                else
                                {
                                    MoveSquareVertical(grid, j, i, k + 1, A[i, j], false);
                                    if (i != k + 1)
                                        count++;
                                }
                                break;
                            }

                        }
                    }
                }
            }

            if (count != 0)
                Device.StartTimer(TimeSpan.FromMilliseconds(200), OnTimerTick);

            bool OnTimerTick()
            {
                CreateSquare();
                //  GetColor(grid);
                return false;
            }
        }

        public static void GoToDown(Grid grid)
        {
            SaveOld();
            int count = 0;
            for (int k = 3; k >= 0; k--)
            {
                for (int j = 0; j < 4; j++)
                {
                    int i = k - 1;
                    while (i >= 0)
                    {
                        if (A[i, j] == 0)
                        {
                            --i;
                            // continue;
                        }
                        else
                        {

                            if (A[k, j] == 0)
                            {
                                // MoveSquareHorizontal(grid, i, k, j, A[j, i], false);
                                MoveSquareVertical(grid, j, i, k, A[i, j], false);
                                ++count;
                            }
                            else
                            {
                                if (A[k, j] == A[i, j])
                                {
                                    MoveSquareVertical(grid, j, i, k, A[i, j], true);
                                    newRec += (A[k, j]);
                                    ++count;
                                }
                                else
                                {
                                    MoveSquareVertical(grid, j, i, k - 1, A[i, j], false);
                                    if (i != k - 1)
                                        count++;
                                }
                                break;
                            }

                        }
                    }
                }
            }

            if (count != 0)
                Device.StartTimer(TimeSpan.FromMilliseconds(200), OnTimerTick);

            bool OnTimerTick()
            {
                CreateSquare();
                return false;
            }
        }

       
        public static Task<bool> isGameOverAsync()
        {
            return Task.Run(() =>
           {
              
               bool isGO = true;
               foreach (int a in A)
               {
                   if (a == 0)
                       isGO = false;
               }

               for (int i = 0; i < 4; i++)
                   for (int j = 0; j < 4; j++)
                   {
                       if (i > 0)
                           if (A[i - 1, j] == A[i, j])
                               isGO = false;

                       if (i < 3)
                           if (A[i + 1, j] == A[i, j])
                               isGO = false;

                       if (j > 0)
                           if (A[i, j - 1] == A[i, j])
                               isGO = false;

                       if (j < 3)
                           if (A[i, j + 1] == A[i, j])
                               isGO = false;
                   }

              

               if (isGO)
                   Thread.Sleep(800);

               return isGO;
           });
        }

       

        private static bool isEquall()
        {
            bool isEq = true;

            int count = 0;
            foreach (int olda in oldA)
                count += olda;
            isEq = count == 0;

            if(!isEq)
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (A[i, j] != oldA[i, j])
                            isEq = false;
                    }
                }


            return isEq;
        }
        public static void Back()
        {
            if (!isEquall())
            {
               // newRec = oldnewRec;
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        A[i, j] = oldA[i, j];

                Action.BackTo();
            }
        }

        public static void SaveOld()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    oldA[i, j] = A[i, j];
                    Action.oldA[i, j] = A[i, j];
                }
            oldnewRec = newRec;
        }
    }
}
