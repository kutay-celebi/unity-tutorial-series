using System.Collections.Generic;
using Carpenter.Animation.Player;
using UnityEngine;

namespace DefaultNamespace {
    
    /**
     * Characters attack info 
     */
    public class AttackInfo : MonoBehaviour {
        
        /**
         * Attacker class.
         */
        public MoveController attacker;
        
        public Attack attackAbility;
        public List<string> colliderNames = new List<string>();

        public bool mustCollide;
        public bool mustFaceAttacker;
        public float lethalRangge;
        public int maxHits;
        public int currentHits;
        public bool isRegistered;
        public bool isFinished;

        public void ResetInfo(Attack attack, MoveController controller) {
            isRegistered  = false;
            isFinished    = false;
            attackAbility = attack;
            attacker = controller;
        }

        public void Register(Attack attack, MoveController controller) {
            isRegistered = true;
            attacker     = controller;

            attackAbility    = attack;
            colliderNames    = attack.colliderNames;
            mustCollide      = attack.mustCollide;
            mustFaceAttacker = attack.mustFaceAttacker;
            lethalRangge     = attack.lethalRangge;
            maxHits          = attack.maxHits;
            currentHits      = 0;
        }
    }
}