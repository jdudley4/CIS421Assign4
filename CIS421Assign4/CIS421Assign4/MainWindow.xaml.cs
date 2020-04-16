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

namespace CIS421Assign4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            var data = GetData();
            DGAgeName.ItemsSource = data.Vehicle;
            DGNameNemsis.ItemsSource = data.ModelRecall;

        }


        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private static List<VehicleRecall> ExecuteHashJoin(DataContext data)
        {

            return (data.Vehicle.Join(data.ModelRecall,
                vehicle => vehicle.Model, modelRecall => modelRecall.Model,
                (vehicle, modelRecall) => new VehicleRecall(vehicle.Model, modelRecall.Recall, vehicle.OwnerName, modelRecall.VehicleName, modelRecall.RecallYear )))
                .ToList();
        }

        private static List<VehicleRecall> JoinCol(DataContext data, string T1Col, string T2Col)
        {

            return (data.Vehicle.Join(data.ModelRecall,
                        vehicle => ((T1Col == "1") ?  vehicle.OwnerName : (T1Col == "2") ? vehicle.Model : (T1Col == "3") ? vehicle.Year : null) , 
                            modelRecall => ((T2Col == "1") ? modelRecall.Model : (T2Col == "2") ? modelRecall.VehicleName : (T2Col == "3") ? modelRecall.Recall : ((T2Col == "4") ? modelRecall.RecallYear : null)),
                        (vehicle, modelRecall) => new VehicleRecall(vehicle.Model, modelRecall.Recall, vehicle.OwnerName, modelRecall.VehicleName, modelRecall.RecallYear)))
                        .ToList();
        }

        private static List<VehicleRecall> JoinOnVariable(DataContext data, string input, string T1Col, string T2Col)
        {
            //return (data.Vehicle.Join(data.ModelRecall,
            //    vehicle => vehicle.Year.Contains(input), modelRecall => modelRecall.RecallYear.Contains(input),
            //    (vehicle, modelRecall) => new VehicleRecall(vehicle.Model, modelRecall.Recall, vehicle.OwnerName, modelRecall.VehicleName, modelRecall.RecallYear)))
            //    .ToList();

            if (T1Col == null || T1Col == null)
                return null;
            return (data.Vehicle.Join(data.ModelRecall,
                        vehicle => ((T1Col == "1") ? vehicle.OwnerName : (T1Col == "2") ? vehicle.Model : (T1Col == "3") ? vehicle.Year : null).Contains(input),
                            modelRecall => ((T2Col == "1") ? modelRecall.Model : (T2Col == "2") ? modelRecall.VehicleName : (T2Col == "3") ? modelRecall.Recall : ((T2Col == "4") ? modelRecall.RecallYear : null)).Contains(input),
                        (vehicle, modelRecall) => new VehicleRecall(vehicle.Model, modelRecall.Recall, vehicle.OwnerName, modelRecall.VehicleName, modelRecall.RecallYear)))
                        .ToList();

        }

        private static DataContext GetData()
        {
            var context = new DataContext();

            context.Vehicle.AddRange(new[] {
                    new Vehicle("Knight Rider","Trans Am", "1982"),
                    new Vehicle("DeLorean Guy","DeLorean", "2010"),
                    new Vehicle("Ghost Busters","Meteor Futura", "1970"),
                    new Vehicle("Bat Man","Futura", "2010"),
                    new Vehicle("Jim Douglas","Beetle", "1970")
                });

            context.ModelRecall.AddRange(new[]
            {
                new ModelRecall("Trans Am","KITT", "Self Aware issues", "1984"),
                new ModelRecall("DeLorean", "DeLorean", "Speeds over 88mph causes problems", "2015"),
                new ModelRecall("Meteor Futura","Ecto1", "Exhaust issues", "1984"),
                new ModelRecall("Futura", "Bat Mobile", "Rocket malfunctions","2011"),
                new ModelRecall("Beetle", "Herbie", "Speed regulator does not exist","1970")
            });

            return context;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var data = GetData();
            DGAgeName.ItemsSource = data.Vehicle;
            DGNameNemsis.ItemsSource = data.ModelRecall;
 
            var result = ExecuteHashJoin(data);

            dataGrid.ItemsSource = result;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void txtT1R1C1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var data = GetData();
            DGAgeName.ItemsSource = data.Vehicle;
            DGNameNemsis.ItemsSource = data.ModelRecall;
             
            var result = JoinOnVariable(data, txtT1R1C1.Text, cmbT1.Text, cmbT2.Text);

            dataGrid.ItemsSource = result;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var data = GetData();
            DGAgeName.ItemsSource = data.Vehicle;
            DGNameNemsis.ItemsSource = data.ModelRecall;

            var result = JoinCol(data, cmbT1.Text, cmbT2.Text);

            dataGrid.ItemsSource = result;
        }
    }
}

