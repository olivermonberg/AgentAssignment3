using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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

namespace AgentAssignment3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        Clock clock = new Clock();

        public MainWindow()
        {
            InitializeComponent();

            spClock.DataContext = clock;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            clock.Update();
        }

        private void SortByComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Agent[] ag = ListBoxAgents.Items.Cast<Agent>().ToArray();

            ComboBoxItem _comboBoxItem = e.AddedItems[0] as ComboBoxItem;
            string sortBy;

            if (_comboBoxItem != null)
            {
                sortBy = _comboBoxItem.Tag.ToString();

                SortDescription sd = new SortDescription(sortBy, ListSortDirection.Ascending);
                ICollectionView cv = CollectionViewSource.GetDefaultView(DataContext);

                if (cv != null)
                {
                    cv.SortDescriptions.Clear();
                    if (sortBy != "None")
                        cv.SortDescriptions.Add(sd);
                }
            }
        }

        private void SortBySpecialityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem _comboBoxItem = e.AddedItems[0] as ComboBoxItem;

            ICollectionView cv = CollectionViewSource.GetDefaultView(ListBoxAgents);

        }
    }
}
