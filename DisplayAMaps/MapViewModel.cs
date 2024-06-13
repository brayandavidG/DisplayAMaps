using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Geometry;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Map = Esri.ArcGISRuntime.Mapping.Map;

using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.Tasks.Geocoding;
using Esri.ArcGISRuntime.UI;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;


namespace DisplayAMap.ViewModels;


internal class MapViewModel : INotifyPropertyChanged
{

    public MapViewModel()
    {
        _map = new Map();
        SetupMap();
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private Map _map;
    public Map Map
    {
        get => _map;
        set
        {
            _map = value;
            OnPropertyChanged();
        }
    }
    private GraphicsOverlayCollection? _graphicsOverlayCollection;
    public GraphicsOverlayCollection? GraphicsOverlays
    {
        get { return _graphicsOverlayCollection; }
        set
        {
            _graphicsOverlayCollection = value;
            OnPropertyChanged();
        }
    }


    private void SetupMap()
    {

        // Create a new map with a 'topographic vector' basemap.
        Map = new Map(BasemapStyle.ArcGISTopographic);


        
    }

}


