using UnityEngine;
using System;
using System.Collections.Generic;

public interface ISelector<T>
{
    void UpdateElements();
    void WriteChoosedValue();
    void Select(T value);
    void SubscribeToUpdateAction();
}



public class Selector<T> : MonoBehaviour, ISelector<T>
{
    [SerializeField] private ChosableElement<T>[] elements;

    protected T choosedValue;

    protected Action actionToUpdate;


    private void Start()
    {
        WriteChoosedValue();
        UpdateElements();
    }

    public virtual void WriteChoosedValue()
    {
        if (GameManager.Instance == null)
        {
            return;
        }
    }



    private void OnEnable()
    {
        SubscribeElements();
        SubscribeToGameManager();
    }

    private void OnDisable()
    {
        UnsubscribeElements();
        UnsubscribeToGameManager();
    }


    public virtual void SubscribeToUpdateAction()
    {

    }


    private void SubscribeToGameManager()
    {
        actionToUpdate += UpdateElements;
    }

    private void UnsubscribeToGameManager()
    {
        actionToUpdate -= UpdateElements;
    }

    public virtual void SetChoosedValue(T value)
    {
        if (GameManager.Instance == null)
        {
            return;
        }
    }


    public void UpdateElements()
    {
        foreach (var element in elements)
        {
            if (element != null)
            {
                element.Check(choosedValue);
            }
        }
    }

    public virtual void Select(T selectedValue)
    {
        if (GameManager.Instance != null)
        {
            SetChoosedValue(selectedValue);
            WriteChoosedValue();
            UpdateElements();
        }
    }

    public void SubscribeElements()
    {
        foreach (var element in elements)
        {
            if (element != null)
            {
                element.OnChanged += Select;
            }
        }
    }

    public void UnsubscribeElements()
    {
        foreach (var element in elements)
        {
            if (element != null)
            {
                element.OnChanged -= Select;
            }
        }
    }
}




public class InputTypeSelector : Selector<InputType>
{
    public override void SubscribeToUpdateAction()
    {
        if (GameManager.Instance != null)
        {
            GameManager.OnInputTypeChanged += actionToUpdate;
        }
    }

    public override void SetChoosedValue(InputType value)
    {
        base.SetChoosedValue(value);
        GameManager.Instance.SetInputReaderType(value);
    }

    public override void WriteChoosedValue()
    {
        base.WriteChoosedValue();
        choosedValue = GameManager.Instance.GetInputType();
    }
}
