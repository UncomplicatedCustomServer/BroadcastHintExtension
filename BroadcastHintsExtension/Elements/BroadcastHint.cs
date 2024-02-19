using BroadcastHintExtension.Structures;
using System.ComponentModel;

namespace BroadcastHintExtension.Elements
{
    internal class BroadcastHint : IBroadcastHint
    {
        [Description("The broadcast content")]
        public string BroadcastContent { get; set; } = "This is an example broadcast!";
        [Description("Set the broadcast duration")]
        public ushort BroadcastDuration { get; set; } = 5;
        [Description("The broadcast visibility. Available: All / Self")]
        public BroadcastVisibility BroadcastVisibility { get; set; } = BroadcastVisibility.Self;
        [Description("The hint content")]
        public string HintContent { get; set; } = "And this is an example hint!";
        [Description("Set the hint duration")]
        public float HintDuration { get; set; } = 5f;
        [Description("The cassie message, set to empty to avoid")]
        public string CassieMessage { get; set; } = string.Empty;
        [Description("The cassie subtitles. Empty to use only voice")]
        public string CassieSubtitles { get; set; } = string.Empty;
    }
}
