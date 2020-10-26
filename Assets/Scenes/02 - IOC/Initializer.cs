using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IOC
{

    public class Initializer : MonoBehaviour
    {

        public ActorController actorController;
        public GameObject actorPrefab;

        private Container container = new Container();

        private void Awake()
        {
            Factory.Container = container;
            Factory.Create<RuntimeInput>();
            container.FixDependecies(actorController);
            GameObject go = Factory.Instantiate(actorPrefab);
        }

    }

}