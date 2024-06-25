using Amazon.Library.Models;
using Amazon.Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace eCommerce.MAUI.ViewModels
{
    public class InventoryViewModel : INotifyPropertyChanged
    {
        public ICommand? EditCommand { get; private set; }
        public ICommand? DeleteCommand { get; private set; }

        public List<ProductViewModel> Products { 
            get {
                return InventoryServiceProxy.Current.Products.Where(p=>p != null)
                    .Select(p => new ProductViewModel(p)).ToList() 
                    ?? new List<ProductViewModel>();
            } 
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Products));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void ExecuteEdit(ProductViewModel? p)
        {
            if (p?.Model == null)
            {
                return;
            }
            //Shell.Current.GoToAsync(
        }

        private void ExecuteDelete(int? id)
        {
            if (id == null)
            {
                return;
            }

            InventoryServiceProxy.Current.Delete(id ?? 0);
        }

        public void SetupCommands()
        {
            EditCommand = new Command(
               (c) => ExecuteEdit(c as ProductViewModel));
            DeleteCommand = new Command(
               (c) => ExecuteDelete((c as ProductViewModel)?.Model?.Id));
        }
    }
}
