using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FlowControl
{

    public class StateMachineSample : MonoBehaviour
    {

        private StateMachine stateMachine;

        [SerializeField] private CubeBehaviour cube;
        [SerializeField] private SphereBehaviour sphere;

        private void Start()
        {
            cube.Init();
            sphere.Init();
            Setup();
        }

        private void Setup()
        {
            this.stateMachine = new StateMachine();
            stateMachine.Register(
                new StateBuilder<State>()
                    .Route("CubeState")
                    .Show(cube)
                    .Hide(cube)
                    .Build()
            );
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