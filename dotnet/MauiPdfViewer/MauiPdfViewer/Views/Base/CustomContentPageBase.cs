using Services.Interfaces;

namespace Views.Base;

public abstract class CustomContentPageBase : ContentPage
{
    private readonly IPluggablePageHandler pluggablePageHandler;

    public CustomContentPageBase(IPluggablePageHandler pluggablePageHandler)
    {
        this.pluggablePageHandler = pluggablePageHandler;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await pluggablePageHandler.OnPageAppearingAsync(BindingContext);
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        pluggablePageHandler.OnPageDisappearingAsync(BindingContext);
    }
}
