using System;
using System.Windows;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using static WhileSyntaxChecker.TemplateChecker;

namespace WhileSyntaxChecker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(string.IsNullOrWhiteSpace(textBox.Text) ^ string.IsNullOrWhiteSpace(pathBox.Text)))
                    throw new InvalidOperationException("Only one text box could be filled");

                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    TryCheck(textBox.Text, out string message);

                    MessageBox.Show(message);
                }

                if (!string.IsNullOrWhiteSpace(pathBox.Text))
                {
                    var allText = File.ReadAllText(pathBox.Text);

                    if (Regex.Matches(allText, "while").Count > 1)
                        throw new InvalidOperationException("Chosen file should contain only one operator");

                    var start = allText.IndexOf("while");
                    var finish = allText.LastIndexOf("}");

                    var operation = allText.Substring(start, finish - start + "while".Length);
                    TryCheck(operation, out string message);

                    using (var writer = new StreamWriter(pathBox.Text, append: true))
                    {
                        writer.Write(message);
                    }

                    MessageBox.Show("The result has been written to a file");
                }
            }
            catch (InvalidOperationException exception) when (exception.Message == "Only one text box could be filled")
            {
                MessageBox.Show(exception.Message);
                textBox.Text = string.Empty;
                pathBox.Text = string.Empty;
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
