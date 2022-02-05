using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Round {START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
	public GameObject enemyPrefab;

	public Transform playerBattleStation;
	public Transform enemyBattleStation;

	Unit playerUnit;
	Unit enemyUnit;

    public Round state;

    // Start is called before the first frame update
    void Start()
    {
        state = Round.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
	{
		Debug.Log("SetupBattle");
		GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
		playerUnit = playerGO.GetComponent<Unit>();

		GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
		enemyUnit = enemyGO.GetComponent<Unit>();

		yield return new WaitForSeconds(2f);
		Debug.Log("SetupBattle2");
		Debug.Log(playerUnit.speed);
		
        if(playerUnit.speed >= enemyUnit.speed){
			state = Round.PLAYERTURN;
            StartCoroutine(PlayerTurn());
        }else{
			state = Round.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
	}
    
    IEnumerator PlayerTurn()
	{
		Debug.Log("PlayerTurn");
        //Not implemented yet
        //Choice of actions

		yield return new WaitForSeconds(2f);

        //Temporary, remove when selection implemented
        StartCoroutine(EnemyTurn());
	}

    IEnumerator Attack(){
		Debug.Log("Attack");

		yield return new WaitForSeconds(2f);

        //Can expand to different attacks and abilities here first.
        StartCoroutine(PlayerAttack());
    }

	IEnumerator PlayerAttack()
	{
		Debug.Log("PlayerAttack");
        playerUnit.BasicAttack();

		yield return new WaitForSeconds(2f);

		if(enemyUnit.currentHP <= 0)
		{
			state = Round.WON;
			StartCoroutine(EndBattle());
		} else
		{
			state = Round.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}

    IEnumerator UseItem(){
		Debug.Log("UseItem");
        //Enter logic for item use
        yield return new WaitForSeconds(2f);
    }

	IEnumerator EnemyTurn()
	{
		Debug.Log("EnemyTurn");
        //For now, we use just basic attacks
        enemyUnit.BasicAttack();

		yield return new WaitForSeconds(1f);

		if(playerUnit.currentHP <= 0)
		{
			state = Round.LOST;
			StartCoroutine(EndBattle());
		} else
		{
			state = Round.PLAYERTURN;
			StartCoroutine(PlayerTurn());
		}

	}

	IEnumerator EndBattle()
	{
		Debug.Log("EndBattle");
		if(state == Round.WON)
		{
			Debug.Log("Battle Won");

            StartCoroutine(Loot());
		} else if (state == Round.LOST)
		{
			Debug.Log("Battle sLost");

            //Handle death
		}
        yield return new WaitForSeconds(2f);
	}

    IEnumerator Loot(){
        //Handle drop logic here
        yield return new WaitForSeconds(2f);
    }
	
}
