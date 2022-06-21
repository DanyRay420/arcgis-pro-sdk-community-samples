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
using System.Linq;
using System.Text;
using System.Windows.Input;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using System.Threading.Tasks;

namespace MapToolWithOverlayControl
{
  /// <summary>
  /// This sample provides a map tool that when you left click in the view will show the map coordinates of the click location in the top left corner of the view.
  /// </summary>
  /// <remarks>
  /// 1. In Visual Studio click the Build menu. Then select Build Solution.
  /// 2. Launch the debugger to open ArcGIS Pro.
  /// 3. ArcGIS Pro will open. 
  /// 4. With a map view active go to the Add-In tab and click the Show Coordinates tool.
  /// 5. Click within the map view and the coordinates of the location you clicked will be shown in a control in the top left corner of the view.
  /// ![UI](Screenshots/screenshot.png)
  /// </remarks>
  internal class Module1 : Module
  {
    private static Module1 _this = null;

    /// <summary>
    /// Retrieve the singleton instance to this module here
    /// </summary>
    public static Module1 Current
    {
      get
      {
        return _this ?? (_this = (Module1)FrameworkApplication.FindModule("MapToolWithOverlayControl_Module"));
      }
    }

    #region Overrides
    /// <summary>
    /// Called by Framework when ArcGIS Pro is closing
    /// </summary>
    /// <returns>False to prevent Pro from closing, otherwise True</returns>
    protected override bool CanUnload()
    {
      //TODO - add your business logic
      //return false to ~cancel~ Application close
      return true;
    }

    #endregion Overrides

  }
}
