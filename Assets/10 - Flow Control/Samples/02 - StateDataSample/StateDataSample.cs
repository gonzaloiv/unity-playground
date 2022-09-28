using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FlowControl
{

    public class StateDataSample : MonoBehaviour
    {

        [SerializeField] private CubeBehaviour cube;
        [SerializeField] private SphereBehaviour sphere;
        [SerializeField] private StateData cubeStateData;

        private StateMachine stateMachine;
        private StateFactory factory;

        private void Start()
        {
            factory = new StateFactory();
            factory.Register(cube, sphere);
            cube.Init();
            sphere.Init();
            Setup();
        }

        private void Setup()
        {
            this.stateMachine = new StateMachine();
            stateMachine.Register(factory.Convert(cubeStateData));
            stateMachine.Register(
                new StateBuilder<State>()
                    .Route("SphereState")
                    .Show(sphere)
                    .Hide(sphere)
                    .Build()
            );
            Router.Init(stateMachine);
            Router.SetCurrentState("CubeState");
        }

    }

}