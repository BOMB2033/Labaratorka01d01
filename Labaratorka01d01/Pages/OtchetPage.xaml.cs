using Labaratorka01d01.AppData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Font = iTextSharp.text.Font;
using PdfPCell = iTextSharp.text.pdf.PdfPCell;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;
using System.Data;

namespace Labaratorka01d01.Pages
{
    /// <summary>
    /// Логика взаимодействия для OtchetPage.xaml
    /// </summary>
    public partial class OtchetPage : Page
    {
        public OtchetPage()
        {
            InitializeComponent();
            MotnComoBox.Items.Add("Январь");
            MotnComoBox.Items.Add("Февраль");
            MotnComoBox.Items.Add("Март");
            MotnComoBox.Items.Add("Апрель");
            MotnComoBox.Items.Add("Май");
            MotnComoBox.Items.Add("Июнь");
            MotnComoBox.Items.Add("Июль");
            MotnComoBox.Items.Add("Август");
            MotnComoBox.Items.Add("Сентябрь");
            MotnComoBox.Items.Add("Октябрь");
            MotnComoBox.Items.Add("Ноябрь");
            MotnComoBox.Items.Add("Декабрь");
        }

        private void BtnOthchetBack_Click(object sender, RoutedEventArgs e)
        {
            Nav.GoBack();
        }

        private void BtnOthchetPDF_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream($"Ведомость оплаты за электроэнергию {MotnComoBox.Text} за месяц.pdf", FileMode.Create));
                doc.Open();
                BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                Font font = new Font(baseFont, Font.DEFAULTSIZE, Font.NORMAL);
                PdfPTable table = new PdfPTable(5);
                PdfPCell cell = new PdfPCell(new Phrase($"Ведомость оплаты за электроэнергию {MotnComoBox.Text} за месяц", font));
                cell.Colspan = 5;
                cell.HorizontalAlignment = 1;
                cell.Border = 0;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Номер лицевого счета", font));
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Фамилия, имя, отчество", font));
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Кол-во киловатт", font));
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Тариф", font));
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Сумма к оплате", font));
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);
                var summ = 0;
                foreach (var item in Connect.Context.Uchet.ToList())
                {
                    table.AddCell(new Phrase(item.NumbChet.ToString(), font));
                    table.AddCell(new Phrase(item.Clients.FullName.ToString(), font));
                    table.AddCell(new Phrase(item.Kw.ToString(), font));
                    table.AddCell(new Phrase(item.Rate.ToString(), font));
                    table.AddCell(new Phrase((item.Rate * item.Kw).ToString(), font));
                    summ += (int)(item.Rate * item.Kw);
                }
                table.AddCell(new Phrase("", font));
                table.AddCell(new Phrase("", font));
                table.AddCell(new Phrase("", font));
                table.AddCell(new Phrase("Итог", font));
                table.AddCell(new Phrase(summ.ToString(), font));
                doc.Add(table);
                doc.Close();
                MessageBox.Show("Pdf-документ сохранен");
            }
            catch
            {
                MessageBox.Show("Pdf-документ не сохранен", "Ошибка!");
            }
        }

        private void BtnOthchetExcel_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application app = new Excel.Application()
            {
                Visible = true,
                SheetsInNewWorkbook = 2
            };
            Excel.Workbook workbook = app.Workbooks.Add(Type.Missing); app.DisplayAlerts = false;
            Excel.Worksheet sheet = (Excel.Worksheet)app.Worksheets.get_Item(1); 
            sheet.Name = "Отчёт";
            sheet.Cells[1, 1] = "Номер лицевого счета"; 
            sheet.Cells[1, 2] = "Фамилия, имя, отчество";
            sheet.Cells[1, 3] = "Кол-во киловатт"; 
            sheet.Cells[1, 4] = "Тариф";
            sheet.Cells[1, 5] = "Сумма к оплате";
            var currentRow = 2;
            var uchet = Connect.Context.Uchet.ToList();
            decimal summ = 0;
            foreach (var item in uchet)
            {
                if (item.MothPay == MotnComoBox.SelectedIndex+1)
                {
                    sheet.Cells[currentRow, 1] = item.NumbChet;
                    sheet.Cells[currentRow, 2] = item.Clients.FullName;
                    sheet.Cells[currentRow, 3] = item.Kw;
                    sheet.Cells[currentRow, 4] = item.Rate;
                    sheet.Cells[currentRow, 5] = item.Rate * item.Kw;
                    summ += (decimal)(item.Rate * item.Kw);
                    currentRow++;
                }
                
            }
            sheet.Cells[currentRow, 1] = "Итого                                                     ";
            sheet.Cells[currentRow, 5] = summ.ToString();

            Excel.Range rang = sheet.get_Range("A1", "G7"); rang.Cells.Font.Name = "Times New Roman";

            rang.Cells.Font.Size = 10; rang.Font.Bold = true;
            rang.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
            rang.Borders.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
