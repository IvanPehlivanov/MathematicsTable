using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MathematicsTable
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string[]> ArrCorrectValues { get; set; }
        public string[] Operator { get; set; }
        public List<string[]> ArrUserInput { get; set; }

        private readonly Calculations _calculations;

        private string mathFunction;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Operator = new string[] { "-", "+", "*", "/" };

            _calculations = new Calculations();

            ArrCorrectValues = new List<string[]>();
            ArrCorrectValues.Add(new string[] { "0", "0", "0", " 0", "0", "0", "0", "0", "0", "0" });
            ArrCorrectValues.Add(new string[] { "0", "0", "0", " 0", "0", "0", "0", "0", "0", "0" });
            ArrCorrectValues.Add(new string[] { "0", "0", "0", " 0", "0", "0", "0", "0", "0", "0" });
            ArrCorrectValues.Add(new string[] { "0", "0", "0", " 0", "0", "0", "0", "0", "0", "0" });
            ArrCorrectValues.Add(new string[] { "0", "0", "0", " 0", "0", "0", "0", "0", "0", "0" });
            ArrCorrectValues.Add(new string[] { "0", "0", "0", " 0", "0", "0", "0", "0", "0", "0" });
            ArrCorrectValues.Add(new string[] { "0", "0", "0", " 0", "0", "0", "0", "0", "0", "0" });
            ArrCorrectValues.Add(new string[] { "0", "0", "0", " 0", "0", "0", "0", "0", "0", "0" });
            ArrCorrectValues.Add(new string[] { "0", "0", "0", " 0", "0", "0", "0", "0", "0", "0" });
            ArrCorrectValues.Add(new string[] { "0", "0", "0", " 0", "0", "0", "0", "0", "0", "0" });


            ArrUserInput = new List<string[]>();
            ArrUserInput.Add(new string[] { "0", "0", "0", " 0", "0", "0", "0", "0", "0", "0" });
            ArrUserInput.Add(new string[] { "0", "0", "0", " 0", "0", "0", "0", "0", "0", "0" });
            ArrUserInput.Add(new string[] { "0", "0", "0", " 0", "0", "0", "0", "0", "0", "0" });
            ArrUserInput.Add(new string[] { "0", "0", "0", " 0", "0", "0", "0", "0", "0", "0" });
            ArrUserInput.Add(new string[] { "0", "0", "0", " 0", "0", "0", "0", "0", "0", "0" });
            ArrUserInput.Add(new string[] { "0", "0", "0", " 0", "0", "0", "0", "0", "0", "0" });
            ArrUserInput.Add(new string[] { "0", "0", "0", " 0", "0", "0", "0", "0", "0", "0" });
            ArrUserInput.Add(new string[] { "0", "0", "0", " 0", "0", "0", "0", "0", "0", "0" });
            ArrUserInput.Add(new string[] { "0", "0", "0", " 0", "0", "0", "0", "0", "0", "0" });
            ArrUserInput.Add(new string[] { "0", "0", "0", " 0", "0", "0", "0", "0", "0", "0" });


            DgUser.ItemsSource = ArrCorrectValues;
            Combo.ItemsSource = Operator;
        }

        private void Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            mathFunction = (sender as ComboBox).SelectedValue.ToString();
            ArrCorrectValues = _calculations.CalculateTable(mathFunction);
            myRandom();
            DgUser.ItemsSource = null;
            DgUser.ItemsSource = ArrCorrectValues;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Ok = MessageBox.Show("Are you want to close", "MathematicsTableZP", MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (Ok == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        public void myRandom()
        {
            Random ran = new Random();
            for (int i = 0; i < 4; i++)
            {
                int pp = ran.Next(9);
                int po = ran.Next(9);

                ArrCorrectValues[pp][po] = string.Empty;
            }
        }

        private void BtnCheckUserInput(object sender, RoutedEventArgs e)
        {
            ArrUserInput = DgUser.ItemsSource as List<string[]>;
            var wrongLines = CheckUserInput(ArrUserInput, mathFunction);
            if (wrongLines.Any())
            {
                MessageBox.Show($"Wrong value in{wrongLines.Count} line/s.");
                ColorRow(DgUser, wrongLines);
            }
            else
            {
                MessageBox.Show("All values are correct.");
            }
        }

        /// <summary>
        /// check if user input is correct
        /// </summary>
        /// <param name="userInput">user input value</param>
        /// <param name="correctValue">correct value</param>
        /// <returns>true if user input is correct</returns>
        internal List<int> CheckUserInput(List<string[]> userInput, string mathOp)
        {
            var correctValuesList = _calculations.CalculateTable(mathOp);
            return _calculations.CompareLists(correctValuesList, userInput);

        }

        private void ColorRow(DataGrid dg, List<int> linesToMark)
        {
            for (int i = 0; i < dg.Items.Count; i++)
            {
                //DataGridRow row = (DataGridRow) dg.ItemContainerGenerator.ContainerFromIndex(i);

                //    if (row != null)
                //    {
                //        int index = row.GetIndex();
                //        if (index % 2 == 0)
                //        {
                //            SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(100, 255, 104, 0));
                //            row.Background = brush;
                //        }
                //        else
                //        {
                //            SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(100, 255, 232, 0));
                //            row.Background = brush;
                //        }
                //    }
                //}

                foreach (var rowNumber in linesToMark)
                {
                    DataGridRow row = (DataGridRow)dg.ItemContainerGenerator.ContainerFromIndex(rowNumber);
                    if (row != null)
                    {
                        SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(100, 255, 104, 0));
                        row.Background = brush;
                    }
                }
            }
        }
    }
}
