using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.CombatSystem
{
    public class AttackNoteLoaded
    {
        public bool spawned { get; set; } = false;
        public AttackNoteLive attackNoteLive { get; set; }
    }
}
