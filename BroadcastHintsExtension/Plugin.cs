using BroadcastHintExtension.Elements;
using BroadcastHintExtension.Structures;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using UncomplicatedCustomRoles.API.Features;
using UncomplicatedCustomRoles.Structures;

namespace BroadcastHintExtension
{
    internal class Plugin : Plugin<Config>
    {
        public override string Name => "BroadcastHintExtension";
        public override string Prefix => "BroadcastHintExtension";
        public override string Author => "FoxWorn3365";
        public override Version Version => new(1, 0, 0);
        public override Version RequiredExiledVersion => new(8, 8, 0);
        public static Plugin Istance;
        public override void OnEnabled()
        {
            Istance = this;

            foreach (KeyValuePair<int, Dictionary<UCREvents, BroadcastHint>> CustomRole in Config.Events)
            {
                foreach (KeyValuePair<UCREvents, BroadcastHint> BroadcastHint in CustomRole.Value)
                {
                    Events.Listen(BroadcastHint.Key, (ICustomRoleEvent Event) =>
                    {
                        if (Event.Role.Id == CustomRole.Key)
                        {
                            IBroadcastHint EventBase = Config.Events[Event.Role.Id][Event.EventType];
                            if (EventBase.BroadcastDuration > 0 && EventBase.BroadcastContent != string.Empty)
                            {
                                if (EventBase.BroadcastVisibility == BroadcastVisibility.All)
                                {
                                    Map.Broadcast(EventBase.BroadcastDuration, EventBase.BroadcastContent);
                                }
                                else
                                {
                                    Event.Player.Broadcast(EventBase.BroadcastDuration, EventBase.BroadcastContent);
                                }
                            }
                            if (EventBase.HintDuration > 0 && EventBase.HintContent != string.Empty)
                            {
                                Event.Player.ShowHint(EventBase.HintContent, EventBase.HintDuration);
                            }
                            if (EventBase.CassieMessage != null && EventBase.CassieMessage != string.Empty)
                            {
                                if (EventBase.CassieSubtitles != null && EventBase.CassieSubtitles != string.Empty)
                                {
                                    Cassie.MessageTranslated(EventBase.CassieMessage, EventBase.CassieSubtitles);
                                }
                                else
                                {
                                    Cassie.Message(EventBase.CassieMessage);
                                }
                            }
                        }
                        return Event;
                    });
                }
            }

            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Events.ClearAllListeners();

            Istance = null;

            base.OnDisabled();
        }
    }
}
