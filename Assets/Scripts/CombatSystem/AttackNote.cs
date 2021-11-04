using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.CombatSystem
{
    [CreateAssetMenu(fileName = "AttackNote", menuName = "CombatSystem/AttackNote")]
    public class AttackNote: ScriptableObject
    {
        public Sprite sprite;
        public KeyCode key;
        public double speed;
        public double Sdeltatime;
        public double Adeltatime;
        public double Bdeltatime;
        public double Cdeltatime;
    }
}
