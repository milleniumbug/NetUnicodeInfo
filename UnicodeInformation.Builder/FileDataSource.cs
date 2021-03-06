﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Unicode;

namespace System.Unicode.Builder
{
	public sealed class FileDataSource : IDataSource
	{
		private readonly string baseDirectory;

		public FileDataSource(string baseDirectory)
		{
			this.baseDirectory = Path.GetFullPath(baseDirectory);
		}

		public void Dispose()
		{
		}

		public Task<Stream> OpenDataFileAsync(string fileName)
		{
			return Task.FromResult<Stream>(File.OpenRead(Path.Combine(baseDirectory, fileName)));
		}
	}
}
