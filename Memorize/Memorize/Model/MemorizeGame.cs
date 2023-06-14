using CommunityToolkit.Mvvm.ComponentModel;
using Memorize.Extensions;
using System.Collections.ObjectModel;

namespace Memorize.Model
{
   public class MemorizeGame : ObservableObject
   {
      private readonly Dictionary<int,Card> _cards;
      public IReadOnlyCollection<Card> Cards => new ReadOnlyCollection<Card>(_cards.Values.ToList());

      public bool IsGameOver => _cards.Values.All(c => c.IsMatched);

      private IEnumerable<Card> FaceUpCards => _cards.Values.Where(c => c.IsFaceUp && !c.IsMatched);

      public MemorizeGame(HashSet<string> cardContents)
      {
         _cards = InitializeCards(cardContents);
         NotifyPropertiesChanged();
      }

      public void ChooseCard(int id)
      {
         if (!_cards.ContainsKey(id) || _cards[id].IsMatched)
         {
            return;
         }

         switch (FaceUpCards.Count())
         {
            case 0:
               _cards[id] = _cards[id].Flipped();
               break;
            case 1:
               _cards[id] = _cards[id].Flipped();
               CheckForMatches();
               break;
            default:
               FlipOverAllFaceUpCards();
               _cards[id] = _cards[id].Flipped();
               break;
         }

         NotifyPropertiesChanged();
      }

      private void FlipOverAllFaceUpCards()
      {
         foreach (var faceUpCard in FaceUpCards)
         {
            _cards[faceUpCard.Id] = _cards[faceUpCard.Id].Flipped();
         }
      }

      private void NotifyPropertiesChanged()
      {
         OnPropertyChanged(nameof(Cards));
         OnPropertyChanged(nameof(IsGameOver));
      }

      private void CheckForMatches()
      {
         foreach (var cardToCheck in FaceUpCards.Select((card, index) => ( card, index )))
         {
            foreach (var cardToCheckAgainst in FaceUpCards.Skip(cardToCheck.index + 1))
            {
               if (cardToCheck.card.Content == cardToCheckAgainst.Content)
               {
                  _cards[cardToCheck.card.Id] = _cards[cardToCheck.card.Id].Matched();
                  _cards[cardToCheckAgainst.Id] = _cards[cardToCheckAgainst.Id].Matched();
               }
            }
         }
      }

      private static Dictionary<int,Card> InitializeCards(IEnumerable<string> cardContents)
      {
         var doubledContents = cardContents.Concat(cardContents).ToList();
         var randomizedDoubledContents = doubledContents.Randomize();
         var cards = randomizedDoubledContents.Select(c => new Card(c)).ToDictionary(card => card.Id);
         return cards;
      }
   }
}
