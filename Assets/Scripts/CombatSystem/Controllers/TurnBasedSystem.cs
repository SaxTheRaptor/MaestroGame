using Assets.Scripts.CombatSystem.Models;
using Assets.Scripts.CombatSystem.UI;
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
        public ChooseAttackDialog attackDialog;
        public ChooseItemDialog itemDialog;
        public ChooseActDialog actDialog;
        public TurnBasedUI turnBasedUI;
        public NoteCombatSystem noteCombatSystem;
        void Start()
        {
            attackDialog.AttackChosen += AttackChosen;
            noteCombatSystem.AttackFinished += AttackFinished;
            turnBasedUI.AttackClicked += DoAttack;
            turnBasedUI.ItemClicked += DoItem;
            turnBasedUI.ActClicked += DoAct;
            
        }

        void DoAttack(object sender, EventArgs args)
        {
            attackDialog.Show(new List<Attack>() { attack, attack });
        }

        void DoItem(object sender, EventArgs args)
        {

        }

        void DoAct(object sender, EventArgs args)
        {

        }

        void AttackChosen(object sender, EventArgs args)
        {
            AttackChosenArgs attackArgs = (AttackChosenArgs)args;
            noteCombatSystem.StartAttack(attackArgs.attack);
        }

        void AttackFinished(object sender, EventArgs args)
        {
            Show();
        }

        void Show()
        {
            turnBasedUI.Show();
        }



        
    }
}
