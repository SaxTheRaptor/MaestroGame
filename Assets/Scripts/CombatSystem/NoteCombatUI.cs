using Assets.Scripts.CombatSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
namespace Assets.Scripts.CombatSystem 
{
    public class NoteCombatUI : MonoBehaviour
    {

        public Transform spawnPoint, endPoint;
        public GameObject notaPrefab;
       
        private List<GameObject> noteObjects;
        private List<PlayingNote> playingNotes;
        private double distance;
        // Start is called before the first frame update
        void Start()
        {
            playingNotes = new List<PlayingNote>();
            noteObjects = new List<GameObject>();
            for (int i = 0; i < 10; i++)
            {
                GameObject notaInstantiated = Instantiate(notaPrefab, spawnPoint.position, spawnPoint.rotation);
                notaInstantiated.SetActive(false);
                noteObjects.Add(notaInstantiated);
            }

            distance = spawnPoint.position.x - endPoint.position.x;
        }

        // Update is called once per frame
        void Update()
        {
            MoveNotes();
        }

        public void PlayNote(AttackNoteLive attackNote)
        {
            GameObject freeNote = noteObjects.FirstOrDefault(noteObject => !noteObject.activeSelf);
            freeNote.SetActive(true);
            playingNotes.Add(new PlayingNote() {spawnTime = attackNote.spawnTime, speed = attackNote.note.speed, noteObject = freeNote});
        }

        public void StopNote(AttackNoteLive attackNote)
        {
            PlayingNote nota = playingNotes.FirstOrDefault(playingNote => playingNote.spawnTime == attackNote.spawnTime);
            nota.noteObject.SetActive(false);
            nota.noteObject.transform.position = spawnPoint.transform.position;
            playingNotes.Remove(nota);
        }

        void MoveNotes()
        {
            //iterate over every note
            playingNotes.ForEach(playingNote =>
            {
                playingNote.noteObject.transform.Translate(Vector3.Scale(Vector3.left, new Vector3(((float)distance / (float)playingNote.speed) * Time.deltaTime, 0, 0)));
            });
        }
    }

}

