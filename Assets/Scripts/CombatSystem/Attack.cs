using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.CombatSystem
{
    [CreateAssetMenu(fileName = "Attack", menuName = "CombatSystem/Attack")]
    public class Attack: ScriptableObject
    {
        public new string name;
        public double successRateRequired;
        public List<AttackNoteLive> noteList;
        public double damage;
    }
}
