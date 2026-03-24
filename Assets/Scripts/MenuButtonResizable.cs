using DG.Tweening;
using UnityEngine;

public class MenuButtonResizable : MenuButton
{
    [SerializeField] private Vector3 howeredSize;
    [SerializeField] private Vector3 unhoweredSize;

    private RectTransform rectTransform;

    protected override void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        base.Start();
    }

    protected override void AnimateButton()
    {
        if (rectTransform != null)
        {
            if (isChoosed)
            {
                rectTransform.DOScale(howeredSize, appearanceDuration);
            }
            else
            {
                rectTransform.DOScale(unhoweredSize, appearanceDuration);
            }
        }
        else
        {
            Debug.LogError("No RectTransform on this button");
        }
    }
}
