using System;
using Microsoft.AspNetCore.Html;

namespace app.Extensions
{
    public interface IManifest
    {
        public String ByKey(String file, String key);

        public IHtmlContent Script(String key);
        public IHtmlContent Style(String key);

        public IHtmlContent Script(String manifest, String key);
        public IHtmlContent Style(String manifest, String key);
    }
}
