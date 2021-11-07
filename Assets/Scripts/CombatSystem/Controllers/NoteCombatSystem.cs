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

        public event EventHandler AttackFinished;
        public event EventHandler NoteHit;
        private EventHandler handler;
        private NoteHitEventArgs args;
        private double score;
        private float attackDeltaTime;
        private bool isAttacking;
        private List<AttackNoteLoaded> noteToSpawn;

        // Start is called before the first frame update
        void Awake()
        {
            args = new NoteHitEventArgs();
            handler = NoteHit;
            noteToSpawn = new List<AttackNoteLoaded>();
            gameObject.SetActive(false);
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

        public void StartAttack(Attack attack)
        {
            gameObject.SetActive(true);
            isAttacking = true;
            attackDeltaTime = 0;
            attack.noteList.ForEach(note =>
            {
                noteToSpawn.Add(new AttackNoteLoaded() { attackNoteLive = note });
            });
            noteToSpawn.Sort((note1, note2) =>
           {
               if (note1.attackNoteLive.spawnTime < note2.attackNoteLive.spawnTime)
                   return -1;
               else if (note1.attackNoteLive.spawnTime == note2.attackNoteLive.spawnTime)
                   return 0;
               else return 1;
           });
        }

        private void SpawnNotes()
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

        private void CheckNotes()
        {

            foreach (AttackNoteLoaded _note in noteToSpawn.Where(nota => nota.spawned == true).ToList().Reverse<AttackNoteLoaded>().Reverse())
            {
                Grade leastGrade = _note.attackNoteLive.note.gradeList.Last();
                if (_note.attackNoteLive.spawnTime + _note.attackNoteLive.note.speed + leastGrade.deltaTime < attackDeltaTime)
                {
                    NoteConfirmed(_note, badGrade);
                } else
                {
                    //User pressed button
                    if (Input.GetKeyDown(_note.attackNoteLive.note.key))
                    {
                        foreach(Grade grade in _note.attackNoteLive.note.gradeList)
                        {
                            if (DidScore(_note.attackNoteLive, grade.deltaTime))
                            {
                                NoteConfirmed(_note, grade);
                                return;
                            }
                        }  
                    }
                } 
            };
        }

        private void NoteConfirmed(AttackNoteLoaded _note, Grade grade)
        {
            noteCombatUI.StopNote(_note.attackNoteLive);
            noteToSpawn.Remove(_note);
            score += grade.score;
            args.Grade = grade;
            handler?.Invoke(this, args);

            if (noteToSpawn.Count == 0)
            {
                AttackFinished?.Invoke(this, null);
                gameObject.SetActive(false);
            }
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
    }
}

