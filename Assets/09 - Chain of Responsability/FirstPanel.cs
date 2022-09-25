using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace COR
{

    public class FirstPanel : BasePanel
    {

        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private TextMeshProUGUI label;

        private void Awake()
        {
            inputField.onValueChanged.AddListener(Handle);
        }

        private void OnDestroy()
        {
            inputField.onValueChanged.RemoveListener(Handle);
        }

        public override void Handle(string value)
        {
            base.Handle(value);
            label.text = value;
        }

    }

}