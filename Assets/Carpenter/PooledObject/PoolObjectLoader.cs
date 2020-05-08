using System;
using UnityEngine;

namespace Carpenter.PooledObject {
    public class PoolObjectLoader : MonoBehaviour {
        public static GameObject InstantiatePoolObject(PoolObjectType type) {
            GameObject obj = null;

            switch (type) {
                case PoolObjectType.ATTACK_INFO: {
                    obj = Instantiate(Resources.Load("AttackInfo", typeof(GameObject))) as GameObject;
                    break;
                }
                default: {
                    throw new NullReferenceException("There is no pool object.");
                }
            }

            return obj;
        }
    }
}