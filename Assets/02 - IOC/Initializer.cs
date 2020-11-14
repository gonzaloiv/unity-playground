using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IOC
{

    public class Initializer : MonoBehaviour
    {

        public ActorController actorController;
        public GameObject actorPrefab;

        private Container container;
        private Factory factory;

        private void Awake()
        {
            container = new Container();
            factory = new Factory(container);
            factory.Create<RuntimeInput>();
            container.ResolveDependecies(actorController);
            GameObject go = factory.Instantiate(actorPrefab);
        }

    }

}