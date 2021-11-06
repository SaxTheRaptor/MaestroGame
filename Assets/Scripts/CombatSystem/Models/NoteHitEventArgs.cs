using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.CombatSystem
{
    public class NoteHitEventArgs: EventArgs
    {
        public Grade Grade { get; set; }
    }
}
