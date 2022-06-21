//   Copyright 2019 Esri
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at

//       https://www.apache.org/licenses/LICENSE-2.0

//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using ArcGIS.Desktop.Core;
using ArcGIS.Desktop.Core.Portal;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Desktop.Mapping;

namespace GalleryDemo
{
  /// <summary>
  /// The Inline gallery
  /// </summary>
  internal class WebMapsGallery : Gallery
  {
    private bool _isInitialized;

    public WebMapsGallery()
    {
      Initialize();
      //fire the click event even if the item is currently selected.
      this.AlwaysFireOnClick = true;
    }
    /// <summary>
    /// Called when a gallery item is clicked.
    /// </summary>
    /// <param name="item"></param>
    protected override void OnClick(object item)
    {

      //open the Webmap when the gallery item is clicked
      OpenWebMapAsync(item);
      base.OnClick(item);
    }

    /// <summary>
    /// Called when the gallery is initialized on the Pro ribbon
    /// </summary>
    private async void Initialize()
    {
      if (_isInitialized)
        return;
      _isInitialized = true;
      //Get the webmaps from ArcGIS Online
      var lstWebmapItems = await GetWebMapsAsync();

      //Add the webmaps to the gallery 
      foreach (var dataItem in lstWebmapItems)
        Add(dataItem);
    }


    #region Get Webmaps and open it.
    private static string _arcgisOnline = @"http://www.arcgis.com:80/";

    /// <summary>
    /// Gets a collection of web map items from ArcGIS Online
    /// </summary>
    /// <returns></returns>
    private async Task<List<WebMapItem>> GetWebMapsAsync()
    {
        var lstWebmapItems = new List<WebMapItem>();
        try
        {
            await QueuedTask.Run(async () =>
            {
                ArcGISPortal portal = ArcGISPortalManager.Current.GetPortal(new Uri(_arcgisOnline));
                PortalQueryParameters query = PortalQueryParameters.CreateForItemsOfType(PortalItemType.WebMap);

                PortalQueryResultSet<PortalItem> results = await ArcGIS.Desktop.Core.ArcGISPortalExtensions.SearchForContentAsync(portal, query);

                if (results == null)
                    return;

                foreach (var item in results.Results.OfType<PortalItem>())
                {
                    lstWebmapItems.Add(new WebMapItem(item));
                }
            });

        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
        }
        return lstWebmapItems;
    }
    /// <summary>
    /// Opens a web map item in a map pane.
    /// </summary>
    /// <param name="item"></param>
    private async void OpenWebMapAsync(object item)
    {

      if (item is WebMapItem)
      {
        WebMapItem clickedWebMapItem = (WebMapItem)item;
        await QueuedTask.Run(() =>
        {
          //Open WebMap
          var currentItem = ItemFactory.Instance.Create(clickedWebMapItem.ID, ItemFactory.ItemType.PortalItem);
          if (MapFactory.Instance.CanCreateMapFrom(currentItem))
          {
               var newMap = MapFactory.Instance.CreateMapFromItem(currentItem);
               FrameworkApplication.Panes.CreateMapPaneAsync(newMap);          
          }
        });
      }
    }
    #endregion
  }
}
