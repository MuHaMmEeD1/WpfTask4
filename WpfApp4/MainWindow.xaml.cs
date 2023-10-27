using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
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

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window , INotifyPropertyChanged
    {
        private List<MyMesseg> m1 = new List<MyMesseg>();

        public List<MyMesseg> m { get => m1; set { m1 = value; OnPropoytyChange(); } }
        public MainWindow()
        {

            m = JsonSerializer.Deserialize<List<MyMesseg>>(File.ReadAllText("../../../mes.json"));

            InitializeComponent();



           


            DataContext = this;

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropoytyChange([CallerMemberName] string name = null)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {

            if(textBox.Text.Length != 0)
            {
                m.Add(new MyMesseg() { messeg = $" {textBox.Text} ", time = DateTime.Now });


                textBox.Text = "";
                OnPropoytyChange(nameof(m));

                File.WriteAllText("../../../mes.json", JsonSerializer.Serialize(m, new JsonSerializerOptions() { WriteIndented = true }));

                MainWindow yeniSayfa = new MainWindow();
                yeniSayfa.Show();
                this.Close();
            }



        }
    }
}
