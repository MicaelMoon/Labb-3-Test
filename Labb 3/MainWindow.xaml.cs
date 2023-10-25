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
            for (int i = 0; i < 10; i++)
            {
                ColumnDefinition column = new ColumnDefinition();

                if (i == 0 || i == 9)
                {
                    column.Width = new GridLength(10);
                    MainGrid.ColumnDefinitions.Add(column);
                }
                else
                {
                    column.Width = new GridLength(0, GridUnitType.Star);
                    MainGrid.ColumnDefinitions.Add(column);
                }
            }

            for (int i = 0;i < 7;i++)
            {
                RowDefinition row = new RowDefinition();

                if (i == 0 || i == 6)
                {
                    row.Height = new GridLength(10);
                    MainGrid.RowDefinitions.Add(row);
                }
                else if (i == 1)
                {
                    row.Height = new GridLength(0, GridUnitType.Pixel);
                    MainGrid.RowDefinitions.Add(row);
                }
                else if (i == 4)
                {
                    row.Height = new GridLength(150, GridUnitType.Pixel);
                    MainGrid.RowDefinitions.Add(row);
                }
                else
                {
                    row.Height = new GridLength(70, GridUnitType.Pixel);
                    MainGrid.RowDefinitions.Add(row);
                }
            }

            TextBlock title = new TextBlock();
            MainGrid.Children.Add(title);
            title.SetValue(Grid.RowProperty,1);
            title.SetValue(Grid.ColumnProperty, 1);
            title.SetValue(Grid.RowProperty, 1);
            title.SetValue(Grid.ColumnSpanProperty, 2);
            title.Text = "Create your question";
            title.FontSize = 80;
            title.Height = 100;
            MainGrid.ShowGridLines = true;

            TextBlock question = new TextBlock();
            MainGrid.Children.Add(question);
            question.Text = "Question: ";
            question.SetValue(Grid.RowProperty, 2);
            question.SetValue(Grid.ColumnProperty, 1);
            question.FontSize = 50;
            question.Height = 70;

            TextBlock answer1 = new TextBlock();
            MainGrid.Children.Add(answer1);
            answer1.Text = "Answer 1: ";
            answer1.SetValue(Grid.RowProperty, 3);
            answer1.SetValue(Grid.ColumnProperty, 1);
            answer1.FontSize = 50;
            answer1.Height = 70;

            TextBlock answer2 = new TextBlock();
            MainGrid.Children.Add(answer2);
            answer2.Text = "Answer 2: ";
            answer2.SetValue(Grid.RowProperty, 4);
            answer2.SetValue(Grid.ColumnProperty, 1);
            answer2.FontSize = 50;
            answer2.Height = 70;

            TextBlock answer3 = new TextBlock();
            MainGrid.Children.Add(answer3);
            answer3.Text = "Answer 2: ";
            answer3.SetValue(Grid.RowProperty, 5);
            answer3.SetValue(Grid.ColumnProperty, 1);
            answer3.FontSize = 50;
            answer3 .Height = 70;


            statment = new TextBox();
            MainGrid.Children.Add(statment);
            statment.SetValue(Grid.RowProperty, 2);
            statment.SetValue(Grid.ColumnProperty, 1);
            statment.SetValue(Grid.ColumnSpanProperty, 3);
            statment.FontSize = 30;
            statment.Width = 700;
            statment.Height = 40;

            answer1Text = new TextBox();
            MainGrid.Children.Add(answer1Text);
            answer1Text.SetValue(Grid.RowProperty, 3);
            answer1Text.SetValue(Grid.ColumnProperty, 1);
            answer1Text.SetValue(Grid.ColumnSpanProperty, 3);
            answer1Text.FontSize = 30;
            answer1Text.Width = 700;
            answer1Text.Height = 40;

            Button submitButton = new Button
            {
                Content = "Submit",
                Width = 40,
                Height = 30,
            };
            MainGrid.Children.Add(submitButton);
            submitButton.SetValue(Grid.RowProperty, 0);
            submitButton.SetValue(Grid.ColumnProperty, 0);
            submitButton.Click += SubmitButton_Click;

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
            MainGrid.Children.Clear();
            CreateQuizGrid();

            
           
        }
    }
}
