namespace Services.Interfaces;

public interface IPluggablePageHandler
{
    public Task OnPageAppearingAsync(object bindingContext);
    public Task OnPageDisappearingAsync(object bindingContext);
}

