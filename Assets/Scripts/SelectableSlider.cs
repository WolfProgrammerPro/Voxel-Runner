using UnityEngine;
using UnityEngine.UI;

public class SelectableSlider : ChosableElement<float>
{
    [SerializeField] private Slider slider;
    public override void Check(float newValue)
    {
        slider.value = newValue;
    }

    public override void OnValueChanged()
    {
        myValue = slider.value;
        base.OnValueChanged();
    }
}
