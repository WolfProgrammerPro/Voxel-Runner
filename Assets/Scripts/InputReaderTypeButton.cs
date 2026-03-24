using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IChoosable<T>
{
    void Check(T value);
    void OnValueChanged();
}


public interface IHigligtable
{
    void Highlight();
    void Unhiglight();
}

public class ChosableElement<T> : MonoBehaviour, IChoosable<T>
{
    [SerializeField] protected T myValue;
    [SerializeField] protected float effectsDuration;
    public Action<T> OnChanged;

    public virtual void Check(T newValue)
    {

    }

    public virtual void OnValueChanged()
    {
        OnChanged?.Invoke(myValue);
    }


}


public class ChosableButton<T> : ChosableElement<T>, IHigligtable
{

    [SerializeField] private Color highlightedColor;
    [SerializeField] private Color defaultColor;
    

    [SerializeField] private Image image;
    private bool isSelected;

    private void Awake()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
            if (image == null)
            {
                Debug.LogError("No Image component on object " + myValue.ToString());
            }
        }
    }

    public override void Check(T value)
    {
        if (image  != null)
        {
            ChangeSelectedValue(value);
            UpdateButtonHigligting();
        }
        else
        {
            Debug.Log("No image defined");
        }
    }

    private void ChangeSelectedValue(T value)
    {
        //print(name);
        //print(value);
        //print(myValue);
        isSelected = EqualityComparer<T>.Default.Equals(value, myValue);
    }

    private void UpdateButtonHigligting()
    {
        if (isSelected)
        {
            Highlight();
        }
        else
        {
            Unhiglight();
        }
    }
    public void Highlight()
    {
        if (image != null)
        {
            image.DOColor(highlightedColor, effectsDuration);
        }
    }
    public void Unhiglight()
    {
        if (image != null)
        {
            image.DOColor(defaultColor, effectsDuration);
        }
    }
}


public class InputReaderTypeButton : ChosableButton<InputType>
{
    
}
