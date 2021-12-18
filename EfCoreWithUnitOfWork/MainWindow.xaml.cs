using EfCoreWithUnitOfWork.DAL.Context;
using EfCoreWithUnitOfWork.Unit_Of_Work;
using EfCoreWithUnitOfWork.Unit_Of_Work.Concrete;
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

namespace EfCoreWithUnitOfWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IUnitOfWork _unitOfWork;
        public MainWindow()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork(new ProductContext());
        }
    }
}
