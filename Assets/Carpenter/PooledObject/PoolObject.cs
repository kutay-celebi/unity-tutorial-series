using System;
using System.Collections;
using DefaultNamespace.Managers;
using UnityEngine;

namespace Carpenter.PooledObject {
    public class PoolObject : MonoBehaviour {
        public PoolObjectType type;
        public float scheduledTimer;
        private Coroutine offRoutine;

        private void OnEnable() {
            if (offRoutine != null) {
                StopCoroutine(offRoutine);
            }

            if (scheduledTimer > 0 ) {
                offRoutine = StartCoroutine(ScheduledOff());
            }
        }

        public void TurnOff() {
            PoolObjectManager.Instance.AddObject(this);
        }

        IEnumerator ScheduledOff() {
            yield return new WaitForSeconds(scheduledTimer);

            if (!PoolObjectManager.Instance.poolDictionary[type].Contains(gameObject)) {
                TurnOff(); //todo test it.
                // GetComponent<PoolObject>().TurnOff();
            }
        }
    }
}