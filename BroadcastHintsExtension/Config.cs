using BroadcastHintExtension.Elements;
using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace BroadcastHintExtension
{
    internal class Config : IConfig
    {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;
        [Description("Do enable the debug (developer) mode?")]
        public bool Debug { get; set; } = false;
        [Description("A list of all events")]
        public Dictionary<int, Dictionary<UCREvents, BroadcastHint>> Events { get; set; } = new()
        {
            { 1, new()
                {
                    { UCREvents.Dying, new() }
                }
            }
        };
    }
}
