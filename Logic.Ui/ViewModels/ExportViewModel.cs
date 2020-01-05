using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using De.HsFlensburg.LernkartenApp001.Business.Model.BusinessObjects;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.Wrapper;
using De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels.Common;
using System.Windows.Input;
using System.IO;
using IronPdf;

namespace De.HsFlensburg.LernkartenApp001.Logic.Ui.ViewModels
{
    public class ExportViewModel : AbstractViewModel
    {
        #region Commands
            private ICommand exportPDFCommand;
            public ICommand ExportPDFCommand { get { return exportPDFCommand; } }
        #endregion

        #region Properties
        public SetViewModel Set { get; set; }

        public CategoryViewModel category;
        public CategoryViewModel Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
                if(category != null) {
                    ButtonsEnabled = true;
                }
              
                OnPropertyChanged();
            }
        }

        private bool buttonsEnabled;
        public bool ButtonsEnabled
        {
            get
            {
                return buttonsEnabled;
            }
            set
            {
                buttonsEnabled = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public ExportViewModel (SetViewModel set)
        {
            this.Set = set;
            exportPDFCommand = new RelayCommand(this.ExportPDF, this.ReturnTrue);
        }

       
        private void ExportPDF()
        {
            Console.WriteLine("tew");

            string categoryName = category.Name;
       
            string html = "";
            
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < category.Collections[i].Count; j++)
                {
                    string title = category.Collections[i][j].Name;
                    string imgSrcFront = category.Collections[i][j].Front.ImageSourece;
                    string imgSrcBack = category.Collections[i][j].Back.ImageSourece;
                    string question = category.Collections[i][j].Front.Text;
                    string answer = category.Collections[i][j].Back.Text;

                    html += @"
                    <!DOCTYPE html>
                     <html>
                         <head>
                         <meta http-equiv='content-type' content='text/html;charset=UTF-8' />
                         <title>Paginated HTML</title>
                         <style type='text/css' media='print'>
                             div.page
                             {
                                 page-break-after: always;
                                 page-break-inside: avoid;
                             }
                         </style>
                         </head>
                         <body>
                            <div style='display:flex; flex-direction:column; font-family:Calibri Light;'>
                                <table style='width:100%'>
                                    <tr>
                                        <!--Vorderseite-->
                                        <td style='width:50%;'>
                                            <div style='border:1px solid #000; border-top-left-radius: 5px; border-bottom-left-radius: 5px; width:100%; display:flex; flex-direction:column;'>

                                                <p style='margin-left: 10px; margin-right: auto; margin-bottom:0px;'>" + categoryName + "</p>" +
                                                "<center><h1 class='margin' style = 'margin-top:0px;'>" + title + "</h1></center>" +
                                                "<center><img src='" + imgSrcFront + "' alt ='' style='margin-left: auto; margin-right: auto; height:150px; width:80%; border:1px solid #000;'></center>" +
                                                "<center><p> " + question + "</p></center>" +
                                                "<p style='margin-left:15px;'>" + (j * i + j + 1) + "</p>" +

                                            "</div>" +
                                        "</td>" +
                                        "<!--Rückseite-->" +
                                        "<td style='width:50%'>" +
                                            "<div style='border:1px solid #000; border-top-right-radius: 5px; border-bottom-right-radius: 5px; width:100%; display:flex; flex-direction:column;'>" +

                                               "<p style='margin-left: 10px; margin-right: auto; margin-bottom:0px;' >" + categoryName + "</p> " +
                                               "<center><h1 class='margin' style ='margin-top:0px;'>" + title + "</h1></center>" +
                                               "<center><img src='" + imgSrcBack + "' alt='' style='height:150px; width:80%; border:1px solid #000;'></center>" +
                                               "<center><p> " + answer + "</p></center>" +
                                               "<p style='margin-left:15px;'>" + (j * i + j + 1) + "</p>" +

                                            "</div>" +
                                        "</td>" +
                                    "</tr>" +
                                "</table>" +
                            "</div> " +
                        "</body>" +
                    "</html>";
                }
            }
          
            var renderer = new HtmlToPdf();
            PdfPrintOptions myOptions = new PdfPrintOptions() { MarginTop = 0, MarginBottom = 0, MarginLeft = 0, MarginRight = 0 };
            renderer.PrintOptions = myOptions;
            renderer.PrintOptions.CssMediaType = PdfPrintOptions.PdfCssMediaType.Screen;
            renderer.PrintOptions.PrintHtmlBackgrounds = true;
            renderer.PrintOptions.PaperSize = PdfPrintOptions.PdfPaperSize.A4;

            var pdf = renderer.RenderHtmlAsPdf(html);
            
      
            pdf.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "Lernkarten_"+categoryName+".Pdf"));
            System.Diagnostics.Process.Start("Lernkarten_" + categoryName + ".Pdf");
        }

        private bool ReturnTrue()
        {
            return true;
        }
    }
}
