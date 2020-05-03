using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Core.ConfigurationOptions
{
    public class StorageOptions : IStorageOptions
    {
        public string DBConnectionString { get; set; }
    }
}
