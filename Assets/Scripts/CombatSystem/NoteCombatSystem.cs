using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace Assets.Scripts.CombatSystem {

    public class NoteCombatSystem : MonoBehaviour
    {
        public NoteCombatUI noteCombatUI;
        public Attack testAttack;
        public GameObject indicator;
        public Sprite s, a, b, c, bad;

        private float indicatorFlashingTime;
        private Vector3 startingIndicatorScale;
        private bool indicatorFlashing = false;
        private double score;
        private float attackDeltaTime;
        private bool isAttacking;
        private List<AttackNoteLoaded> noteToSpawn;

        // Start is called before the first frame update
        void Start()
        {
            startingIndicatorScale = indicator.transform.localScale;
            noteToSpawn = new List<AttackNoteLoaded>();
            StartAttack(testAttack);
        }

        // Update is called once per frame
        void Update()
        {
            if (isAttacking)
            {
                attackDeltaTime += Time.deltaTime;

                SpawnNotes();
                CheckNotes();
                FlashIndicator();
            }
            
            Debug.Log(score);
        }

        void FlashIndicator()
        {
            if (indicatorFlashingTime > 2)
            {
                DisableIndicator();
            }
            if (indicatorFlashing)
            {
                indicatorFlashingTime += Time.deltaTime;
                indicator.transform.localScale = Vector3.Scale(startingIndicatorScale, new Vector3( (Mathf.Sin(indicatorFlashingTime) + 3) / 2, (Mathf.Sin(indicatorFlashingTime) + 3) / 2, 1));
            }
        }

        void SpawnNotes()
        {
            noteToSpawn.Where(nota => nota.spawned == false).ToList().ForEach(nota =>
            {
                if (nota.attackNoteLive.spawnTime < attackDeltaTime)
                {
                    nota.spawned = true;
                    noteCombatUI.PlayNote(nota.attackNoteLive);
                }
            });
        }

        void CheckNotes()
        {

            foreach (AttackNoteLoaded _note in noteToSpawn.Where(nota => nota.spawned == true).ToList().Reverse<AttackNoteLoaded>())
            {
                if (_note.attackNoteLive.spawnTime + _note.attackNoteLive.note.speed + _note.attackNoteLive.note.Cdeltatime < attackDeltaTime)
                {
                    Debug.Log("REM");
                    //Remove notes that went past the lowest grade
                    noteCombatUI.StopNote(_note.attackNoteLive);
                    noteToSpawn.Remove(_note);

                    StartFlashingIndicator(bad);
                    
                } else
                {
                    //User pressed button
                    if (Input.GetKeyDown(_note.attackNoteLive.note.key))
                    {
                        if(DidScore(_note.attackNoteLive, _note.attackNoteLive.note.Sdeltatime))
                        {
                            noteCombatUI.StopNote(_note.attackNoteLive);
                            noteToSpawn.Remove(_note);
                            score += 20;

                            StartFlashingIndicator(s);
                        }
                        else if (DidScore(_note.attackNoteLive, _note.attackNoteLive.note.Adeltatime))
                        {
                            noteCombatUI.StopNote(_note.attackNoteLive);
                            noteToSpawn.Remove(_note);
                            score += 10;

                            StartFlashingIndicator(a);
                            
                        }
                        else if(DidScore(_note.attackNoteLive, _note.attackNoteLive.note.Bdeltatime))
                        {
                            noteCombatUI.StopNote(_note.attackNoteLive);
                            noteToSpawn.Remove(_note);
                            score += 6;
                            StartFlashingIndicator(b);
                        }
                        else if (DidScore(_note.attackNoteLive, _note.attackNoteLive.note.Cdeltatime))
                        {
                            noteCombatUI.StopNote(_note.attackNoteLive);
                            noteToSpawn.Remove(_note);
                            score += 2;
                            StartFlashingIndicator(c);
                        }

                    }
                } 
                
            };
        }

        private void StartFlashingIndicator(Sprite sprite)
        {
            indicatorFlashingTime = 0;
            indicatorFlashing = true;
            indicator.GetComponent<SpriteRenderer>().sprite = sprite;
            indicator.SetActive(true);
            
        }

        private void DisableIndicator()
        {
            
            indicatorFlashing = false;
            indicator.transform.localScale = startingIndicatorScale;
            indicator.SetActive(false);
        }

        private bool DidScore(AttackNoteLive noteLive, double gradeTime)
        {
            if (noteLive.spawnTime + noteLive.note.speed - gradeTime < attackDeltaTime &&
                noteLive.spawnTime + noteLive.note.speed + gradeTime > attackDeltaTime)
            {
                return true;
            }
            return false;
        }



        void StartAttack(Attack attack)
        {
            isAttacking = true;
            attackDeltaTime = 0;
            attack.noteList.ForEach(note =>
            {
                noteToSpawn.Add(new AttackNoteLoaded() { attackNoteLive = note });
            });
        }


    }
}

