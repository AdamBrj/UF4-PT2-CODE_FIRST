using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UF4_PT2_CODE_FIRST.DAO;
using UF4_PT2_CODE_FIRST.MODEL;

namespace UF4_PT2_CODE_FIRST
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IDAOManager dao;
        private MyDbContext context = new MyDbContext();

        public MainWindow()
        {
            InitializeComponent();
            dao = new DAOManager(this);
        }


        private void btnImportCSV_Click(object sender, RoutedEventArgs e)
        {
            GetImports();

        }

        private void GetImports()
        {
            try
            {
                dao.AddProductLines();
                dao.AddProducts();
                dao.AddOffices();
                dao.AddEmployees();
                dao.AddCustomers();
                dao.AddPayments();
                dao.AddOrders();
                dao.AddOrdersDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }


       


        private async void QueryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedOption = ((ComboBoxItem)QueryComboBox.SelectedItem).Content.ToString();

            switch (selectedOption)
            {
                case "Obtenir tots els clients":
                    dao.GetCustomers();
                    break;

                case "Obtenir tots els productes":
                    dao.GetProducts();
                    break;

                case "Obtenir clients amb crèdit major a 5000":
                    dao.GetCustomersWithCreditGreaterThan5000();
                    break;

                case "Obtenir empleats i els seus clients":
                    await dao.GetEmployeesWithCustomers();
                    break;

                case "Obtenir productes i els seus detalls de comanda":
                    dao.GetProductsWithOrderDetails();
                    break;

                case "Obtenir total de productes per línia de producte":
                    await dao.GetTotalProductsByProductLine();
                    break;

                case "Obtenir total de comandes per client":
                    await dao.GetTotalOrdersByCustomer();
                    break;

                case "Obtenir totes les línies de productes i els seus productes":
                    await dao.GetProductLinesWithProducts();
                    break;

                case "Obtenir totes les comandes i els seus detalls de comanda":
                    await dao.GetOrdersWithOrderDetails();
                    break;

                case "Obtenir els 10 productes més venuts":
                    await dao.GetTopProducts();
                    break;

                case "Obtenir empleats amb més de 100 vendes":
                    await dao.GetTopEmployees();
                    break;

                default:
                    break;
            }
        }
    }
}

