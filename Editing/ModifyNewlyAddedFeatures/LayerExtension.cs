/*

   Copyright 2019 Esri

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
using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using ArcGIS.Desktop.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifyNewlyAddedFeatures
{
  /// <summary>
  /// Extension method to search and retrieve rows
  /// </summary>
  public static class LayerExtensions
  {
    /// <summary>
    /// Performs a spatial query against a feature layer.
    /// </summary>
    /// <remarks>It is assumed that the feature layer and the search geometry are using the same spatial reference.</remarks>
    /// <param name="searchLayer">The feature layer to be searched.</param>
    /// <param name="searchGeometry">The geometry used to perform the spatial query.</param>
    /// <param name="spatialRelationship">The spatial relationship used by the spatial filter.</param>
    /// <returns>Cursor containing the features that satisfy the spatial search criteria.</returns>
    public static RowCursor Search(this BasicFeatureLayer searchLayer, Geometry searchGeometry, SpatialRelationship spatialRelationship)
    {
      RowCursor rowCursor = null;
      // define a spatial query filter
      var spatialQueryFilter = new SpatialQueryFilter
      {
        // passing the search geometry to the spatial filter
        FilterGeometry = searchGeometry,
        // define the spatial relationship between search geometry and feature class
        SpatialRelationship = spatialRelationship
      };
      // apply the spatial filter to the feature layer in question
      rowCursor = searchLayer.Search(spatialQueryFilter);
      return rowCursor;
    }
  }
}
