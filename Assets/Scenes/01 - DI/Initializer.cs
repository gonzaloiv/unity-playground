using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DI
{

    public class Initializer : MonoBehaviour
    {

        public ActorController actorController;

        private void Awake()
        {
            actorController.Input = new RuntimeInput();
        }

        private void Start() { }

    }

}