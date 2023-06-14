using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memorize.Extensions
{
   public static class EnumerableExtensions
   {
      public static IEnumerable<TSource> Randomize<TSource>(this IEnumerable<TSource> source)
      {
         var randomized = new List<TSource>();
         var random = new Random();
         var list = source.ToList();
         while (list.Any())
         {
            var randomIndex = random.Next(list.Count);
            var randomItem = list.ElementAt(randomIndex);
            list.RemoveAt(randomIndex);
            randomized.Add(randomItem);
         }
         return randomized;
      }
   }
}
