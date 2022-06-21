/*

   Copyright 2017 Esri

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

namespace ProSqlExpressDb
{

    /// <summary>
    /// Pro SQL attribute column information
    /// </summary>
    public class ProSqlColumnInfo
    {
        /// <summary>
        /// name of the attribute column
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// Alias of the attribute column name
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// .Net datatype of the attribute column
        /// </summary>
        public Type ColumnDataType { get; set; }
        
        /// <summary>
        /// Maximum length of the characters in the attribute column
        /// </summary>
        public int ColumnLength { get; set; }
    }
}
