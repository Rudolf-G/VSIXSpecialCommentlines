using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

using System.ComponentModel.Composition;

namespace VSIXSpecialCommentlines
{
   /// <summary>
   /// Classification type definition export for SpecialCommentlinesClassifier
   /// </summary>
   internal static class SpecialCommentlinesClassificationDefinition
   {
      // This disables "The field is never used" compiler's warning. Justification: the field is used by MEF.
#pragma warning disable IDE0051 // Nicht verwendete private Member entfernen
#pragma warning disable IDE0044 // Modifizierer "readonly" hinzufügen

      /// <summary>
      /// Defines the "SpecialCommentlines1stChar" classification type.
      /// </summary>
      [Export]
      [Name("SpecialCommentlines1stChar")]
      private static ClassificationTypeDefinition ClassificationTypeOf1stChar;

#pragma warning restore IDE0044 // Modifizierer "readonly" hinzufügen
#pragma warning restore IDE0051 // Nicht verwendete private Member entfernen

   }
}

