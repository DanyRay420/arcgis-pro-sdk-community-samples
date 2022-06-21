//   Copyright 2017 Esri
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
using System.Threading.Tasks;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.TaskAssistant;
using ArcGIS.Desktop.TaskAssistant.Exceptions;

namespace TasksSDK
{
  /// <summary>
  /// Button which implements the OpenTaskAsync API method.
  /// </summary>
  /// <remarks>
  /// The OpenTaskAsync API method takes an .esriTasks file as a parameter.  This task file will be added to the 
  /// project and loaded into the Tasks pane. The method returns a unique identifier which represents the task item.
  /// Use this identifier for other Tasks API calls.
  /// </remarks>
  internal class OpenTask : Button
  {
    protected override async void OnClick()
    {
      // pass an .esriTasks File and it will be added to project and loaded in the Tasks pane
      try
      {
        string taskFile = @"c:\Tasks\Project Exploration Tasks.esriTasks";
        if (!System.IO.File.Exists(taskFile))
        {
          ArcGIS.Desktop.Framework.Dialogs.MessageBox.Show("Cannot find file " + taskFile + ". Check file location.");
          return;
        }

      //Guid guid = await TaskAssistantModule.OpenTaskAsync(taskFile); 2.x
      Guid guid = await TaskAssistantFactory.Instance.OpenTaskFileAsync(taskFile);

      // keep the guid for CloseTaskAsync
        Module1.Current.taskGuid = guid;
      }
      catch (OpenTaskException e)
      {
        ArcGIS.Desktop.Framework.Dialogs.MessageBox.Show(e.Message);
      }
    }
  }
}
