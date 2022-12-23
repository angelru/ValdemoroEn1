namespace ValdemoroEn1.Features;

public abstract partial class BaseViewModel : ObservableObject, IDisposable
{
    [ObservableProperty]
    private string _baseState;

    [ObservableProperty]
    private bool _isBusy;

    [ObservableProperty]
    private string _title = "";

    private bool _disposedValue;
    private readonly SemaphoreSlim _isBusyLock = new(1, 1);

    protected BaseViewModel()
    {
    }

    protected static ApiService ApiService { get; private set; } = new();

    protected async Task RunSafeAsync(Func<Task> task, bool stateLoading = true, string stateError = StateKey.Error)
    {
        await _isBusyLock.WaitAsync();

        try
        {
            NetworkAccess accessType = Connectivity.Current.NetworkAccess;

            if (accessType != NetworkAccess.Internet)
            {
                BaseState = StateKey.ConexError;
                return;
            }

            if (stateLoading)
                BaseState = StateKey.Loading;

            await task();

            if (stateLoading)
                BaseState = StateKey.Success;
        }
        catch (Exception ex)
        {
            _ = ex.Message;
            BaseState = stateError;
        }
        finally
        {
            _isBusyLock.Release();
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _isBusyLock?.Dispose();
            }

            _disposedValue = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
