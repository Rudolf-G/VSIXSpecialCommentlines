using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace VSIXSpecialCommentlines
{
   /// <summary>
   /// Classification type definition exports for SpecialCommentlinesClassifier
   /// </summary>
   internal static class SpecialCommentlinesClassificationDefinitions
   {
      internal const string SpecialCommentlines1stChar = "SpecialCommentlines1stChar";
      internal const string SpecialCommentlinesContent = "SpecialCommentlinesContent";

      // This disables "The field is never used" compiler's warning. Justification: the field is used by MEF.
#pragma warning disable IDE0051 // Nicht verwendete private Member entfernen, justification: Export
#pragma warning disable IDE0044 // Modifizierer "readonly" hinzufügen, justification: Export

      [Export]
      [Name(SpecialCommentlines1stChar)]
      private static ClassificationTypeDefinition ClassificationTypeOf1stChar = null;

      [Export]
      [Name(SpecialCommentlinesContent)]
      private static ClassificationTypeDefinition ClassificationTypeOfContent = null;

#pragma warning restore IDE0044 // Modifizierer "readonly" hinzufügen
#pragma warning restore IDE0051 // Nicht verwendete private Member entfernen

   }
}

