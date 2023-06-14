using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Memorize.Model;
using System.Collections.ObjectModel;

namespace Memorize.ViewModel
{
   public partial class MemorizeViewModel : ObservableObject
   {
      [ObservableProperty]
      public MemorizeGame game;

      [ObservableProperty]
      ObservableCollection<string> items = new ObservableCollection<string>();

      public string GameOverText => $"{Game.IsGameOver} game over";

      [RelayCommand]
      private void NewGame()
      {
         Game = new MemorizeGame(new HashSet<string> { "A", "B", "C" });
      }

      [RelayCommand]
      private void ChooseCard(Card chosenCard)
      {
         Game.ChooseCard(chosenCard.Id);
      }

      public MemorizeViewModel()
      {
         NewGame();
      }
   }
}
