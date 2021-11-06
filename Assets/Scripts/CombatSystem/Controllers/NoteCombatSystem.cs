using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace Assets.Scripts.CombatSystem {

    public class NoteCombatSystem : MonoBehaviour
    {
        public NoteCombatUI noteCombatUI;
        public Attack testAttack;
        
        public Grade badGrade;


        public event EventHandler NoteHit;
        private EventHandler handler;
        private NoteHitEventArgs args;
        private double score;
        private float attackDeltaTime;
        private bool isAttacking;
        private List<AttackNoteLoaded> noteToSpawn;

        // Start is called before the first frame update
        void Start()
        {
            
            args = new NoteHitEventArgs();
            handler = NoteHit;
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
                Grade leastGrade = _note.attackNoteLive.note.gradeList.Last();
                if (_note.attackNoteLive.spawnTime + _note.attackNoteLive.note.speed + leastGrade.deltaTime < attackDeltaTime)
                {
                    Debug.Log("REM");
                    //Remove notes that went past the lowest grade
                    noteCombatUI.StopNote(_note.attackNoteLive);
                    noteToSpawn.Remove(_note);

                    args.Grade = badGrade;
                    handler?.Invoke(this, args);
                    
                } else
                {
                    //User pressed button
                    if (Input.GetKeyDown(_note.attackNoteLive.note.key))
                    {
                        foreach(Grade grade in _note.attackNoteLive.note.gradeList)
                        {
                            if (DidScore(_note.attackNoteLive, grade.deltaTime))
                            {
                                noteCombatUI.StopNote(_note.attackNoteLive);
                                noteToSpawn.Remove(_note);
                                score += grade.score;
                                args.Grade = grade;
                                handler?.Invoke(this, args);
                                break;
                            }
                        }
                       
                    }
                } 
            };
        }

        private void Test(object sender, EventArgs a)
        {
            Debug.Log("test");
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

