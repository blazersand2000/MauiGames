namespace Memorize.Model
{
   public readonly struct Card
   {
      private static int nextId = 0;
      public string Content { get; }
      public int Id { get; }
      public bool IsFaceUp { get; }
      public bool IsMatched { get; }

      public Card(string content) : this(content, GetNextId(), false, false)
      {
      }

      public Card(string content, int id, bool isFaceUp, bool isMatched)
      {
         Content = content;
         Id = id;
         IsFaceUp = isFaceUp;
         IsMatched = isMatched;
      }

      private static int GetNextId() => nextId++;
      
      public Card Flipped() => new(Content, Id, !IsFaceUp, IsMatched);
      
      public Card Matched() => new(Content, Id, IsFaceUp, true);
   }
}
