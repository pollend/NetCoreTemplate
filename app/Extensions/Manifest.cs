using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Html;
using Microsoft.Extensions.Hosting;

namespace app.Extensions
{
    public class Manifest : IManifest
    {
        private readonly IWebHostEnvironment _env;
        private Dictionary<String, String> _mapping = new Dictionary<string, string>();

        public Manifest(IWebHostEnvironment env)
        {
            _env = env;
        }

        public String ByKey(String file, String key)
        {
            if (_mapping.ContainsKey(key) && !_env.IsDevelopment())
            {
                return _mapping[key];
            }

            var contents = File.ReadAllText(file);
            var result = JsonSerializer.Deserialize<Dictionary<String, String>>(contents);
            foreach (var pair in result)
            {
                _mapping[pair.Key] = pair.Value;
            }

            return _mapping[key];
        }

        public IHtmlContent Script(String key) => Script(_env.WebRootPath + "/dist/asset-manifest.json", key);
        public IHtmlContent Style(String key) => Style(_env.WebRootPath + "/dist/asset-manifest.json", key);

        public IHtmlContent Script(String manifest, String key)
        {
            String script = ByKey(manifest, key);
            return new HtmlString($@"<script type=""text/javascript"" src=""{script}""></script>");
        }


        public IHtmlContent Style(String manifest, String key)
        {
            String link = ByKey(manifest, key);
            return new HtmlString($@"<link rel=""stylesheet"" href=""{link}"">");
        }
    }
}