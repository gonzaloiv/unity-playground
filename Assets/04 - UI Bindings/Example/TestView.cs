using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class TestView : MonoBehaviour
{

    [SerializeField] private Button button;
    [SerializeField] private Slider slider;
    [SerializeField] private InputField inputField;

    protected virtual void Awake()
    {
        Assert.AreNotEqual(button, null);
        Assert.AreNotEqual(slider, null);
        Assert.AreNotEqual(inputField, null);
        gameObject.AddComponent<Binder>().
            AddBinding(button.onClick, () => Debug.LogWarning("Button onClick")).
            AddBinding(slider.onValueChanged, value => Debug.LogWarning("Slider onValueChanged " + value)).
            AddBinding(inputField.onEndEdit, value => Debug.LogWarning("InputField onEndEdit " + value)).
            AddBinding(inputField.onValueChanged, value => Debug.LogWarning("InputField onValueChange " + value));
    }

}