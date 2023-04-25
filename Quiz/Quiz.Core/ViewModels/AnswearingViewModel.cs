﻿using Quiz.Core.Core;
using Quiz.Core.Services;

namespace Quiz.Core.ViewModels
{
    public class AnswearingViewModel : ViewModel
    {

        private INavigationService _navigation;
        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public AnswearingViewModel(INavigationService navigation)
        {
            Navigation = navigation;
        }
    }
}
