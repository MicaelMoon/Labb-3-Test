using Labb_3.Windows;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
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
using Newtonsoft.Json;
using Labb_3.Models;

namespace Labb_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Quiz> quizList = new List<Quiz>();
        public static List<Question> questionList = new List<Question>();

        private TextBox statment;
        private TextBox answer1Text;
        private TextBox answer2Text;
        private TextBox answer3Text;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        public void CreateQuestionsAndLists()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string searchPattern = "*.json";
            string[] questionArray = Directory.GetFiles(baseDirectory, searchPattern);

            for (int i = 0; i < questionArray.Length; i++)  //Will most likley need a try catch later.
            {
                if (questionArray[i].Contains("isQuestion"))
                {
                    Question jToC = JsonConvert.DeserializeObject<Question>(questionArray[i]);
                    questionList.Add(jToC);
                }
                else
                {
                    Quiz jToC = JsonConvert.DeserializeObject<Quiz>(questionArray[i]);
                    quizList.Add(jToC);
                }
            }
        }

        public void CreateQuizGrid()
        {
            MainGrid.Children.Clear();
            MainGrid.RowDefinitions.Clear();
            MainGrid.ColumnDefinitions.Clear();

            MainGrid.ShowGridLines = true;

            for (int i = 0; i < 8; i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                MainGrid.ColumnDefinitions.Add(column);

                if (i == 0 || i == 7)
                {
                    column.Width = new GridLength(21);
                }
                else
                {
                    column.Width = new GridLength(200, GridUnitType.Pixel); // When set to (* / Star) they become really small for some reason
                }
            }

            for (int i = 0;i < 9;i++)
            {
                RowDefinition row = new RowDefinition();
                MainGrid.RowDefinitions.Add(row);

                if (i == 0 || i == 8)
                {
                    row.Height = new GridLength(20, GridUnitType.Pixel);
                }
                else if (i == 2)
                {
                    row.Height = new GridLength(50, GridUnitType.Pixel);
                }
                else if (i == 7)
                {
                    row.Height = new GridLength(0, GridUnitType.Auto);
                }
                else
                {
                    row.Height = new GridLength(0, GridUnitType.Auto);
                }
            }

            TextBlock title = new TextBlock();
            MainGrid.Children.Add(title);
            title.SetValue(Grid.RowProperty,1);
            title.SetValue(Grid.ColumnProperty, 2);
            title.SetValue(Grid.ColumnSpanProperty, 4);
            title.Text = "Create your question";
            title.FontSize = 80;
            title.Height = 100;


            TextBlock question = new TextBlock();
            MainGrid.Children.Add(question);
            question.Text = "Question: ";
            question.SetValue(Grid.RowProperty, 3);
            question.SetValue(Grid.ColumnProperty, 1);
            question.FontSize = 50;
            question.Height = 70;

            TextBlock answer1 = new TextBlock();
            MainGrid.Children.Add(answer1);
            answer1.Text = "Answer 1: ";
            answer1.SetValue(Grid.RowProperty, 4);
            answer1.SetValue(Grid.ColumnProperty, 1);
            answer1.FontSize = 50;
            answer1.Height = 70;

            TextBlock answer2 = new TextBlock();
            MainGrid.Children.Add(answer2);
            answer2.Text = "Answer 2: ";
            answer2.SetValue(Grid.RowProperty, 5);
            answer2.SetValue(Grid.ColumnProperty, 1);
            answer2.FontSize = 50;
            answer2.Height = 70;

            TextBlock answer3 = new TextBlock();
            MainGrid.Children.Add(answer3);
            answer3.Text = "Answer 3: ";
            answer3.SetValue(Grid.RowProperty, 6);
            answer3.SetValue(Grid.ColumnProperty, 1);
            answer3.FontSize = 50;
            answer3 .Height = 70;


            statment = new TextBox();
            MainGrid.Children.Add(statment);
            statment.SetValue(Grid.RowProperty, 3);
            statment.SetValue(Grid.ColumnProperty, 2);
            statment.SetValue(Grid.ColumnSpanProperty, 3);
            statment.FontSize = 30;
            statment.Width = 700;
            statment.Height = 40;

            answer1Text = new TextBox();
            MainGrid.Children.Add(answer1Text);
            answer1Text.SetValue(Grid.RowProperty, 4);
            answer1Text.SetValue(Grid.ColumnProperty, 2);
            answer1Text.SetValue(Grid.ColumnSpanProperty, 3);
            answer1Text.FontSize = 30;
            answer1Text.Width = 700;
            answer1Text.Height = 40;

            answer2Text = new TextBox();
            MainGrid.Children.Add(answer2Text);
            answer2Text.SetValue(Grid.RowProperty, 5);
            answer2Text.SetValue(Grid.ColumnProperty, 2);
            answer2Text.SetValue(Grid.ColumnSpanProperty, 3);
            answer2Text.FontSize = 30;
            answer2Text.Width = 700;
            answer2Text.Height = 40;

            answer3Text = new TextBox();
            MainGrid.Children.Add(answer3Text);
            answer3Text.SetValue(Grid.RowProperty, 6);
            answer3Text.SetValue(Grid.ColumnProperty, 2);
            answer3Text.SetValue(Grid.ColumnSpanProperty, 3);
            answer3Text.FontSize = 30;
            answer3Text.Width = 700;
            answer3Text.Height = 40;

            Button submitButton = new Button
            {
                Content = "Submit",
                Width = 180,
                Height = 100,
            };
            MainGrid.Children.Add(submitButton);
            submitButton.SetValue(Grid.RowProperty, 7);
            submitButton.SetValue(Grid.ColumnProperty, 5);
            submitButton.SetValue(Grid.RowSpanProperty, 2);
            submitButton.Click += SubmitButton_Click;

            Button backButton = new Button
            {
                Content = "Back",
                Width = 180,
                Height = 100,
            };
            MainGrid.Children.Add(backButton);
            backButton.SetValue(Grid.RowProperty, 7);
            backButton.SetValue(Grid.ColumnProperty, 3);
            backButton.SetValue(Grid.RowSpanProperty, 2);

        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string[] answers = new string[] {answer1Text.Text, answer2Text.Text, answer3Text.Text };
            //Question question = new Question(statment.Text, answers, );
        }

        private void Start_Quiz_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_Quiz_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Create_Quiz_Click(object sender, RoutedEventArgs e)
        {
            CreateQuizGrid();

            
           
        }
    }
}
