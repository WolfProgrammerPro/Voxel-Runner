using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] protected float appearanceDuration;

    protected bool isChoosed;

    protected virtual void Start()
    {
        UnHower();
    }

    private void UnHower()
    {
        isChoosed = false;
        AnimateButton();
    }

    private void Hower()
    {
        isChoosed = true;
        AnimateButton();
    }

    protected virtual void AnimateButton()
    {

    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        Hower();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UnHower();
    }
}

public class MenuButtonWithImage : MenuButton
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI text;


    [SerializeField] private Color imageColorChoosed;
    [SerializeField] private Color imageColorUnchoosed;


    [SerializeField] private Color textColorChoosed;
    [SerializeField] private Color textColorUnchoosed;

    

    protected override void AnimateButton()
    {
        if (image != null && text != null)
        {
            image.DOKill();
            text.DOKill();
            if (isChoosed)
            {
                image.DOColor(imageColorChoosed, appearanceDuration);
                text.DOColor(textColorChoosed, appearanceDuration);
            }
            else
            {
                image.DOColor(imageColorUnchoosed, appearanceDuration);
                text.DOColor(textColorUnchoosed, appearanceDuration);
            }
        }
        else
        {
            Debug.LogError("Image or text not choosed");
        }
    }


}
