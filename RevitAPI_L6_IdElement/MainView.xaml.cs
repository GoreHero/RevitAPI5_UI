using Autodesk.Revit.UI;
using RevitAPI_L6I_dElement;
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

namespace RevitAPI_L6_IdElement
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView(ExternalCommandData commandData)
        {
            InitializeComponent();
            MainViewViewModel vm = new MainViewViewModel(commandData);
            vm.HideRequst+=(s, e) => this.Hide(); //Говорим что эвент HideRequst отвечает за скрытие окна
            vm.ShowRequst+=(s, e) => this.Show(); //Говорим что эвент ShowRequst отвечает за раскрытие окна
            DataContext = vm; //DataContext - свойство по которому можно найти например selectCommand
        }
    }
}
