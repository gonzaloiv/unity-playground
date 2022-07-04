using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StateMachine
{

    public class FinalState : State
    {

        private Button previousStateButton;

        public FinalState(StateMachine stateMachine, Button previousStateButton) : base(stateMachine)
        {
            this.previousStateButton = previousStateButton;
        }

        public override void Enter()
        {
            base.Enter();
            previousStateButton.gameObject.SetActive(true);
        }

        public override void Exit()
        {
            base.Exit();
            previousStateButton.gameObject.SetActive(false);
        }

        protected override void AddListeners()
        {
            previousStateButton.onClick.AddListener(ChangeState);
        }

        protected override void RemoveListeners()
        {
            previousStateButton.onClick.RemoveListener(ChangeState);
        }

        protected virtual void ChangeState()
        {
            stateMachine.ChangeState<InitialState>();
        }

    }

}