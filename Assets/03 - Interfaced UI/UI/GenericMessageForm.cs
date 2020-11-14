using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace InterfacedUI
{

    public class GenericMessageForm : MonoBehaviour, IEntityForm<Message>
    {

        public TMP_InputField titleField;
        public TMP_InputField bodyField;

        private Action<Message> messageValueChanged = (Message message) => { };

        public Action<Message> MessageValueChanged { get => messageValueChanged; set => messageValueChanged = value; }

        private void Start()
        {
            titleField.onEndEdit.AddListener(value => OnValueChanged());
            bodyField.onEndEdit.AddListener(value => OnValueChanged());
        }

        private void OnDestroy()
        {
            titleField.onEndEdit.RemoveListener(value => OnValueChanged());
            bodyField.onEndEdit.RemoveListener(value => OnValueChanged());
        }

        private void OnValueChanged()
        {
            Message message = new Message() { title = titleField.text, body = bodyField.text };
            messageValueChanged.Invoke(message);
        }

    }

}