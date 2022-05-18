using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class BinderTest
{

    private GameObject go;

    [SetUp]
    public void SetUp()
    {
        this.go = new GameObject();
    }

    [UnityTest]
    public IEnumerator TestAddBindingActionIsCalled()
    {
        bool hasBeenCalled = false;
        Button button = go.AddComponent<Button>();
        Binder binder = go.AddComponent<Binder>()
            .AddBinding(button.onClick, () => hasBeenCalled = true);
        yield return new WaitForEndOfFrame();
        button.onClick.Invoke();
        Assert.AreEqual(hasBeenCalled, true);
    }

    [UnityTest]
    public IEnumerator TestAddFloatBindingActionIsCalled()
    {
        float expectedValue = 0.5f;
        float sliderValue = 0;
        Slider slider = go.AddComponent<Slider>();
        Binder binder = go.AddComponent<Binder>()
            .AddBinding(slider.onValueChanged, value => sliderValue = value);
        yield return new WaitForEndOfFrame();
        slider.onValueChanged.Invoke(expectedValue);
        Assert.AreEqual(sliderValue, expectedValue);
    }

    [UnityTest]
    public IEnumerator TestAddStringBindingActionIsCalled()
    {
        string expectedValue = "New value";
        string inputFieldValue = string.Empty;
        InputField inputField = go.AddComponent<InputField>();
        Binder binder = go.AddComponent<Binder>()
            .AddBinding(inputField.onValueChanged, value => inputFieldValue = value);
        yield return new WaitForEndOfFrame();
        inputField.onValueChanged.Invoke(expectedValue);
        Assert.AreEqual(inputFieldValue, expectedValue);
    }

}