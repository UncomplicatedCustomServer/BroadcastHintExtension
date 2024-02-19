using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadcastHintExtension.Structures
{
    internal interface IBroadcastHint
    {
        public abstract string BroadcastContent { get; set; }
        public abstract ushort BroadcastDuration { get; set; }
        public abstract BroadcastVisibility BroadcastVisibility { get; set; }
        public abstract string HintContent { get; set; }
        public abstract float HintDuration { get; set; }
        public abstract string CassieMessage { get; set; }
        public abstract string CassieSubtitles { get; set; }
    }
}
