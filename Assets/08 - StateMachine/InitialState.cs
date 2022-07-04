using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StateMachine
{

    public class InitialState : State
    {

        private Button nextStateButton;

        public InitialState(StateMachine stateMachine, Button nextStateButton) : base(stateMachine)
        {
            this.nextStateButton = nextStateButton;
        }

        public override void Enter()
        {
            base.Enter();
            nextStateButton.gameObject.SetActive(true);
        }

        public override void Exit()
        {
            base.Exit();
            nextStateButton.gameObject.SetActive(false);
        }

        protected override void AddListeners()
        {
            nextStateButton.onClick.AddListener(ChangeState);
        }

        protected override void RemoveListeners()
        {
            nextStateButton.onClick.RemoveListener(ChangeState);
        }

        protected virtual void ChangeState()
        {
            stateMachine.ChangeState<FinalState>();
        }

    }

}