using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Managers {
    
    /**
     * <summary>Singleton class which the ist of attacks stored or managed.</summary>
     */
    public class AttackManager : Singleton<AttackManager> {
        
        public List<AttackInfo> currentAttacks = new List<AttackInfo>();


    }
}