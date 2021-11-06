using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.CombatSystem
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Grade", menuName = "CombatSystem/Grade")]
    public class Grade : ScriptableObject
    {
        // Start is called before the first frame update
        public double score;
        public double deltaTime;
        public Sprite spriteOnHit;
    }
}


