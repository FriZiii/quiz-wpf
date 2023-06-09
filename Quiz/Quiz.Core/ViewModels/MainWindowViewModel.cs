﻿using Quiz.Core.Core;
using Quiz.Core.Services;
using System.Windows;

namespace Quiz.Core.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        //Properties
        private INavigationService _navigation;
        public INavigationService Navigation
        {
            get { return _navigation; }
            set
            { 
                _navigation = value; 
                OnPropertyChanged();
            }
        }

        //Commands
        public RelayCommand CloseAppCommand { get; set; }
        public RelayCommand MinimalizeAppCommand { get; set; }
        public RelayCommand MouseDownCommand { get; set; }

        //Constructor
        public MainWindowViewModel(INavigationService navigationService)
        {
            Navigation = navigationService;
            Navigation.NavigateTo<MainViewModel>();

            CloseAppCommand = new RelayCommand(o => { Application.Current.Shutdown(); }, o=> true);
            MinimalizeAppCommand = new RelayCommand(o => { Application.Current.MainWindow.WindowState = WindowState.Minimized; }, o => true);
            MouseDownCommand = new RelayCommand(o => { Application.Current.MainWindow.DragMove(); }, o=> true);
        }
    }
}
