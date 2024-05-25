using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace WpfApp_MVVM.Models
{
    public class ClientsServices
    {
        TicketSalesSystemEntities2 ObjContext;
    
        public ClientsServices()
        {
            ObjContext = new TicketSalesSystemEntities2();
           
        }

        public List<ClientsDTO> GetAll()
        {
            List<ClientsDTO> ObjClientList = new List<ClientsDTO> ();
            try
            {
               var ObjQuery = from clients in ObjContext.Clients select clients;
                foreach(var client in ObjQuery)
                {
                    ObjClientList.Add(new ClientsDTO { Id=client.Id, Phone=client.Phone, Email=client.Email});
                }
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                /*ObjSqlConnection.Close();*/
            }
            return ObjClientList;
        }

        public static bool ValidatePhoneNumber(string phoneNumber)
        {
           
            string pattern = @"^7\d{10}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }

        public static bool ValidateEmail(string email)
        {
            
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        public bool Add(ClientsDTO objNewClients)
        {
            bool IsAdded = false;
            if (string.IsNullOrWhiteSpace(objNewClients.Phone))
            {
                Console.WriteLine("Phone number is required.");
                return false;
            }

            // Проверка корректности номера телефона
            if (!ValidatePhoneNumber(objNewClients.Phone))
            {
                Console.WriteLine("Invalid phone number format.");
                return false;
            }

            // Проверка наличия адреса электронной почты
            if (string.IsNullOrWhiteSpace(objNewClients.Email))
            {
                Console.WriteLine("Email address is required.");
                return false;
            }

            // Проверка корректности адреса электронной почты
            if (!ValidateEmail(objNewClients.Email))
            {
                Console.WriteLine("Invalid email address format.");
                return false;
            }


            try
            {
                var ObjClients = new Clients();
                ObjClients.Id = objNewClients.Id;
                ObjClients.Phone= objNewClients.Phone;
                ObjClients.Email= objNewClients.Email;

                ObjContext.Clients.Add(ObjClients);
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsAdded = NoOfRowsAffected > 0;
             
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                /*ObjSqlConnection.Close();*/
            }


            return IsAdded;
        }

        public bool Update(ClientsDTO objClientsToUpdate) 
        {
            bool IsUpdated = false;


            try
            {
                var ObjClient = ObjContext.Clients.Find(objClientsToUpdate.Id);
                ObjClient.Phone = objClientsToUpdate.Phone;
                ObjClient.Email = objClientsToUpdate.Email;
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsUpdated = NoOfRowsAffected > 0;
               
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                /*ObjSqlConnection.Close();*/
            }


            return IsUpdated;
        }

        public bool Delete(int id)
        {
            bool IsDeleted = false;


            try
            {
                var ObjClientToDelete = ObjContext.Clients.Find(id);
                ObjContext.Clients.Remove(ObjClientToDelete);
                var NoOfRowsAffected = ObjContext.SaveChanges();
                IsDeleted = NoOfRowsAffected > 0;
              
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                
            }


            return IsDeleted;
        }

        public ClientsDTO Search(int id)
        {
            ClientsDTO ObjClients = null;

            try
            {
                var ObjClientsToFind = ObjContext.Clients.Find(id);
                if(ObjClientsToFind != null )
                {
                    ObjClients = new ClientsDTO()
                    {
                        Id = ObjClientsToFind.Id,
                        Phone = ObjClientsToFind.Phone,
                        Email = ObjClientsToFind.Email
                };
                }
            
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            
            return ObjClients;
        }
    }
}
