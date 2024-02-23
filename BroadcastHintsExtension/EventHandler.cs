using BroadcastHintExtension.Structures;
using Exiled.API.Features;
using UncomplicatedCustomRoles.API.Features;
using UncomplicatedCustomRoles.Structures;

namespace BroadcastHintExtension
{
    internal class EventHandler
    {
        public ICustomRoleEvent OnSpawned(ICustomRoleEvent Spawning)
        {
            CallEvent(CustomRoleEvent.OnSpawned, Spawning);
            return Spawning;
        }

        public ICustomRoleEvent OnDying(ICustomRoleEvent Dying)
        {
            CallEvent(CustomRoleEvent.OnDied, Dying);
            return Dying;
        }

        public ICustomRoleEvent OnDamaging(ICustomRoleEvent Damage)
        {
            CallEvent(CustomRoleEvent.OnDamaging, Damage);
            return Damage;
        }

        public ICustomRoleEvent OnInteractingElevator(ICustomRoleEvent Interaction)
        {
            CallEvent(CustomRoleEvent.OnInteractingElevator, Interaction);
            return Interaction;
        }

        public ICustomRoleEvent OnWarheadActivation(ICustomRoleEvent Activation)
        {
            CallEvent(CustomRoleEvent.OnWarheadActivation, Activation);
            return Activation;
        }

        public ICustomRoleEvent OnGeneratorActivation(ICustomRoleEvent Generator)
        {
            CallEvent(CustomRoleEvent.OnGenerationActivation, Generator);
            return Generator;
        }

        public ICustomRoleEvent OnGeneratorDeactivation(ICustomRoleEvent Generator)
        {
            CallEvent(CustomRoleEvent.OnGenerationDeactivation, Generator);
            return Generator;
        }

        public void CallEvent(CustomRoleEvent Event, ICustomRoleEvent BaseEvent)
        {
            Player Player = BaseEvent.Player;
            if (Plugin.Istance.Config.Events.ContainsKey(Manager.Get(Player).Id) && Plugin.Istance.Config.Events[BaseEvent.Role.Id].ContainsKey(Event))
            {
                IBroadcastHint EventBase = Plugin.Istance.Config.Events[Manager.Get(Player).Id][Event];
                if (EventBase.BroadcastDuration > 0 && EventBase.BroadcastContent != string.Empty)
                {
                    if (EventBase.BroadcastVisibility == BroadcastVisibility.All)
                    {
                        Map.Broadcast(EventBase.BroadcastDuration, EventBase.BroadcastContent);
                    } else
                    {
                        Player.Broadcast(EventBase.BroadcastDuration, EventBase.BroadcastContent);
                    }
                }
                if (EventBase.HintDuration > 0 && EventBase.HintContent != string.Empty)
                {
                    Player.ShowHint(EventBase.HintContent, EventBase.HintDuration);
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
        }
    }
}
