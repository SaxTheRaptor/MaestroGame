using Assets.Scripts.CombatSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.CombatSystem.Controllers
{

    public class TurnBasedSystem: MonoBehaviour
    {
        public Attack attack;
        public ChooseAttackDialog dialog;
        public NoteCombatSystem noteCombatSystem;
        void Start()
        {
            dialog.AttackChosen += AttackChosen;
            noteCombatSystem.AttackFinished += AttackFinished;
            dialog.Show(new List<Attack>() { attack, attack });
        }

        void AttackChosen(object sender, EventArgs args)
        {
            AttackChosenArgs attackArgs = (AttackChosenArgs)args;
            noteCombatSystem.StartAttack(attackArgs.attack);
        }

        void AttackFinished(object sender, EventArgs args)
        {
            dialog.Show(new List<Attack>() { attack, attack });
        }



        
    }
}
