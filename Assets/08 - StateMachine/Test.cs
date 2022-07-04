using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StateMachine
{

    public class Test : MonoBehaviour
    {

        [SerializeField] private Button nextStateButton;
        [SerializeField] private Button previousStateButton;

        private void Start()
        {
            nextStateButton.gameObject.SetActive(false);
            previousStateButton.gameObject.SetActive(false);
            StateMachine stateMachine = new StateMachine();
            stateMachine.AddState(new InitialState(stateMachine, nextStateButton));
            stateMachine.AddState(new FinalState(stateMachine, previousStateButton));
            stateMachine.ChangeState<InitialState>();
        }

    }

}