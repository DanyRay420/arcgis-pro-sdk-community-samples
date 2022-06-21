/*

   Copyright 2022 Esri

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       https://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.

   See the License for the specific language governing permissions and
   limitations under the License.

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcGIS.Core.CIM;
using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using ArcGIS.Desktop.Catalog;
using ArcGIS.Desktop.Core;
using ArcGIS.Desktop.Editing;
using ArcGIS.Desktop.Extensions;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Framework.Dialogs;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Desktop.Mapping;

namespace SymbolSearcherControl
{
  internal class PickStyleXFile : Button
  {
    protected override void OnClick()
    {
      //esri_browseDialogFilters_styleFiles
      //Create instance of BrowseProjectFilter using the id for Pro's file geodatabase filter
      BrowseProjectFilter bf = new BrowseProjectFilter("esri_browseDialogFilters_geodatabases");
      //Display the filter in an Open Item dialog
      OpenItemDialog aNewFilter = new OpenItemDialog
      {
        Title = "Open Geodatabases",
        InitialLocation = @"C:\Data",
        MultiSelect = false,
        //Set the BrowseFilter property to Pro's Geodatabase filter.
        BrowseFilter = bf
      };
      bool? ok = aNewFilter.ShowDialog();
    }
  }
}
