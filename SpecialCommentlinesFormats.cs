using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

using System.ComponentModel.Composition;
using System.Windows.Media;

namespace VSIXSpecialCommentlines
{
   /// <summary>
   /// Defines an editor format for the "SpecialCommentlines1stChar" type
   /// </summary>
   [Export(typeof(EditorFormatDefinition))]
   [ClassificationType(ClassificationTypeNames =
      SpecialCommentlinesClassificationDefinitions.SpecialCommentlines1stChar)]
   [Name(SpecialCommentlinesClassificationDefinitions.SpecialCommentlines1stChar)]
   [UserVisible(true)] // This should be visible to the end user
   [Order(After = Priority.High)] // Insert after high priority classifiers (give highest priority)
   internal sealed class SpecialCommentlinesFormat1stChar : ClassificationFormatDefinition
   {
      public SpecialCommentlinesFormat1stChar()
      {
         this.DisplayName = "SpecialCommentlines: 1stChar"; // Human readable version of the name
         // The following initial values can be overridden (and selected again) by Visual Studio Options
         this.BackgroundColor = Colors.LightGray;
         this.ForegroundColor = Colors.Black;
         this.IsBold = true;
         // this.TextDecorations = System.Windows.TextDecorations.Underline;
      }
   }

   /// <summary>
   /// Defines an editor format for the "SpecialCommentlinesContent" type
   /// </summary>
   [Export(typeof(EditorFormatDefinition))]
   [ClassificationType(ClassificationTypeNames =
      SpecialCommentlinesClassificationDefinitions.SpecialCommentlinesContent)]
   [Name(SpecialCommentlinesClassificationDefinitions.SpecialCommentlinesContent)]
   [UserVisible(true)] // This should be visible to the end user
   [Order(After = Priority.High)] // Insert after high priority classifiers (give highest priority)
   internal sealed class SpecialCommentlinesFormatContent : ClassificationFormatDefinition
   {
      public SpecialCommentlinesFormatContent()
      {
         this.DisplayName = "SpecialCommentlines: Content"; // Human readable version of the name
         // The following initial values can be overridden (and selected again) by Visual Studio Options
         this.ForegroundColor = Colors.Black;
         this.IsBold = true;
      }
   }   
}
