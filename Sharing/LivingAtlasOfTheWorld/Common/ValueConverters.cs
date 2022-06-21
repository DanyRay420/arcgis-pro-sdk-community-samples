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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using LivingAtlasOfTheWorld.Models;

namespace LivingAtlasOfTheWorld.Common {

   
    /// <summary>
    /// Converts Uri to string (returns the Thumbnail property)
    /// </summary>
    public class UriToString : IValueConverter
    {
        /// <summary>
        /// Returns the query string property or an empty string if the value is null
        /// </summary>
        /// <returns>The query string</returns>
        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {

           // Uri input = value as Uri;
            if (value == null)
                return string.Empty;
            else
                return value;
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("Converter cannot convert back.");
        }

    }


    /// <summary>
    /// Converts OnlineUri to string (returns the Query property)
    /// </summary>
    public class OnlineUriToString : IValueConverter {
        /// <summary>
        /// Returns the query string property or an empty string if the value is null
        /// </summary>
        /// <returns>The query string</returns>
        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture) {
            if (value == null)
                return "";
            if ((value as OnlineUri) == null)
                return "";
            OnlineUri val = value as OnlineUri;
            return val.Name;
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture) {
            throw new InvalidOperationException("Converter cannot convert back.");
        }

    }
    /// <summary>
    /// Converts the given bool to a Visibility
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter {

        /// <summary>
        /// Convert True to Visible and False to Hidden
        /// </summary>
        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture) {
            if (value == null)
                return Visibility.Hidden;
            bool val = (bool)value;
            return val ? Visibility.Visible : Visibility.Hidden;
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture) {
            throw new InvalidOperationException("Converter cannot convert back.");
        }

    }
}
