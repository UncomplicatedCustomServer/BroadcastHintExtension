using Exiled.API.Features;
using System;
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

            PlayerHandler.Spawned += Handler.OnSpawned;
            PlayerHandler.Dying += Handler.OnDying;
            PlayerHandler.Hurting += Handler.OnDamaging;
            PlayerHandler.Hurt += Handler.OnDamage;
            PlayerHandler.InteractingDoor += Handler.OnInteractingDoor;
            PlayerHandler.InteractingElevator += Handler.OnInteractingElevator;

            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            PlayerHandler.Spawned += Handler.OnSpawned;
            PlayerHandler.Dying += Handler.OnDying;
            PlayerHandler.Hurting += Handler.OnDamaging;
            PlayerHandler.Hurt += Handler.OnDamage;
            PlayerHandler.InteractingDoor += Handler.OnInteractingDoor;
            PlayerHandler.InteractingElevator += Handler.OnInteractingElevator;

            Istance = null;
            Handler = null;

            base.OnDisabled();
        }
    }
}
