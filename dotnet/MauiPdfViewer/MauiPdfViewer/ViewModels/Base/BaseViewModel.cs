#nullable enable
namespace ViewModels.Base;

public abstract class BaseViewModel : BindableBase
{
    #region Constructors        
    protected BaseViewModel()
    {
       
    }
    #endregion

    #region PropertiesAndFields   

    private bool initialized;

    private bool isBusy;
    public bool IsBusy
    {
        get => isBusy;
        set => SetPropertyValue(ref isBusy, value, nameof(IsBusy), nameof(IsNotBusy));
    }

    public bool IsNotBusy => !IsBusy;

    #endregion

    #region InitializationMethods
    protected virtual void Initialize()
    {

    }

    protected virtual async Task InitializeAsync()
    {
        await Task.FromResult(0);
    }

    public virtual void OnAppeared()
    {
        if (!initialized)
        {
            try
            {
                Initialize();
            }
            finally
            {
                initialized = true;
            }
        }
    }

    public virtual async Task OnAppearedAsync()
    {
        if (!IsInitializedAsync)
        {
            try
            {
                await InitializeAsync();
            }
            finally
            {
                IsInitializedAsync = true;
            }
        }
    }

    public virtual void OnDisappeared()
    {

    }

    public virtual async Task OnDisappearedAsync()
    {
        await Task.FromResult(0);
    }

    #endregion

    #region UtilityMethods

    protected virtual void UpdateCommandStates()
    {

    }

    private bool isInitializedAsync;

    public bool IsInitializedAsync
    {
        get => isInitializedAsync;
        set => SetPropertyValue(ref isInitializedAsync, value);
    }
    #endregion
}