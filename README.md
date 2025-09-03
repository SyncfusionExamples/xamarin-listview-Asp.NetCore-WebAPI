# Learn easy way to consume ASP.NET Core Web API in Xamarin application

This sample demonstrates the easy steps to consume the [ASP.Net Core Web API](https:\ej2services.syncfusion.com\production\web-services\api\Orders) service in Syncfusion Xamarin.Forms [ListView](https://help.syncfusion.com/xamarin/sflistview/getting-started).

## Sample

```xaml
<Grid >
    <Grid.RowDefinitions>
        <RowDefinition Height="50"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <Label Text="Load data from web Api" BackgroundColor="SlateBlue" FontSize="18" FontAttributes="Bold" TextColor="White" VerticalTextAlignment="Center" HorizontalTextAlignment="Center"/>
    <syncfusion:SfListView x:Name="listView" ItemSize="90" ItemSpacing="5" Grid.Row="1"
                            BackgroundColor="AliceBlue" ItemsSource="{Binding Items}">
        <syncfusion:SfListView.ItemTemplate>
            <DataTemplate>
                <Frame BorderColor="#757575" Padding="5">
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="*"/>
                            <ColumnDefinition Width="*"/>
                        </Grid.ColumnDefinitions>
                        <Grid.RowDefinitions>
                            <RowDefinition Height="Auto"/>
                            <RowDefinition Height="Auto"/>
                            <RowDefinition Height="Auto"/>
                        </Grid.RowDefinitions>
                        <code>
                        . . .
                        . . .
                        <code>
                    </Grid>
                </Frame>
            </DataTemplate>
        </syncfusion:SfListView.ItemTemplate>
    </syncfusion:SfListView>
</Grid>

ViewModel.cs:
WebAPIService webAPIService;

webAPIService = new WebAPIService();
GetDataFromWebAPI();

async void GetDataFromWebAPI()
{
    Items = await webAPIService.RefreshDataAsync();
}
```