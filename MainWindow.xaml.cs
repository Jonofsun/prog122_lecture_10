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

namespace prog122_lecture_10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /* Datetime
         *
         *
         */

        const int ageToDrive = 16;
        const int ageToVote = 18;
        const int ageToDrink = 21;
        public MainWindow()
        {
            InitializeComponent();

            BlogPost bp = new BlogPost("header 1", "value 2");

            //DateTime dateTime = new DateTime(2023, 2, 15);
            //dateTime.AddMonths(7);
            DateTime dateTime = DateTime.Now;
            string shortTime = dateTime.ToShortTimeString();
            string longTime = dateTime.ToLongTimeString();

            string formatString = $"Short Time: {shortTime}\n" +
                $"Long time: {longTime}\n" +
                $"Short Day: {dateTime.ToShortDateString()}\n" +
                $"Long Date: {dateTime.ToLongDateString()}\n" +
                $"Year: {dateTime.Year}\n" +
                $"Day of the Week: {dateTime.DayOfWeek}";

            DateTime nowPlusTime = dateTime.AddMonths(7);

            TimeSpan differenceInDays = nowPlusTime - dateTime;

            rtbRunDisplay.Text = differenceInDays.ToString(); // deviding make sure its a double
        }

        private void btnDisplayTime_Click(object sender, RoutedEventArgs e)
        {

            DateTime birthDay = BirthdayObject();

            rtbRunDisplay.Text = $"Your birthday is {birthDay}";
        }

        public DateTime BirthdayObject()
        {
            int day = int.Parse(txtDay.Text);
            int month = int.Parse(txtMonth.Text);
            int year = int.Parse(txtYear.Text);

            return new DateTime(year, month, day);
        }

        private void btnDrivers_Click(object sender, RoutedEventArgs e)
        {
            DateTime bday= BirthdayObject();
            DateTime now = DateTime.Now;
            TimeSpan ageInDays = now - bday;
            int age = (int)(ageInDays.Days / 365.25);

            rtbRunDisplay.Text = $"You are {age.ToString()} years old";

            if (age >= ageToDrive)
            {
                rtbRunDisplay.Text += "you can drive";
            }
            else if (age >= ageToVote)
            {
                rtbRunDisplay.Text += "you can vote and drive";
            }
            else if (age >= ageToDrink)
            {
                rtbRunDisplay.Text += "you can drink, vote, and drive";
            }
        }

        private void btnResults_Click(object sender, RoutedEventArgs e)
        {
            /*DateTime selectedDate = calDate.SelectedDate.Value; *///dpDate

            if(calDate.SelectedDate.HasValue)
            {
                rtbRunDisplay.Text = (calDate.SelectedDate.Value.ToString());
                
            }
            else
            {
                rtbRunDisplay.Text = DateTime.Now.ToString();
            }

            //rtbRunDisplay.Text = (selectedDate.ToString());
        }
    }
}
