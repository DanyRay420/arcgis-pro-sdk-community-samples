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
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace SLR_Analyst
{
	/// <summary>
	/// Interaction logic for SLR_DockpaneView.xaml
	/// </summary>
	public partial class SLR_DockpaneView : UserControl
	{
		public SLR_DockpaneView()
		{
			InitializeComponent();
		}
		
		private void Slider_DragCompleted(object sender, DragCompletedEventArgs e)
		{
			// Get Slider reference.
			var slider = sender as Slider;
			double value = slider.Value;

			// Pass to method in the ViewModel
			((SLR_DockpaneViewModel)this.DataContext).SliderUpdate(value);
		}
	}
}
