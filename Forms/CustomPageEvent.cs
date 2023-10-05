using iTextSharp.text;
using iTextSharp.text.pdf;

public class CustomPageEvent : PdfPageEventHelper
{
    public override void OnEndPage(PdfWriter writer, Document doc)
    {
        base.OnEndPage(writer, doc);

        // Add your footer content here
        Font footerFont = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 6);
        string footerText = @"
            Payment Terms:
            - Payment is due upon receipt.
            - Late payments may incur additional charges.
            - For any payment-related inquiries, please contact our accounts department.

            Return Policy:
            - Goods once sold are not returnable.
            - If you have received damaged or incorrect items, please contact us within 7 days for a replacement or refund.

            Customer Support:
            - For any questions or assistance, please feel free to contact our customer support team.
            - Phone: [Your Contact Number]
            - Email: [Your Support Email]

            Thank you for choosing New Bernales Hardware Store! We appreciate your business.
        ";

        Paragraph footerParagraph = new Paragraph(footerText, footerFont);
        footerParagraph.Alignment = Element.ALIGN_LEFT;

        ColumnText ct = new ColumnText(writer.DirectContent);
        ct.SetSimpleColumn(20, 20, 580, 50); // Define the rectangle for footer text
        ct.AddElement(footerParagraph);
        ct.Go();
    }
}
