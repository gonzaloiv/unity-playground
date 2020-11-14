using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IOC
{

    public class Factory
    {

        private Container container;

        public Factory(Container container)
        {
            this.container = container;
        }

        public GameObject Instantiate(GameObject prefab)
        {
            GameObject go = GameObject.Instantiate(prefab);
            MonoBehaviour[] monoBehaviours = go.GetComponentsInChildren<MonoBehaviour>();
            foreach (MonoBehaviour monoBehaviour in monoBehaviours) // First checks registering
            {
                if (monoBehaviour.HasAttributeOfType(typeof(RegisterAttribute)))
                    container.Register(monoBehaviour);
            }
            foreach (MonoBehaviour monoBehaviour in monoBehaviours) // After checks dependencies
            {
                container.ResolveDependecies(monoBehaviour);
            }
            return go;
        }

        public T Create<T>() where T : new()
        {
            T instance = new T();
            if (instance.HasAttributeOfType(typeof(RegisterAttribute)))
                container.Register(instance);
            return instance;
        }

    }

}