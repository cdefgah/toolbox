using DevExpress.Maui.Pdf;

using ViewModels.Base;

namespace MauiPdfViewer.ViewModels;

public class MainViewModel : BaseViewModel
{

    public override async Task OnAppearedAsync()
    {
        await base.OnAppearedAsync();

        await Task.Run(() => 
        {
            PdfDocumentSource = PdfDocumentSource.FromFile("sample.pdf");
            OnPropertyChanged(nameof(PdfDocumentSource));
        });
    }

    public PdfDocumentSource? PdfDocumentSource { get; set; }
}
