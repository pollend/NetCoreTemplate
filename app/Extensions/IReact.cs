using System;
using Microsoft.AspNetCore.Html;

namespace app.Extensions
{
    public interface IReact
    {
        public IHtmlContent Component<T>(String name, T props, String tag = "div", String id = null);
        public IHtmlContent ReactBindComponents();
    }
}