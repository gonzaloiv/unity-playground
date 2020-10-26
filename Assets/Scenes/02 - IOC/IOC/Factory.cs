using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IOC
{

    public static class Factory
    {

        public static Container Container { get; set; }

        public static GameObject Instantiate(GameObject prefab)
        {
            GameObject go = GameObject.Instantiate(prefab);
            MonoBehaviour[] classes = go.GetComponentsInChildren<MonoBehaviour>();
            // First checking registering
            foreach (MonoBehaviour monoBehaviour in classes)
            {
                Container.RegisterIfNeeded(monoBehaviour);
            }
            // Later dependecies
            foreach (MonoBehaviour monoBehaviour in classes)
            {
                Container.FixDependecies(monoBehaviour);
            }
            return go;
        }

        public static T Create<T>() where T : new()
        {
            T instance = new T();
            Container.RegisterIfNeeded(instance);
            return instance;
        }

    }

}