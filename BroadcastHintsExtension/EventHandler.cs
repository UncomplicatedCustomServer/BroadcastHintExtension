using BroadcastHintExtension.Structures;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Interfaces;
using Exiled.Events.EventArgs.Player;
using MEC;
using PluginAPI.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncomplicatedCustomRoles.API.Features;
using UnityEngine.UI;

namespace BroadcastHintExtension
{
    internal class EventHandler
    {
        public void OnSpawned(SpawnedEventArgs Spawning)
        {
            Timing.CallDelayed(0.5f, () =>
            {
                CallEvent(CustomRoleEvent.OnSpawned, Spawning);
            });
        }

        public void OnDying(DyingEventArgs Dying)
        {
            CallEvent(CustomRoleEvent.OnDied, Dying);
        }

        public void OnDamage(HurtEventArgs Hurted)
        {
            CallEvent(CustomRoleEvent.OnDamaged, Hurted);
        }

        public void OnDamaging(HurtingEventArgs Damage)
        {
            CallEvent(CustomRoleEvent.OnDamaging, Damage);
        }

        public void OnInteractingDoor(InteractingDoorEventArgs Interaction)
        {
            CallEvent(CustomRoleEvent.OnInteractingDoor, Interaction);
        }

        public void OnInteractingElevator(InteractingElevatorEventArgs Interaction)
        {
            CallEvent(CustomRoleEvent.OnInteractingElevator, Interaction);
        }

        public void CallEvent(CustomRoleEvent Event, IPlayerEvent BaseEvent)
        {
            CallEvent(Event, BaseEvent.Player);
        }

        public void CallEvent(CustomRoleEvent Event, Player Player)
        {
            if (Manager.HasCustomRole(Player) && Plugin.Istance.Config.Events.ContainsKey(Manager.Get(Player).Id) && Plugin.Istance.Config.Events[Manager.Get(Player).Id].ContainsKey(Event))
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
