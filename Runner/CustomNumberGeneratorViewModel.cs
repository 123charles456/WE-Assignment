using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using Numbers;
namespace Runner
{
    class CustomNumberGeneratorViewModel : INotifyPropertyChanged

    {
        #region private properties
        private int _limit;
        private ObservableCollection<string> _CustomNumberList;    
        private bool _isBusy;
        #endregion
        #region public properties
        public int Limit
        {
            get
            {
                return _limit;
            }
            set
            {
                _limit = value;
                SetPropertyChanged("Limit");
            }
        }

        public ObservableCollection<string> CustomNumberList
        {
            get
            {
                return _CustomNumberList;
            }
            set
            {
                _CustomNumberList = value;
                SetPropertyChanged("CustomNumberList");
            }

        }



        public IAsyncCommand ClickGenerate
        {
            get;

            private set;

        }
        public bool IsBusy
        {
            get => _isBusy;
            private set
            {
                _isBusy = value;
            }
        }

        #endregion

        public CustomNumberGeneratorViewModel()
        {
            ClickGenerate = new AsyncCommand(ExecuteSubmitAsync, CanExecuteSubmit);

        }
        private async Task ExecuteSubmitAsync()
        {
            try
            {
                IsBusy = true;
                CustomNumberGenerator objCustomGenerator = new CustomNumberGenerator();                
                CustomNumberList = new ObservableCollection<string>();

                //Synchronizing the collection "CustomNumberList" among multiple threads
                BindingOperations.EnableCollectionSynchronization(CustomNumberList, new Object());
                await Task.Run(() => objCustomGenerator.GenerateCustomList(Limit, CustomNumberList));   
            }
            finally
            {
                IsBusy = false;
            }
        }

       
        private bool CanExecuteSubmit()
        {
            return !IsBusy;
        }

        #region propertychanged Events
        public event PropertyChangedEventHandler PropertyChanged;
        public void SetPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }


}
