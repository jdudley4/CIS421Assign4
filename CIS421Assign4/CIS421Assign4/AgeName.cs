using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS421Assign4
{
    public class Vehicle
    {
        public Vehicle(string ownerName, string model, string year)
        {
            OwnerName = ownerName;
            Model = model;
            Year = year;
            
        }
        public string OwnerName { get; private set; }
        public string Model { get; private set; }
        public string Year { get; private set; }
    }

    public class ModelRecall
    {
        public ModelRecall(string model, string vehicleName, string recall, string recallYear)
        {
            Model = model;
            VehicleName = vehicleName;
            Recall = recall;
            RecallYear = recallYear;
        }
        public string Model { get; private set; }
        public string VehicleName { get; private set; }
        public string Recall { get; private set; }
        public string RecallYear { get; private set; }
    }

    public class DataContext
    {
        public DataContext()
        {
            Vehicle = new List<Vehicle>();
            ModelRecall = new List<ModelRecall>();
        }
        public List<Vehicle> Vehicle { get; set; }
        public List<ModelRecall> ModelRecall { get; set; }
    }

    public class VehicleRecall
    {
        public VehicleRecall(string model, string recall, string ownerName, string vehicleName, string recallYear)
        {
            Model = model;
            OwnerName = ownerName;
            VehicleName = vehicleName;
            Recall = recall;
            RecallYear = recallYear;
        }
        public string Model { get; private set; }
        public string OwnerName { get; private set; }
        public string Recall { get; private set; }
        public string VehicleName { get; private set; }
        public string RecallYear { get; private set; }
    }
}