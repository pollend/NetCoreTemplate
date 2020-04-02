using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Html;

namespace app.Extensions
{
    public class React : IReact
    {
        private class ReactComponent {
            public String Name { get; }
            public String Id { get; }
            
            public Object Prop { get; }

            public ReactComponent(String name, String id, Object prop)
            {
                Name = name;
                Id = id;
                Prop = prop;
            }
        }
        
        private readonly List<ReactComponent> _reactComponents = new List<ReactComponent>();
        
        public IHtmlContent Component<T>(String name, T props, String tag = "div", String id = null)
        {
            if (id == null)
            {
                var bytes = new byte[16];
                using (var rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(bytes);
                }
                id = "React_" + BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
            _reactComponents.Add(new ReactComponent(name, id, props));
            return new HtmlString($@"<{tag} id='{id}'></{tag}>");
        }

        public IHtmlContent ReactBindComponents()
        {
            StringBuilder sb = new StringBuilder();
            // var builder = new HtmlContentBuilder();
            sb.Append("<script>");
            foreach (var component in _reactComponents)
            {
                // component.Name
                var json = JsonSerializer.Serialize(component.Prop);
                sb.Append(
                    $" ReactDOM.hydrate(React.createElement({component.Name},{json}),document.getElementById('{component.Id}'));");
            }
            sb.Append("</script>");
            return new HtmlString(sb.ToString());
        }
    }
}