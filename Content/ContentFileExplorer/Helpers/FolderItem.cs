﻿using ArcGIS.Desktop.Framework.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentFileExplorer.Helpers
{
	public class FolderItem : FileItemBase
	{
		private FolderItem _parentFolderItem = null;

		public FolderItem(string theFolder)
		{
			Folder = theFolder;
		}

		public FolderItem(FolderItem parentFolderItem, string theFolder)
		{
			_parentFolderItem = parentFolderItem;
			Folder = theFolder;
		}

		private string _folder = string.Empty;

		public string Folder
		{
			get { return _folder; }
			set
			{
				SetProperty(ref _folder, value, () => Folder);
				base.Name = Path.GetFileName(_folder);
			}
		}

		public override void LoadChildren()
		{
			// use this directory as parent and first find all child directories
			var directories = Directory.GetDirectories(_folder);
			foreach (string directory in directories)
			{
				if (Path.GetExtension(directory).ToLower().EndsWith("gdb"))
				{
					// is geodatabase
					Children.Add(new GdbDbItem(this, directory));
				}
				else
				{
					// is folder
					Children.Add(new FolderItem(this, directory));
				}
			}
			// also we need to check for shape files
			var shapeFiles = Directory.GetFiles(_folder, "*.shp");
			foreach (string shapeFile in shapeFiles)
			{
				Children.Add(new GdbItem(this, Path.GetFileName(shapeFile)));
			}
		}
	}
}
