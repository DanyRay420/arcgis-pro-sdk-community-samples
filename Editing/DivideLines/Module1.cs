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

namespace DivideLines
{
  /// <summary>
  /// This sample provides a tool that divides a line into an equal number of parts or a number of parts of a given length.
  /// The sample creates a map tool that is similar to other editing tools in the Modify Features pane, in that it opens a control within the pane with a dialog for user input. It follows the MVVM pattern used by the editing tools.
  /// </summary>
  /// <remarks>
  /// 1. Debug through Visual Studio or compile and run ArcGIS Pro.
  /// 1. In Pro, add or create a map with lines or use FeatureTest.aprx from the community sample dataset
  /// 1. Select a single line in the map.
  /// 1. Click the Divide Lines tool in the Divide group within the Modify Features pane.
  /// ![UI](Screenshots/Screen1.png)
  /// 1. In the pane for Divide Lines, select the option and enter a value. Click on Divide.
  /// ![UI](Screenshots/Screen2.png)
  /// 1. The selected line should be divided and the selection cleared. 
  /// ![UI](Screenshots/Screen3.png)
  /// 1. The tool remains active to enable selection of other lines to repeat the process.
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
        return _this ?? (_this = (Module1)FrameworkApplication.FindModule("DivideLines_Module"));
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
