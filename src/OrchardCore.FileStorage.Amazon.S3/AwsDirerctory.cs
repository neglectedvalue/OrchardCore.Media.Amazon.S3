﻿namespace OrchardCore.FileStorage.Amazon.S3
{
    using System;
    using FileStorage;
    
    public class AwsDirectory : IFileStoreEntry
    {
        private readonly string _path;
        private readonly DateTime _lastModifiedUtc;
        private readonly string _name;
        private readonly string _directoryPath;

        public AwsDirectory(string path, DateTime lastModifiedUtc)
        {
            _path = path;
            _lastModifiedUtc = lastModifiedUtc;
            _name = System.IO.Path.GetFileName(path);
            _directoryPath = _path.Length > _name.Length ?
                _path.Substring(0, _path.Length - _name.Length - 1) : String.Empty;
        }

        public string Path => _path;

        public string Name => _name;

        public string DirectoryPath => _directoryPath;

        public long Length => 0;

        public DateTime LastModifiedUtc => _lastModifiedUtc;

        public bool IsDirectory => true;
    }
}