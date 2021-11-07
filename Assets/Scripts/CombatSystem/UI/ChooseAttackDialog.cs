using Assets.Scripts.CombatSystem;
using Assets.Scripts.CombatSystem.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseAttackDialog : MonoBehaviour
{
    public event EventHandler AttackChosen;
    List<Button> spellButtons;
    List<Attack> currentAttacks;
    AttackChosenArgs attackArgs;
    // Start is called before the first frame update
    void Awake()
    {
        spellButtons = new List<Button>();
        attackArgs = new AttackChosenArgs();
        int id = 0;
        foreach (Button button in GetComponentsInChildren<Button>())
        {
            spellButtons.Add(button);
            
        }
        spellButtons[0].onClick.AddListener(delegate { ButtonClicked(0); });
        spellButtons[1].onClick.AddListener(delegate { ButtonClicked(1); });
        spellButtons[2].onClick.AddListener(delegate { ButtonClicked(2); });
        spellButtons[3].onClick.AddListener(delegate { ButtonClicked(3); });
    }

    void ButtonClicked (int _id)
    {
        attackArgs.attack = currentAttacks[_id];
        AttackChosen?.Invoke(this, attackArgs);
        gameObject.SetActive(false);
    }

    public void Show(List<Attack> attacks)
    {
        gameObject.SetActive(true);
        currentAttacks = attacks;
        if (attacks.Count > 4)
        {
            throw new Exception("Too many attacks were passed to the choose attack dialog");
        }
        foreach(Button button in spellButtons)
        {
            button.gameObject.SetActive(false);
        }
        for (int i = 0; i < attacks.Count; i++)
        {
            spellButtons[i].gameObject.SetActive(true);
            spellButtons[i].GetComponent<Image>().sprite = attacks[i].sprite;
        }
    }
}
