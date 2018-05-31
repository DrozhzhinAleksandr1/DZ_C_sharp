using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Demo.Lesson20.wpf1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SQLiteConnection DB;
        public MainWindow()
        {
            InitializeComponent();
            Create15Btn();
            mixAllBtn();
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(MyTick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            DB = new SQLiteConnection("Data Source =../../bd/game.db");
            DB.Open();
        }
        int emptySlotCol = 3;
        int emptySlotRow = 3;
        int timeSecond = 0;
        int numberClick = 0;

        // class helper
        private class cellInfo
        {
            public int rowPosition;
            public int colPosition;
            public int btnNumber;
            public bool isEmpty;
            public cellInfo(int row, int col, int number, bool empty)
            {
                rowPosition = row;
                colPosition = col;
                btnNumber = number;
                isEmpty = empty;
            }
        }
        // arr with all cell info
        private List<cellInfo> allCellInfo = new List<cellInfo>();
        private List<Button> btn15 = new List<Button>();
        // create btn for game
        private void Create15Btn()
        {
            int number = 1;
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    if (!(i == 3 && j == 3))
                    {
                        allCellInfo.Add(new cellInfo(i, j, number, false));
                        // create btn
                        Button btn = new Button();
                        wrapper.Children.Add(btn);
                        btn.Content = number;
                        btn.Background = Brushes.DeepSkyBlue;
                        btn.Foreground = Brushes.White;
                        btn.Click += Button_Click;
                        btn.SetValue(Grid.RowProperty, i);
                        btn.SetValue(Grid.ColumnProperty, j);
                        btn15.Add(btn);
                        ++number;
                    }
                    else
                    {
                        allCellInfo.Add(new cellInfo(i, j, 0, true));
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs ev)
        {
            Button btn = sender as Button;

            int btnColumnProp = (int)btn.GetValue(Grid.ColumnProperty);
            int btnRowProp = (int)btn.GetValue(Grid.RowProperty);

            moveBtn(btn, btnColumnProp, btnRowProp);

            numberClickBtn.Text = $"number click: {++numberClick}";

            Win();

            //int x = (int)btn.GetValue(Grid.ColumnProperty);
            //int y = (int)btn.GetValue(Grid.RowProperty);

            //ThicknessAnimation animation = new ThicknessAnimation();

            //double btnWidth = btn.ActualWidth;
            //animation.From = new Thickness(10, 10, btnWidth + 20, 10);
            //animation.To = new Thickness(btnWidth + 20, 10, 10, 10);
            //animation.FillBehavior = FillBehavior.Stop;
            //animation.Duration = new Duration(TimeSpan.FromMilliseconds(500));
            //animation.Completed += (s, e) =>
            //{
            //btn.SetValue(Grid.ColumnProperty, 3);
            //};

            //btn.BeginAnimation(Button.MarginProperty, animation);
        }
        private void moveBtn(Button thisBtn, int thisBtnCol, int thisBtnRow)
        {
            int btnColumnProp = thisBtnCol;
            int btnRowProp = thisBtnRow;

            // проверка можно ли перемещать данную кнопку
            bool canPush;
            if (btnColumnProp - emptySlotCol == 0 && btnRowProp - emptySlotRow == 1 ||
                btnColumnProp - emptySlotCol == 0 && btnRowProp - emptySlotRow == -1 ||
                btnColumnProp - emptySlotCol == -1 && btnRowProp - emptySlotRow == 0 ||
                btnColumnProp - emptySlotCol == 1 && btnRowProp - emptySlotRow == 0)
            {
                canPush = true;
            }
            else canPush = false;

            if (canPush)
            {
                int nextCol = 0;
                int nextRow = 0;

                foreach (cellInfo item in allCellInfo)
                {
                    // Create new slot with number
                    if (item.isEmpty == true)
                    {
                        item.isEmpty = false;
                        item.btnNumber = (int)thisBtn.Content;

                        nextCol = item.colPosition;
                        nextRow = item.rowPosition;
                    }
                    // create new empty slot info
                    if (item.colPosition == btnColumnProp && item.rowPosition == btnRowProp)
                    {
                        item.btnNumber = 0;
                        item.isEmpty = true;
                        emptySlotCol = item.colPosition;
                        emptySlotRow = item.rowPosition;
                    }
                }
                // передвигаем кнопку
                thisBtn.SetValue(Grid.ColumnProperty, nextCol);
                thisBtn.SetValue(Grid.RowProperty, nextRow);
            }

        }

        private Button returnBtnIfCnowColRow(int col, int row)
        {
            foreach (Button btn in btn15)
            {
                if ((int)btn.GetValue(Grid.ColumnProperty) == col && (int)btn.GetValue(Grid.RowProperty) == row)
                {
                    return btn;
                }
            }
            return btn15[0];
        }
        private void mixAllBtn()
        {
            Random rand = new Random();
            for (int i = 0; i < 3; ++i)
            {
                int randInt = rand.Next(100);
                if (randInt <= 25)
                {
                    int col;
                    if (emptySlotCol + 1 < 3)
                        col = emptySlotCol + 1;
                    else
                        col = emptySlotCol - 1;
                    Button btn = returnBtnIfCnowColRow(col, emptySlotRow);
                    moveBtn(btn, col, emptySlotRow);
                }
                else if (randInt >= 26 && randInt <= 50)
                {
                    int col;
                    if (emptySlotCol - 1 >= 0)
                        col = emptySlotCol - 1;
                    else
                        col = emptySlotCol + 1;
                    Button btn = returnBtnIfCnowColRow(col, emptySlotRow);
                    moveBtn(btn, col, emptySlotRow);
                }
                else if (randInt >= 51 && randInt <= 75)
                {
                    int row;
                    if (emptySlotCol - 1 >= 0)
                        row = emptySlotCol - 1;
                    else
                        row = emptySlotCol + 1;
                    Button btn = returnBtnIfCnowColRow(emptySlotCol, row);
                    moveBtn(btn, emptySlotCol, row);
                }
                else
                {
                    int row;
                    if (emptySlotCol + 1 <= 3)
                        row = emptySlotCol + 1;
                    else
                        row = emptySlotCol - 1;
                    Button btn = returnBtnIfCnowColRow(emptySlotCol, row);
                    moveBtn(btn, emptySlotCol, row);
                }
            }
        }

        private void MyTick(object sender, EventArgs e)
        {
            timeText.Text = $"time second: {++timeSecond}";
        }
        private void GoMix()
        {
            mixAllBtn();
            timeSecond = 0;
            numberClick = 0;
            numberClickBtn.Text = $"number click: {numberClick}";
            timeText.Text = $"time second: {timeSecond}";
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GoMix();
        }
        private void AddToDb()
        {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "INSERT INTO game (seconds, click) VALUES(@sec, @num);";
            CMD.Parameters.Add("@sec", System.Data.DbType.Int32).Value = timeSecond;
            CMD.Parameters.Add("@num", System.Data.DbType.Int32).Value = numberClick;
            CMD.ExecuteNonQuery();
        }
        private void Win()
        {
            int i = 1;
            foreach (cellInfo item in allCellInfo)
            {
                if (i != item.btnNumber) return;
                if (i == 15)
                {
                    MessageBox.Show($"Congratulations your result - time second: {timeSecond}; number click: {numberClick}");
                    AddToDb();
                    GoMix();
                    return;
                }
                ++i;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DB.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SQLiteCommand CMD = DB.CreateCommand();
            //CMD.CommandText = "SELECT * FROM game";
            CMD.CommandText = "SELECT MIN(click) FROM game;";
            SQLiteDataReader SQL = CMD.ExecuteReader();
            if (SQL.HasRows)
            {
                SQL.Read();
                SQLiteCommand CMD2 = DB.CreateCommand();
                CMD2.CommandText = $"SELECT seconds FROM game WHERE click = {SQL[0]};";
                SQLiteDataReader SQL2 = CMD2.ExecuteReader();
                SQL2.Read();
                MessageBox.Show($"Best result - time second: {SQL2[0]}; number click: {SQL[0]}");                
            }
            else
            {
                MessageBox.Show("Результатов нет");
            }
        }
    }
}
