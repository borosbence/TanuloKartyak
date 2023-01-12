﻿using ClosedXML.Excel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TanuloKartyak.Models;

namespace TanuloKartyak.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            _loading = true;
            _cardList = new List<Card>();
            NextCommand = new RelayCommand(SelectNextCard);
            ShowTextCommand = new RelayCommand(ShowTextLabel);
            Task.Run(LoadData);
        }

        private bool _loading;
        public bool Loading
        {
            get { return _loading; }
            set { SetProperty(ref _loading, value); }
        }

        private bool _loaded;
        public bool Loaded
        {
            get { return _loaded; }
            set { SetProperty(ref _loaded, value); }
        }

        private List<Card> _cardList;

        private Card _selectedCard;
        public Card SelectedCard
        {
            get { return _selectedCard; }
            set { SetProperty(ref _selectedCard, value); }
        }

        private bool _visibleText;
        public bool VisibleText
        {
            get { return _visibleText; }
            set { SetProperty(ref _visibleText, value); }
        }

        public IRelayCommand NextCommand { get; set; }
        public IRelayCommand ShowTextCommand { get; set; }

		private async Task LoadData()
		{
            _cardList.Clear();
            using (var stream = await FileSystem.OpenAppPackageFileAsync("kartyak.xlsx"))
            {
                using (var workBook = new XLWorkbook(stream))
                {
                    var workSheet = workBook.Worksheet(1);
                    var rows = workSheet.RowsUsed().Count();

                    for (int i = 1; i <= rows; i++)
                    {
                        string image = workSheet.Cell(i, 4).GetValue<string>();
                        string title = workSheet.Cell(i, 5).GetValue<string>();
                        _cardList.Add(new Card(image, title));
                    }
                }
            }
            SelectNextCard();
            Loading = false;
            Loaded = true;
        }

        private void SelectNextCard()
        {
            var rand = new Random();
            int index = rand.Next(_cardList.Count);
            VisibleText = false;
            SelectedCard = _cardList[index];
        }

        private void ShowTextLabel()
        {
            VisibleText = true;
        }
    }
}