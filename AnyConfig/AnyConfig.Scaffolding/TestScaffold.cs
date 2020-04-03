﻿using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.IO;

namespace AnyConfig.Scaffolding
{
    // this is reserved for testing of microsoft's behavior
    public class TestScaffold
    {
        public IConfigurationRoot Root { get; set; }
        public IConfiguration Config { get; set; }
        public TestScaffold(string path)
        {
            var connectionTest = ConfigurationManager.ConnectionStrings["test"];
            var appTest = ConfigurationManager.AppSettings["test"];
            var nlogTest = ConfigurationManager.GetSection("nlog");

            var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(path))
                .AddJsonFile("appsettings.json", optional: false);
            Root = builder.Build();
            Config = (IConfiguration)Root;
            var boolSetting = Config["TestConfiguration:BoolSetting"];
        }
    }
}