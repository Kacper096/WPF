using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using NorthView;
using System.Threading.Tasks;

namespace DapperDatabase
{
    
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            LimitCharCreateCustomer();
            CustomerViewModel customerViewModel = new NorthView.CustomerViewModel();
            this.DataContext = customerViewModel;
            
        }
        /// <summary>
        /// Shows / hides submenu Customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerButton_Click(object sender, RoutedEventArgs e)
        {
            foreach(var item in Button_Bar.Children)
            {
                if (item is Button button)
                    if (button.Name.Contains("Customer") )
                        if(SubMenuCustomerButton.Visibility.HasFlag(Visibility.Collapsed))                    
                            SubMenuCustomerButton.Visibility = Visibility.Visible;
                        else SubMenuCustomerButton.Visibility = Visibility.Collapsed;
                    

            }
        }

        /// <summary>
        /// Views Customer Data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowData_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                OrdersData.Visibility = Visibility.Collapsed;
                CustomersData.Visibility = Visibility.Visible;

                var cust = new CustomerView();
                if (button.Content.ToString().Contains("Details"))
                {
                    CustomersData.DataContext = cust.Customers;
                    button.Content = "View";
                }
                else
                {
                    CustomersData.DataContext = cust.CustomerHeaders;
                    button.Content = "See Details";
                }
            }
           
        }

        /// <summary>
        /// Sliding Menu Panel By Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void show_Click(object sender, RoutedEventArgs e)
        {
            if (show.Content.ToString().Contains("Show"))
            {
                ShowMenu("showLeftMenu", show, Button_Bar);
            }
            else
            {
                if (sender is Button button)
                {
                    if (button.Content.ToString().Contains("Create"))
                        if(RightMenu.Margin.Right.CompareTo(0).ToString().Contains("0"))
                        {
                            ShowMenu("hideRightMenu", button, RightMenu);
                        }
                        else
                            ShowMenu("showRightMenu", button, RightMenu);
                    else
                        ShowMenu("hideLeftMenu", show, Button_Bar);
                }
            }
        }
        /// <summary>
        /// Slide the Menu Panel
        /// </summary>
        /// <param name="storyBoard"></param>
        /// <param name="showBT"></param>
        /// <param name="panel"></param>
        private void ShowMenu(string storyBoard, Button showBT, StackPanel panel)
        {
            Storyboard sb = Resources[storyBoard] as Storyboard;
            sb.Begin(panel);             
        }
        /// <summary>
        /// Sliding Menu Panel Ends Animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sb_Completed(object sender, System.EventArgs e)
        {
            if (show.Content.ToString().Contains("Show"))
                show.Content = "Hide";
            else
                show.Content = "Show";
        }
        /// <summary>
        /// Limitation in Customer Form
        /// </summary>
        private void LimitCharCreateCustomer()
        {
            var children = CreateCustomer.Children;
            foreach (var item in children)
            {
                if (item.GetType().Name.Contains("TextBox"))
                {
                    if (item is TextBox textBox)
                    {
                        textBox.MaxLines = 1;
                        textBox.MaxLength = 50;
                        textBox.MaxWidth = 262;
                        textBox.MinWidth = 262;
                        textBox.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
                        textBox.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
                        textBox.Text = "Enter...";
                        textBox.TextAlignment = TextAlignment.Center;
                        textBox.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0))
                        {
                            Opacity = 0.65
                        };
                        textBox.GotFocus += TextBox_GotFocus;
                    }
                }
            }
            
        }
        /// <summary>
        /// Clear default textBox text in CustomerForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if(sender is TextBox textBox)
            {
                textBox.Text = string.Empty;
                textBox.TextAlignment = TextAlignment.Left;
                textBox.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0))
                {
                    Opacity = 1
                };
            }
        }
  
    }
}
