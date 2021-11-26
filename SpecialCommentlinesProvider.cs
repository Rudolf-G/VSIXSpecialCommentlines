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
   [ContentType("csharp")]
   // This classifier applies to ... ("csharp" => C#; "text" => all text files; "code" => only to code-files; ...)
   internal class SpecialCommentlinesProvider : IClassifierProvider
   {
      /// <summary>
      /// Classification registry to be used for getting a reference
      /// to the custom classification type later.
      /// </summary>
      [Import]
      internal IClassificationTypeRegistryService classificationRegistry = null;

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
   }
}
