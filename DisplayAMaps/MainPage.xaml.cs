using Esri.ArcGISRuntime.UI;
using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Threading.Tasks;
using Esri.ArcGISRuntime.Maui;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Tasks.NetworkAnalysis;



namespace DisplayAMaps
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();


            MainMapView.PropertyChanged += (object? sender, PropertyChangedEventArgs e) =>
            {
                // The map view's location display is initially null, so check for a location display property change before enabling it.
                if (e.PropertyName == nameof(LocationDisplay))
                {
                    _ = DisplayDeviceLocationAsync();
                }
            };

        }
 

        private async Task DisplayDeviceLocationAsync()
        {

            PermissionStatus status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

            MainMapView.LocationDisplay.IsEnabled = status == PermissionStatus.Granted || status == PermissionStatus.Restricted;
            MainMapView.LocationDisplay.AutoPanMode = LocationDisplayAutoPanMode.Recenter;

        }
        private string _routeServiceUrl = "https://route.arcgis.com/arcgis/rest/services/World/Route/NAServer/Route_World";

        public async Task<RouteResult> CalculateRouteAsync(MapPoint startPoint, MapPoint endPoint)
        {
            // Configure authentication if required
            // AuthenticationManager.Current.ChallengeHandler = new ChallengeHandler(async (info) => { /* handle authentication */ });

            // Create a new route task with the route service URL
            RouteTask routeTask = await RouteTask.CreateAsync(new Uri(_routeServiceUrl));

            // Create a route parameters object and set properties
            RouteParameters routeParams = await routeTask.CreateDefaultParametersAsync();

            // Create stops for the route
            List<Stop> stops =
            [
                new(startPoint),
                new(endPoint)
            ];

            // Set the stops for the route
            routeParams.SetStops(stops);

            // Solve the route
            RouteResult routeResult = await routeTask.SolveRouteAsync(routeParams);

            return routeResult;
        }


    }
    }











