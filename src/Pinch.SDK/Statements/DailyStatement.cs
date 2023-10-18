using System;
using Pinch.SDK.Payers;

namespace Pinch.SDK.Statements
{
    public class DailyStatement
    {
        /// <summary>
        /// The Daily Statement ID
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Status of the PDF generation. 
        /// </summary>
        public string PdfGenerationStatus { get; set; }

        /// <summary>
        /// Date of the statement
        /// </summary>
        public string StatementDateLocal { get; set; }
    }
}
