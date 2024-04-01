using Services.Interfaces;

using MauiPdfViewer.ViewModels;

using Views.Base;

namespace MauiPdfViewer;

public partial class MainPage : CustomContentPageBase
{

    public MainPage(IPluggablePageHandler pluggablePageHandler, MainViewModel mainViewModel) : base(pluggablePageHandler)
    {
        InitializeComponent();
        BindingContext = mainViewModel;
    }
}
