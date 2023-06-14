using Memorize.Model;

namespace Memorize.TemplateSelector
{
   public class CardDataTemplateSelector : DataTemplateSelector
   {
      public DataTemplate FaceUpCardTemplate { get; set; }
      public DataTemplate FaceDownCardTemplate { get; set; }
      public DataTemplate MatchedCardTemplate { get; set; }

      protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
      {
         if (item is null || item is not Card)
         {
            return FaceDownCardTemplate;
         }
         
         var card = (Card)item;

         if (card.IsMatched)
         {
            return MatchedCardTemplate;
         }

         if (card.IsFaceUp)
         {
            return FaceUpCardTemplate;
         }

         return FaceDownCardTemplate;
      }
   }
}
