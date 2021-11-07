using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.CombatSystem.UI
{
    public class TurnBasedUI: MonoBehaviour
    {
        public Button attackButton, itemButton, actButton;

        public event EventHandler AttackClicked, ItemClicked, ActClicked;

        void Awake()
        {
            attackButton.onClick.AddListener( () => { AttackClicked?.Invoke(this, null); gameObject.SetActive(false); });
            itemButton.onClick.AddListener(() => { ItemClicked?.Invoke(this, null); gameObject.SetActive(false); });
            actButton.onClick.AddListener(() => { ActClicked?.Invoke(this, null); gameObject.SetActive(false); });
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

    }
}
