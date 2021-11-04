using Assets.Scripts.CombatSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.Scripts.CombatSystem 
{
    public class NoteCombatUI : MonoBehaviour
    {

        public Transform spawnPoint, endPoint;
        public GameObject go;
        double distance;
        // Start is called before the first frame update
        void Start()
        {
            distance = spawnPoint.position.x - endPoint.position.x;
           

            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void MainLoop()
        {
            //iterate over every note
            // if note duration + lowest grade threshold > time passed since the spawn of the note
            // we delete it and give a bad mark (bad bad)
            // go.transform.Translate(Vector3.Scale(Vector3.left, new Vector3(((float)distance / 1) *  (Time.deltaTime), 0, 0)));

        }


    }

}

