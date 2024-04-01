using ViewModels.Base;

using Services.Interfaces;

namespace Services;

public class PluggablePageHandler : IPluggablePageHandler
{
    public async Task OnPageAppearingAsync(object bindingContext)
    {
        if (bindingContext is BaseViewModel viewModel)
        {
            viewModel.OnAppeared();
            await viewModel.OnAppearedAsync();
        }
    }

    public async Task OnPageDisappearingAsync(object bindingContext)
    {
        if (bindingContext is BaseViewModel viewModel)
        {
            viewModel.OnDisappeared();
            await viewModel.OnDisappearedAsync();
        }
    }
}

