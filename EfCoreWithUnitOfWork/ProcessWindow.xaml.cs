using EfCoreWithUnitOfWork.DAL.Context;
using EfCoreWithUnitOfWork.Entities;
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
using System.Windows.Shapes;

namespace EfCoreWithUnitOfWork
{
    /// <summary>
    /// Interaction logic for ProcessWindow.xaml
    /// </summary>
    public partial class ProcessWindow : Window
    {
        IUnitOfWork _unitOfWork;
        public Category Category { get; set; }
        public Product Product { get; set; }
        public ProcessWindow()
        {
            InitializeComponent();
            _unitOfWork = new UnitOfWork(new ProductContext());
            Category = new Category();
            Product = new Product();
        }

        private void btnCat_Click(object sender, RoutedEventArgs e)
        {
            if (btnCat.Content.ToString() == "Add")
            {
                if (txb_cName.Text != "")
                {
                    var catName = txb_cName.Text;
                    _unitOfWork.CategoryRepository.Add(new Category() { Name = catName });
                    _unitOfWork.Complete();
                    gridCategory.Visibility = Visibility.Hidden;
                    Close();
                }
                else
                    MessageBox.Show("Error!");
            }
            else
            {
                if (txb_cName.Text != "")
                {
                    Category!.Name = txb_cName.Text;
                    _unitOfWork.CategoryRepository.Update(Category);
                    _unitOfWork.Complete();
                    gridCategory.Visibility = Visibility.Hidden;
                    Close();
                }
                else
                    MessageBox.Show("Error!");
            }
        }

        private void btnProd_Click(object sender, RoutedEventArgs e)
        {
            if (btnProd.Content.ToString() == "Add")
            {
                if (txb_pName.Text != "" || txb_pPrice.Text != "" || txb_pCatId.Text != "")
                {
                    var pName = txb_pName.Text;
                    double pPrice = double.Parse(txb_pPrice.Text);
                    int pCatId = int.Parse(txb_pCatId.Text);
                    _unitOfWork.ProductRepository.Add(new Product() { Name = pName, UnitPrice = pPrice, CategoryId = pCatId });
                    _unitOfWork.Complete();
                    gridProduct.Visibility = Visibility.Hidden;
                    Close();
                }
                else
                    MessageBox.Show("Error!");
            }
            else
            {
                if (txb_pName.Text != "" || txb_pPrice.Text != "" || txb_pCatId.Text != "")
                {
                    Product!.Name = txb_pName.Text;
                    Product!.UnitPrice = double.Parse(txb_pPrice.Text);
                    Product!.CategoryId = int.Parse(txb_pCatId.Text);
                    Product!.Category = _unitOfWork.CategoryRepository.GetAll().FirstOrDefault(c => c.Id == Product!.CategoryId);
                    _unitOfWork.ProductRepository.Update(Product);
                    _unitOfWork.Complete();
                    gridProduct.Visibility = Visibility.Hidden;
                    Close();
                }
                else
                    MessageBox.Show("Error!");
            }
        }
    }
}