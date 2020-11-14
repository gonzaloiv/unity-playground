using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterfacedUI
{

    public class Initializer : MonoBehaviour
    {

        public GameObject canvasGO;

        private void Awake() { }

        private void Start()
        {
            Message message = new Message() { title = "This is the title", body = "This is the body" };
            ShowMessage(message);
            canvasGO.GetComponentsInChildren<MessageForm>(true)
                .ForEach(_ => _.MessageValueChanged += ShowMessage);
            canvasGO.GetComponentsInChildren<IEntityForm<Message>>(true)
                .ForEach(_ => _.MessageValueChanged += ShowMessage);
        }

        private void OnDestroy()
        {
            canvasGO.GetComponentsInChildren<MessageForm>(true)
                .ForEach(_ => _.MessageValueChanged -= ShowMessage);
            canvasGO.GetComponentsInChildren<IEntityForm<Message>>(true)
                .ForEach(_ => _.MessageValueChanged -= ShowMessage);
        }

        private void ShowMessage(Message message)
        {
            canvasGO.GetComponentsInChildren<IMessageView>(true)
                .ForEach(_ => _.Show(message));
            canvasGO.GetComponentsInChildren<IEntityView<Message>>(true)
                .ForEach(_ => _.Show(message));
        }

    } 
}