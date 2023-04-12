namespace ValdemoroEn1.Features;

public partial class SearchSchedulesRealTimePage : ContentPage
{
    private SearchSchedulesRealTimePageViewModel Vm => (SearchSchedulesRealTimePageViewModel)BindingContext;

    public SearchSchedulesRealTimePage(SearchSchedulesRealTimePageViewModel
        searchSchedulesRealTimePageViewModel)
    {
        InitializeComponent();
        BindingContext = searchSchedulesRealTimePageViewModel;

        Vm.StopMunicipalities.CollectionChanged += StopMunicipalities_CollectionChanged;
    }

    private void StopMunicipalities_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        double itemHeight = 35;
        int numberOfItems = Vm.StopMunicipalities.Count;

        MainThread.BeginInvokeOnMainThread(() =>
        {
            double height = numberOfItems * itemHeight;

            SearchCollectionView.HeightRequest = height switch
            {
                > 350 => 350,
                _ => height,
            };
        });
    }
}