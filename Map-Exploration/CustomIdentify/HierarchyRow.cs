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
using System.Threading.Tasks;

namespace CustomIdentify
{
    /// <summary>
    /// Representation of the selected feature's Relationship Hierarchy
    /// </summary>
    public class HierarchyRow {
        private List<HierarchyRow> _children = null;
        /// <summary>
        /// Name to display
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Type for group by
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// Related child rows
        /// </summary>
        public List<HierarchyRow> children
        {
            get
            {
                if (_children == null)
                    _children = new List<HierarchyRow>();
                return _children;
            }
            set
            {
                _children = null;
                _children = value;
            }
        }
    }
}
