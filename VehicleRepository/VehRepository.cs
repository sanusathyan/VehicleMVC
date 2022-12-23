using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using VehicleMVC.Models;

namespace VehicleMVC.VehicleRepository
{
    public class VehRepository
    {
        private SqlConnection _sqlconnection;
        public VehRepository()
        {
            var connectionString = "data source = (localdb)\\mssqllocaldb; database = traindb";

            _sqlconnection = new SqlConnection(connectionString);
        }

        public IEnumerable<Vehicle> GetVechicles()
        {
            try
            {
                _sqlconnection.Open();

                var sqlCommand = new SqlCommand("select * from vechicle", _sqlconnection);

                var sqlDataReader = sqlCommand.ExecuteReader();

                var vehicles = new List<Vehicle>();

                while (sqlDataReader.Read())
                {
                    var id = (int)sqlDataReader["id"];
                    var category = (string)sqlDataReader["category"];
                    var companyName = (string)sqlDataReader["companyName"];
                    var modelName = (string)sqlDataReader["modelName"];
                    var power = (int)sqlDataReader["V_power"];

                    vehicles.Add(new Vehicle
                    {
                        Id = id,
                        Category = category,
                        CompanyName = companyName,
                        ModelName = modelName,
                        Power = power
                    }); 
                }
                return vehicles;

            }
            catch (Exception exception)
            {
                throw;
            }
            finally
            {
                _sqlconnection.Close();
            }
        }


        public Vehicle GetVehicleById(int id)
        {
            try
            {
                _sqlconnection.Open();

                var sqlCommand = new SqlCommand("select * from vechicle where id=@id", _sqlconnection);

                sqlCommand.Parameters.AddWithValue("id", id);

                var sqlDataRead = sqlCommand.ExecuteReader();

                var vehicleList = new List<Vehicle>();

                while (sqlDataRead.Read())
                {
                    vehicleList.Add(new Vehicle
                    {
                        Id = (int)sqlDataRead["id"],
                        Category = (string)sqlDataRead["category"],
                        CompanyName = (string)sqlDataRead["companyName"],
                        ModelName = (string)sqlDataRead["modelName"],
                        Power = (int)sqlDataRead["V_power"]
                    });
                }

                return vehicleList.FirstOrDefault();
            }
            catch
            {
                throw;
            }
            finally
            {
                _sqlconnection.Close();
            }
        }

        public bool InsertvehicleList(Vehicle vehicle)
        {
            try
            {
                _sqlconnection.Open();
                var sqlCommand = new SqlCommand("insert into vechicle values(@category, @companyName, @modelName,@V_power)", _sqlconnection);
                sqlCommand.Parameters.AddWithValue("category", vehicle.Category);
                sqlCommand.Parameters.AddWithValue("companyName", vehicle.CompanyName);
                sqlCommand.Parameters.AddWithValue("modelName", vehicle.ModelName);
                sqlCommand.Parameters.AddWithValue("V_power", vehicle.Power);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _sqlconnection.Close();
            }
        }

        public bool Updatevehicle(Vehicle vehicle)
        {
            try
            {
                _sqlconnection.Open();
                var sqlCommand = new SqlCommand("update vechicle set category= @category,companyName=@companyName,modelName=@modelName,V_power=@power where id=@id", _sqlconnection);
                sqlCommand.Parameters.AddWithValue("category", vehicle.Category);
                sqlCommand.Parameters.AddWithValue("companyName", vehicle.CompanyName);
                sqlCommand.Parameters.AddWithValue("modelName", vehicle.ModelName);
                sqlCommand.Parameters.AddWithValue("power", vehicle.Power);
                sqlCommand.Parameters.AddWithValue("id", vehicle.Id);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _sqlconnection.Close();
            }
        }

        public bool Deletevehicle(int id)
        {
            try
            {
                _sqlconnection.Open();
                var sqlCommand = new SqlCommand("delete from vechicle where id = @id", _sqlconnection);
                sqlCommand.Parameters.AddWithValue("id", id);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _sqlconnection.Close();
            }
        }
    }
}
