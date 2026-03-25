using DG.Tweening;
using UnityEngine;

public class MenuInterfaceController : MonoBehaviour
{
    [SerializeField] private RectTransform[] buttons;

    [SerializeField] private float buttonMovedPositionX;
    [SerializeField] private float buttonNotMovedPositionX;

    [SerializeField] private float buttonMoveDuration;

    [SerializeField] private UIMovableElement settings;
    [SerializeField] private UIMovableElement levels;




    private void Start()
    {
        MoveButtons(false);
    }

    private void MoveButtons(bool moveToLeft)
    {
        foreach (RectTransform button in buttons)
        {
            if (button != null)
            {
                button.DOKill();
                if (moveToLeft)
                {
                    button.DOLocalMoveX(buttonMovedPositionX, buttonMoveDuration);
                }
                else
                {
                    button.DOLocalMoveX(buttonNotMovedPositionX, buttonMoveDuration);
                }
            }
        }
    }

    public void Play()
    {
        if (levels != null)
        {
            levels.SetAppearance(!levels.IsAppearanced());
            settings.SetAppearance(false);
            MoveButtons(levels.IsAppearanced());

        }
        else
        {
            Debug.Log("No Levels UIMovableElement has been choosed");
        }
    }


    public void OpenSettings()
    {
        if (settings != null)
        {
            settings.SetAppearance(!settings.IsAppearanced());
            levels.SetAppearance(false);
            MoveButtons(settings.IsAppearanced());
        }
        else
        {
            Debug.Log("No Settings UIMovableElement has been choosed");
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
