using System;
using System.Collections.Generic;
using Carpenter.PooledObject;
using UnityEngine;

namespace DefaultNamespace.Managers {
    public class PoolObjectManager : Singleton<PoolObjectManager> {
        public Dictionary<PoolObjectType, List<GameObject>> poolDictionary = new Dictionary<PoolObjectType, List<GameObject>>();

        public void SetUpDictionary() {
            PoolObjectType[] keys = Enum.GetValues(typeof(PoolObjectType)) as PoolObjectType[];
            foreach (PoolObjectType objectType in keys) {
                if (!poolDictionary.ContainsKey(objectType)) {
                    poolDictionary.Add(objectType, new List<GameObject>());
                }
            }
        }

        /**
         * <summary>Get pool object from manager dictionary.</summary>
         */
        public GameObject GetObject(PoolObjectType type) {
            if (poolDictionary.Count == 0) {
                SetUpDictionary();
            }

            List<GameObject> poolObjects = poolDictionary[type];

            GameObject obj;

            if (poolObjects.Count > 0) {
                obj = poolObjects[0];
                poolObjects.RemoveAt(0);
            } else {
                obj = PoolObjectLoader.InstantiatePoolObject(type);
            }
            obj.SetActive(true);

            return obj;
        }

        /**
         * <summary>Add back the pool object to the dictionary.</summary>
         */
        public void AddObject(PoolObject obj) {
            List<GameObject> gameObjects = poolDictionary[obj.type];
            gameObjects.Add(obj.gameObject);
            obj.gameObject.SetActive(false);
        }
    }
}