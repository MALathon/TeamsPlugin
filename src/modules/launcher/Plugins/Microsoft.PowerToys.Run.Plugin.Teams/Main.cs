using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Wox.Plugin;

namespace Microsoft.PowerToys.Run.Plugin.Teams
{
    /// <summary>
    /// PowerToys Run plugin for Microsoft Teams integration.
    /// </summary>
    public class Main : IPlugin
    {
        /// <summary>
        /// Gets the unique identifier for this plugin.
        /// </summary>
        public static string PluginID => "6A122269-8B3F-4324-85F5-165A870F5D9C";

        private PluginInitContext? _context;
        private string? _icoPathDark;
        private string? _icoPathLight;

        /// <summary>
        /// Gets the display name of the plugin.
        /// </summary>
        public string Name => "Teams";

        /// <summary>
        /// Gets the description of the plugin.
        /// </summary>
        public string Description => "Quick access to Microsoft Teams functions";

        /// <summary>
        /// Initializes the plugin with the provided context.
        /// </summary>
        /// <param name="context">The plugin initialization context.</param>
        public void Init(PluginInitContext context)
        {
            _context = context;
            _icoPathDark = Path.Combine(context.CurrentPluginMetadata.PluginDirectory, "Images", "teams.dark.png");
            _icoPathLight = Path.Combine(context.CurrentPluginMetadata.PluginDirectory, "Images", "teams.light.png");
        }

        /// <summary>
        /// Handles the search query and returns matching results.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <returns>A list of results matching the query.</returns>
        public List<Result> Query(Query query)
        {
            var results = new List<Result>();

            if (string.IsNullOrWhiteSpace(query.Search))
            {
                return results;
            }

            var terms = query.Search.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (terms.Length == 0)
            {
                return results;
            }

            switch (terms[0].ToLowerInvariant())
            {
                case "n":
                    results.Add(CreateNewMessageResult(terms.Skip(1).ToArray()));
                    break;
            }

            return results;
        }

        private Result CreateNewMessageResult(string[] recipients)
        {
            var title = "New Teams Message";
            var subtitle = recipients.Length > 0
                ? $"Start chat with {string.Join(", ", recipients)}"
                : "Start new chat";

            return new Result
            {
                Title = title,
                SubTitle = subtitle,
                IcoPath = _context?.API?.GetTheme().ApplicationTheme == Theme.Light ? _icoPathLight : _icoPathDark,
                Action = _ =>
                {
                    // TODO: Implement Teams chat creation
                    return true;
                }
            };
        }
    }
}
