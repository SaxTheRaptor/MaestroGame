using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.CombatSystem
{
    [CreateAssetMenu(fileName = "AttackNote", menuName = "CombatSystem/AttackNote")]
    public class AttackNote: ScriptableObject
    {
        public Sprite sprite;
        public KeyCode key;
        public double speed;
        public List<Grade> gradeList;
        
        

        public void OnValidate()
        {
            if (gradeList != null)
            {
                gradeList.Sort((grade1, grade2) =>
                {
                    if (grade1 == null && grade2 == null)
                        return 0;
                    if (grade1 == null && grade2 != null)
                        return 1;
                    if (grade1 != null && grade2 == null)
                        return -1;


                    if (grade1.deltaTime < grade2.deltaTime)
                        return -1;
                    else if (grade1.deltaTime == grade2.deltaTime)
                        return 0;
                    else return 1;
                });
            }
            
        }
    }
}
