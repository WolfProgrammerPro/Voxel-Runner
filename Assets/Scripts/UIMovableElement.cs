using DG.Tweening;
using UnityEngine;

public interface IUIMovableElement
{
    public void SetAppearance(bool value);
    public bool IsAppearanced();
}

public class UIMovableElement : MonoBehaviour, IUIMovableElement
{
    [SerializeField] private Vector3 appearancedPosition;
    [SerializeField] private Vector3 hidedPosition;

    [SerializeField] private float appearanceDuration;


    private bool isAppearanced = false;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.localPosition = hidedPosition;
        isAppearanced = false;
    }

    public bool IsAppearanced() => isAppearanced;

    public void SetAppearance(bool value)
    {
        isAppearanced = value;
        UpdateElement();
    }

    private void UpdateElement()
    {
        if (rectTransform != null)
        {
            rectTransform.DOKill();
            if (isAppearanced)
            {
                rectTransform.DOLocalMove(appearancedPosition, appearanceDuration);
            }
            else
            {
                rectTransform.DOLocalMove(hidedPosition, appearanceDuration);
            }
        }
        else
        {
            Debug.LogError("No RectTransform on this object");
        }
    }




}
