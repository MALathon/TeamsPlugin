using System;
using System.Collections.Generic;
using Wox.Plugin;

namespace Microsoft.PowerToys.Run.Plugin.Teams
{
    public class Main : IPlugin
    {
        public static string PluginID => "6A122269-8B3F-4324-85F5-165A870F5D9C";

        private PluginInitContext _context;

        public void Init(PluginInitContext context)
        {
            _context = context;
        }

        public List<Result> Query(Query query)
        {
            var results = new List<Result>();

            if (query?.Search == null)
                return results;

            // Basic command handling
            if (query.Search.StartsWith("n ", StringComparison.OrdinalIgnoreCase))
            {
                var recipient = query.Search[2..].Trim();
                if (string.IsNullOrEmpty(recipient))
                {
                    // New message without recipient
                    results.Add(new Result
                    {
                        Title = "New Teams Message",
                        SubTitle = "Open new message window in Teams",
                        IcoPath = "Images/teams.dark.png",
                        Action = e => 
                        {
                            System.Diagnostics.Process.Start("msteams", ":/l/chat/0/0");
                            return true;
                        }
                    });
                }
                else
                {
                    // New message with recipient
                    results.Add(new Result
                    {
                        Title = $"Message {recipient}",
                        SubTitle = $"Start new Teams chat with {recipient}",
                        IcoPath = "Images/teams.dark.png",
                        Action = e =>
                        {
                            System.Diagnostics.Process.Start("msteams", $":/l/chat/0/0?users={recipient}");
                            return true;
                        }
                    });
                }
            }

            return results;
        }
    }
}
