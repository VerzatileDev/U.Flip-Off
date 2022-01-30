using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Unlock",menuName = "Stuart/Unlock")]

public class Unlock : ScriptableObject
{
 
        public enum HeavenOrHell
        {
            Heaven,
            Hell,
            Both
        }
        public string unlockName;
        public HeavenOrHell heavenOrHell;
        public int cost;
        public bool isUnlocked;

        public void Wipe()
        {
            isUnlocked = false;
        }
}
