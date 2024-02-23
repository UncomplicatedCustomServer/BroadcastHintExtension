using Exiled.API.Features;
using System;
using UncomplicatedCustomRoles.Structures;
using Handler = BroadcastHintExtension.EventHandler;
using PlayerHandler = Exiled.Events.Handlers.Player;

namespace BroadcastHintExtension
{
    internal class Plugin : Plugin<Config>
    {
        public override string Name => "BroadcastHintExtension";
        public override string Prefix => "BroadcastHintExtension";
        public override string Author => "FoxWorn3365";
        public override Version Version => new(0, 8, 0);
        public override Version RequiredExiledVersion => new(8, 8, 0);
        public static Plugin Istance;
        internal Handler Handler;
        public override void OnEnabled()
        {
            Istance = this;
            Handler = new();

            UncomplicatedCustomRoles.API.Features.Events.Listen(UCREvents.Spawned, Handler.OnSpawned);
            UncomplicatedCustomRoles.API.Features.Events.Listen(UCREvents.Dying, Handler.OnDying);
            UncomplicatedCustomRoles.API.Features.Events.Listen(UCREvents.Hurting, Handler.OnDamaging); 
            UncomplicatedCustomRoles.API.Features.Events.Listen(UCREvents.InteractingElevator, Handler.OnInteractingElevator);
            UncomplicatedCustomRoles.API.Features.Events.Listen(UCREvents.ActivatingWarheadPanel, Handler.OnWarheadActivation);
            UncomplicatedCustomRoles.API.Features.Events.Listen(UCREvents.ActivatingGenerator, Handler.OnGeneratorActivation);
            UncomplicatedCustomRoles.API.Features.Events.Listen(UCREvents.StoppingGenerator, Handler.OnGeneratorDeactivation);
            UncomplicatedCustomRoles.API.Features.Events.Listen(UCREvents.TriggeringTesla, (ICustomRoleEvent Event) =>
            {
                Event.IsAllowed = false;
                return Event;
            });

            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            UncomplicatedCustomRoles.API.Features.Events.Unlisten(UCREvents.Spawned, Handler.OnSpawned);
            UncomplicatedCustomRoles.API.Features.Events.Unlisten(UCREvents.Dying, Handler.OnDying);
            UncomplicatedCustomRoles.API.Features.Events.Unlisten(UCREvents.Hurting, Handler.OnDamaging);
            UncomplicatedCustomRoles.API.Features.Events.Unlisten(UCREvents.InteractingElevator, Handler.OnInteractingElevator);
            UncomplicatedCustomRoles.API.Features.Events.Unlisten(UCREvents.ActivatingWarheadPanel, Handler.OnWarheadActivation);
            UncomplicatedCustomRoles.API.Features.Events.Unlisten(UCREvents.ActivatingGenerator, Handler.OnGeneratorActivation);
            UncomplicatedCustomRoles.API.Features.Events.Unlisten(UCREvents.StoppingGenerator, Handler.OnGeneratorDeactivation);
            UncomplicatedCustomRoles.API.Features.Events.Unlisten(UCREvents.TriggeringTesla, (ICustomRoleEvent Event) =>
            {
                Event.IsAllowed = false;
                return Event;
            });

            Istance = null;
            Handler = null;

            base.OnDisabled();
        }
    }
}
