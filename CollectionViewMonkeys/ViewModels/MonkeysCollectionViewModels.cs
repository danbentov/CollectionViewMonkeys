using CollectionViewMonkeys.Models;
using CollectionViewMonkeys.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CollectionViewMonkeys.ViewModels
{
    public class MonkeysCollectionViewModels : INotifyPropertyChanged
    {
        

           #region INotifyPropertyChanged

            public event PropertyChangedEventHandler PropertyChanged;

            void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            #endregion



            private ObservableCollection<Monkey> monkeys;
            public ObservableCollection<Monkey> Monkeys
            {
                get
                {
                    return this.monkeys;
                }
                set
                {
                    this.monkeys = value;
                    OnPropertyChanged();
                }
            }

            public Command<Monkey> DeleteCommand { get; set; }

            public void Delete(Monkey mForDelete)
            {
                if (Monkeys.Contains(mForDelete))
                {
                    Monkeys.Remove(mForDelete);
                }
            }

        public MonkeysCollectionViewModels()
        {
            Monkeys = new MonkeysService().monkeys;
            DeleteCommand = new Command<Monkey>(Delete);
            isRefreshing = false;
            RefreshCommand = new Command(Refresh);
            SingleSelectCommand = new Command()
        }

        public Command RefreshCommand { get; set; }

        private bool isRefreshing;
        public bool IsRefreshing
        {
            get
            {
                return this.isRefreshing;
            }
            set
            {
                this.isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public void Refresh()
        {
            if (IsRefreshing)
            {
                Monkeys = new MonkeysService().monkeys;
                isRefreshing = false;
            }
        }

        private object selectedMonkey;
        public object SelectedMonkey
        {
            get
            {
                return this.selectedMonkey;
            }
            set
            {
                this.selectedMonkey = value;
                OnPropertyChanged();
            }
        }

        public Command SingleSelectCommand { get; set; }

        async void OnSingleSelectMonkey()
        {
            if (SelectedMonkey != null)
            {
                var navParam = new Dictionary<string, object>()
            {
                { "selectedStudent",SelectedMonkey}
            };
                //Add goto here to show details
                await Shell.Current.GoToAsync($"studentDetails", navParam);

                SelectedMonkey = null;
            }
        }


    }
}
