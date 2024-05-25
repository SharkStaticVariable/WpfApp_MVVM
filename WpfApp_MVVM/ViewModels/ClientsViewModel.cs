using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using WpfApp_MVVM.Models;
using WpfApp_MVVM.Commands;
using System.Collections.ObjectModel;

namespace WpfApp_MVVM.ViewModels
{
    public class ClientsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        ClientsServices ObjClientsService;
        public ClientsViewModel()
        {
            ObjClientsService = new ClientsServices();
            LoadData();
            CurrentClients = new ClientsDTO();
            saveCommand = new RelayCommand(Save);
            searchCommand = new RelayCommand(Search);
            updateCommand = new RelayCommand(Update);
            deleteCommand = new RelayCommand(Delete);
        }
        private ObservableCollection<ClientsDTO> clientsList;
        public ObservableCollection<ClientsDTO> ClientsList
        {
            get { return clientsList; }
            set { clientsList = value; OnPropertyChanged("ClientsList"); }
        }

        private void LoadData()
        {
            ClientsList = new ObservableCollection<ClientsDTO> (ObjClientsService.GetAll());
        }


        private ClientsDTO currentClients;

        public  ClientsDTO CurrentClients
        {
            get { return currentClients; }
            set { currentClients = value; OnPropertyChanged("CurrentClients"); }
        }
        private string message;

        public string Message
        {
            get { return message; }
            set { message= value; OnPropertyChanged("Message"); }
        }


        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
           
        }

        public void Save()
        {
            try
            {
                var IsSaved = ObjClientsService.Add(CurrentClients);
                LoadData();
                if (IsSaved)
                    Message = "Клиент сохранен";
                else Message = "Операция прервана!";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }


        private RelayCommand searchCommand;

        public RelayCommand SearchCommand
        {
            get { return searchCommand; }
        }
        public void Search()
        {
            try
            {
                var ObjClients = ObjClientsService.Search(CurrentClients.Id);
                if(ObjClients != null)
                {
                    CurrentClients.Phone = ObjClients.Phone;
                    currentClients.Email = ObjClients.Email;
                }
                else
                {
                    Message = "Клиент не найден";
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private RelayCommand updateCommand;

        public RelayCommand UpdateCommand
        {
            get { return updateCommand; }
           
        }
        public void Update()
        {
            try
            {
                var IsUpdate = ObjClientsService.Update(CurrentClients);
                if (IsUpdate)
                {
                    Message = "Клиент обновлен";
                    LoadData(); 
                }
                else
                {
                    Message = "Неудачно!";
                }
            }
            catch (Exception ex)
            {

                Message = ex.Message;
            }
        }

        private RelayCommand deleteCommand;

        public RelayCommand DeleteCommand
        {
            get { return deleteCommand; }
           
        }
        public void Delete()
        {
            try
            {
                var IsDeleted = ObjClientsService.Delete(CurrentClients.Id);
                if(IsDeleted)
                {
                    Message = "КЛиент удален!";
                    LoadData();
                }
                else
                {
                    Message = "неудачно!";
                }
            }
            catch (Exception ex)
            {

                Message = ex.Message;
            }
        }
    }
}
