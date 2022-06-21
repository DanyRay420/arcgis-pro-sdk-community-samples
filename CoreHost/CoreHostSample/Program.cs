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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ArcGIS.Core.Hosting;
using ArcGIS.Core.Data;
using System.Reflection;
using System.IO;

namespace CoreHostSample {

    #region Initializing Core Host
    //using ArcGIS.Core.Data;
    //There must be a reference to ArcGIS.CoreHost.dll
    //using ArcGIS.Core.Hosting;

	/// <summary>
	/// ArcGIS Pro based console application reading from File Geodatabase
	/// </summary>
	/// <remarks>
	/// 1. Download the Community Sample data (see under the "Resources" section for downloading sample data).  Make sure that the Sample data is unzipped in c:\data and "C:\Data\SDK\SDK.gdb" is available.
	/// 1. Open this solution in Visual Studio 
	/// 1. Click the build menu and select Build Solution.
	/// 1. Specify a valid path to a file geodatabase as your debug command line parameter 
	/// 1. Click the Start button to run the console app.
	/// 1. View the table definition in your file geodatabase
	/// ![UI](Screenshots/ConsoleWindow.png)
	/// 1. Once the output stops press any key to close the application.  
    /// 1. To reuse the ArcGIS Pro assemblies from the installation path, you can change the reference settings for 
    /// ArcGIS.Core.dll and ArcGIS.CoreHost.dll to be "Copy Local = False".
	/// </remarks>
	class Program {
        //[STAThread] must be present on the Application entry point
        [STAThread]
        static void Main(string[] args)
        {

        AppDomain currentDomain = AppDomain.CurrentDomain;
        currentDomain.AssemblyResolve += new ResolveEventHandler(ResolveProAssemblyPath);
            
            //Call Host.Initialize before constructing any objects from ArcGIS.Core
            try
            {
                //ArcGIS.Core.Hosting.Host.Initialize();
                PerformCoreHostTask(args);
            }
            catch (Exception e)
            {
                // Error (missing installation, no license, 64 bit mismatch, etc.)
                Console.WriteLine(string.Format("Initialization failed: {0}", e.Message));
                return;
            }

        }

        private static void PerformCoreHostTask(string[] args)
        {
            Host.Initialize();
            //if (args.Count() > 0) gdbPath = args[0];
            var gdbPath = args[0];
            try
            {
               
                //if we are here, ArcGIS.Core is successfully initialized
                using (var gdb = new Geodatabase(new FileGeodatabaseConnectionPath(new Uri(gdbPath, UriKind.Absolute))))
                {
                    IReadOnlyList<TableDefinition> definitions = gdb.GetDefinitions<FeatureClassDefinition>();
                    foreach (var fdsDef in definitions)
                    {
                        Console.WriteLine(TableString(fdsDef as TableDefinition));
                    }
                }
                Console.WriteLine("Press any key to close this app.");
                Console.ReadKey();
                
            }
            catch (Exception e)
            {
                // Error (missing installation, no license, 64 bit mismatch, etc.)
                Console.WriteLine(string.Format("Cannot read file Geodatabase [{0}] error: {1}", gdbPath, e.Message));
                return;
            }
        }

        private static string TableString(TableDefinition table)
        {
            string alias = table.GetAliasName();
            string name = table.GetName();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("{0} ({1})", alias.Length > 0 ? alias : name, name));
            sb.AppendLine(new string('-', 80));
            foreach (var fld in table.GetFields())
            {
                sb.Append(string.Format("{0,-20}", fld.AliasName ?? fld.Name));
                sb.Append(string.Format("{0,-14} ({1}) ", fld.FieldType.ToString(), fld.Length));
                if (fld.IsNullable || fld.IsRequired)
                {

                    string sep = fld.IsNullable && fld.IsRequired ? ", " : "";
                    sb.Append(string.Format("({0}{1}{2})", fld.IsNullable ? "Null" : "", sep, fld.IsRequired ? "Required" : ""));
                }
                sb.Append("\r\n");
            }
            sb.Append("\r\n");
            return sb.ToString();
        }

        static Assembly ResolveProAssemblyPath(object sender, ResolveEventArgs args)
        {
            string folderPath = @"C:\Program Files\ArcGIS\Pro\bin"; //Get this from registry
            string assemblyPath = Path.Combine(folderPath, new AssemblyName(args.Name).Name + ".dll");
            if (!File.Exists(assemblyPath)) return null;
            Assembly assembly = Assembly.LoadFrom(assemblyPath);
            return assembly;
        }

    }
    #endregion
}
