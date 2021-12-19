using EfCoreWithUnitOfWork.DAL.Context;
using EfCoreWithUnitOfWork.Entities;
using EfCoreWithUnitOfWork.Unit_Of_Work;
using EfCoreWithUnitOfWork.Unit_Of_Work.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            ////_unitOfWork.CategoryRepository.GetAll().Include(c => c.Products);
            ////var c1 = new Category() { Name = "Phone" };
            //var c1 = _unitOfWork.CategoryRepository.GetById(1);
            ////var p1 = new Product() { Name = "Iphone 12 Pro", UnitPrice = 2399 };
            //var p2 = new Product() { Name = "Samsung S20", UnitPrice = 3199 };
            //c1.Products.Add(p2);

            ////_unitOfWork.CategoryRepository.Add(c1);
            //_unitOfWork.ProductRepository.Add(p2);
            //_unitOfWork.Complete();
            dataGridCategory.ItemsSource = _unitOfWork.CategoryRepository.GetAll().ToList();
            dataGridProduct.ItemsSource = _unitOfWork.ProductRepository.GetAll().ToList();

        }

        private void BtnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            ProcessWindow w2 = new ProcessWindow();
            w2.btnCat.Content = "Add";
            w2.gridCategory.Visibility = Visibility.Visible;
            w2.txb_cId.Text = "New Id";
            w2.ShowDialog();
        }

        private void BtnRefreshCategory_Click(object sender, RoutedEventArgs e)
        {
            dataGridCategory.ItemsSource = _unitOfWork.CategoryRepository.GetAll().ToList();
            //dataGridCategory.ItemsSource = _unitOfWork.CategoryRepository.GetAll().ToList().Select(c => new { c.Name });
        }

        private void BtnDeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridCategory.SelectedIndex != -1)
            {
                var category = dataGridCategory.SelectedItem as Category;
                _unitOfWork.CategoryRepository.Remove(category!);
                _unitOfWork.Complete();
            }
            else
                MessageBox.Show("Error!");
        }

        private void btnUpdateCategory_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridCategory.SelectedIndex != -1)
            {
                var category = dataGridCategory.SelectedItem as Category;
                ProcessWindow w2 = new ProcessWindow();
                w2.btnCat.Content = "Update";
                w2.gridCategory.Visibility = Visibility.Visible;
                w2.Category = category!;
                w2.txb_cId.Text = category?.Id.ToString();
                w2.txb_cName.Text = category?.Name;
                w2.ShowDialog();
            }
            else
                MessageBox.Show("Error!");
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            ProcessWindow w2 = new ProcessWindow();
            w2.btnProd.Content = "Add";
            w2.gridProduct.Visibility = Visibility.Visible;
            w2.txb_pId.Text = "New Id";
            w2.ShowDialog();
        }

        private void btnRefreshProduct_Click(object sender, RoutedEventArgs e)
        {
            dataGridProduct.ItemsSource = _unitOfWork.ProductRepository.GetAll().ToList();
        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridProduct.SelectedIndex != -1)
            {
                var product = dataGridProduct.SelectedItem as Product;
                _unitOfWork.ProductRepository.Remove(product!);
                _unitOfWork.Complete();
            }
            else
                MessageBox.Show("Error!");
        }

        private void btnUpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridProduct.SelectedIndex != -1)
            {
                var product = dataGridProduct.SelectedItem as Product;
                ProcessWindow w2 = new ProcessWindow();
                w2.btnProd.Content = "Update";
                w2.gridProduct.Visibility = Visibility.Visible;
                w2.Product = product!;
                w2.txb_pId.Text = product?.Id.ToString();
                w2.txb_pName.Text = product?.Name;
                w2.txb_pPrice.Text = product?.UnitPrice.ToString();
                w2.txb_pCatId.Text = product?.CategoryId.ToString();
                w2.ShowDialog();
            }
            else
                MessageBox.Show("Error!");
        }
    }
}
