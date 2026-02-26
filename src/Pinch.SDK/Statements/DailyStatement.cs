namespace Pinch.SDK.Statements
{
    /// <summary>
    /// Represents a daily statement
    /// </summary>
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
