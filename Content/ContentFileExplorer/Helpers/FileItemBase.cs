﻿using ArcGIS.Desktop.Framework.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentFileExplorer.Helpers
{
	public class FileItemBase : PropertyChangedBase
	{
		private static FileItemBase LazyloadChild = new FileItemBase();

		public FileItemBase()
		{
			IsSelected = false;
			Children = new List<FileItemBase>();
			Children.Add(LazyloadChild);
		}

		#region Common Properties

		private bool _isExpanded;
		public bool IsExpanded
		{
			get { return _isExpanded; }
			set
			{
				SetProperty(ref _isExpanded, value, () => IsExpanded);
				if (HasLazyloadChild)
				{
					Children.Remove(LazyloadChild);
					LoadChildren();
				}
			}
		}

		internal bool _isSelected;
		public virtual bool IsSelected
		{
			get { return _isSelected; }
			set
			{
				SetProperty(ref _isSelected, value, () => IsSelected);
			}
		}

		private string _name;
		public string Name
		{
			get { return _name; }
			set
			{
				SetProperty(ref _name, value, () => Name);
			}
		}

		private string _parentName;
		public string ParentName
		{
			get { return _parentName; }
			set
			{
				SetProperty(ref _parentName, value, () => ParentName);
			}
		}

		private List<FileItemBase> _children;
		public List<FileItemBase> Children
		{
			get { return _children; }
			set
			{
				SetProperty(ref _children, value, () => Children);
			}
		}

		#endregion Common Properties

		#region Child functions

		public virtual void LoadChildren() { }

		/// <summary>
		/// Returns true if this object's Children have not yet been populated.
		/// </summary>
		public bool HasLazyloadChild
		{
			get { return this.Children.Count == 1 && this.Children[0] == LazyloadChild; }
		}

		#endregion Child functions
	}
}
