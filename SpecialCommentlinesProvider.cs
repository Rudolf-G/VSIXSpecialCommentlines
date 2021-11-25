using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

using System.ComponentModel.Composition;

namespace VSIXSpecialCommentlines
{
   /// <summary>
   /// Classifier provider. It adds the classifier to the set of classifiers.
   /// </summary>
   [Export(typeof(IClassifierProvider))]
   [ContentType("text")] // This classifier applies to text-files ("CSharp" => C#; "text" => all text files; "code" => only to code-files; ...)
   internal class SpecialCommentlinesProvider : IClassifierProvider
   {
      // Disable "Field is never assigned to..." compiler's warning. Justification: the field is assigned by MEF.
#pragma warning disable 649

      /// <summary>
      /// Classification registry to be used for getting a reference
      /// to the custom classification type later.
      /// </summary>
      [Import]
#pragma warning disable IDE0044 // Modifizierer "readonly" hinzufügen
      private IClassificationTypeRegistryService classificationRegistry;

#pragma warning restore IDE0044 // Modifizierer "readonly" hinzufügen

#pragma warning restore 649

      #region IClassifierProvider

      /// <summary>
      /// Gets a classifier for the given text buffer.
      /// </summary>
      /// <param name="buffer">The <see cref="ITextBuffer"/> to classify.</param>
      /// <returns>A classifier for the text buffer, or null if the provider cannot do so in its current state.</returns>
      public IClassifier GetClassifier(ITextBuffer buffer)
      {
         return buffer.Properties.GetOrCreateSingletonProperty<SpecialCommentlinesClassifier>(
            creator: () => new SpecialCommentlinesClassifier(this.classificationRegistry));
      }

      #endregion
   }
}
