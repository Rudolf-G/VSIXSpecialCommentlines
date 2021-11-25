using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;

using System;
using System.Collections.Generic;

namespace VSIXSpecialCommentlines
{
   /// <summary>
   /// Classifier that classifies all text as an instance of the "SpecialCommentlinesClassifier" classification type.
   /// </summary>
   internal class SpecialCommentlinesClassifier : IClassifier
   {
      ///// <summary>
      ///// Classification type.
      ///// </summary>
      private readonly IClassificationType classificationType1stChar;

      /// <summary>
      /// Initializes a new instance of the <see cref="SpecialCommentlinesClassifier"/> class.
      /// </summary>
      /// <param name="registry">Classification registry.</param>
      internal SpecialCommentlinesClassifier(IClassificationTypeRegistryService registry)
      {
         this.classificationType1stChar = registry.GetClassificationType("SpecialCommentlines1stChar");
      }

      #region IClassifier

#pragma warning disable 67

      /// <summary>
      /// An event that occurs when the classification of a span of text has changed.
      /// </summary>
      /// <remarks>
      /// This event gets raised if a non-text change would affect the classification in some way,
      /// for example typing /* would cause the classification to change in C# without directly
      /// affecting the span.
      /// </remarks>
      public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;

#pragma warning restore 67

      /// <summary>
      /// Gets all the <see cref="ClassificationSpan"/> objects that intersect with the given range of text.
      /// </summary>
      /// <remarks>
      /// This method scans the given SnapshotSpan for potential matches for this classification.
      /// In this instance, it classifies everything and returns each span as a new ClassificationSpan.
      /// </remarks>
      /// <param name="snapshotSpan">The span currently being classified.</param>
      /// <returns>A list of ClassificationSpans that represent spans identified to be of this classification.</returns>
      public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan snapshotSpan)
      {
         //| This lines is an example: the extension will highlight the "|" at the beginning of this line
         //| using a grey background and set the ForegroundColor of the rest of the line to black and bold to true.
         // BackgroundColor, ForegroundColor and bold can be overridden by the user
         // through the page  Tools - Options -  Fonts and Colors - "SpecialCommentlines-1stChar" or ... "SpecialCommentlines-Line"

         ITextSnapshot snapshot = snapshotSpan.Snapshot;

         List<ClassificationSpan> classificationSpans = null;

         if (snapshot.Length != 0)
         {
            int startno = snapshotSpan.Start.GetContainingLine().LineNumber;
            int endno = (snapshotSpan.End - 1).GetContainingLine().LineNumber;

            for (int lineNumber = startno; lineNumber <= endno; lineNumber++)
            {
               ITextSnapshotLine line = snapshot.GetLineFromLineNumber(lineNumber);
               ITextSnapshot text = line.Snapshot;

               // don't trust the test, which shows that there is always only one line
               for (int charNumber = line.Start; charNumber < line.End - 2; charNumber++)
               {
                  char c = text[charNumber];

                  if (char.IsWhiteSpace(c))
                     continue; // skip whitespace

                  if (c == '/' && text[charNumber + 1] == '/' && text[charNumber + 2] == '|')
                  {  // found "//|"
                     if (classificationSpans == null)
                        classificationSpans = new List<ClassificationSpan>(10); // (2); <<<<<<<<<<<<<<<<<<

                     // Highlite the 1st char of the comment
                     classificationSpans.Add(
                        new ClassificationSpan(
                           new SnapshotSpan(text, charNumber + 2, 1),
                           this.classificationType1stChar));

                     //// Set color of the rest of the line
                     //if (line.End - charNumber - 3 > 0)
                     //   classificationSpans.Add(
                     //   new ClassificationSpan(
                     //      new SnapshotSpan(text, charNumber + 3, line.End - charNumber - 3),
                     //      this.classificationType2));

                     // The following test can be used to show that List<ClassificationSpan>(2) is typically sufficent 
                     // if (classificationSpans.Count > 1)
                     //   throw new Exception("classificationSpans.Count > 2");
                  }

                  break; // found the special string or not a whitespace: continue with next line
               }
            }
         }

         if (classificationSpans == null)
            classificationSpans = new List<ClassificationSpan>(10);  // (0) <<<<<<<<<<<<<<<<<<<<<<<
         return classificationSpans;
      }

      #endregion
   }
}
