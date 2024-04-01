using System.ComponentModel;
using System.Runtime.CompilerServices;

#nullable enable
namespace ViewModels.Base;

public abstract class BindableBase : INotifyPropertyChanged
{
    public BindableBase()
    {

    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected bool SetPropertyValue<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", params string[] dependentProperties)
    {
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
        {
            return false;
        }

        backingStore = value;
        OnPropertyChanged(propertyName);
        foreach (var dependentPropertyName in dependentProperties)
        {
            OnPropertyChanged(dependentPropertyName);
        }
        return true;
    }

    public virtual void OnPropertyChanged(string property)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
}
