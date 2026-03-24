public class LevelSelector : Selector<int>
{
    public override void SubscribeToUpdateAction()
    {
        if (GameManager.Instance != null)
        {
            GameManager.OnLoadingLevelChanged += actionToUpdate;
        }
    }

    public override void SetChoosedValue(int value)
    {
        base.SetChoosedValue(value);
        GameManager.Instance.SetLoadingLevel(value);
    }

    public override void WriteChoosedValue()
    {
        base.WriteChoosedValue();
        choosedValue = GameManager.Instance.GetLoadingLevel();
    }

    public void PlayOnChoosedLevel()
    {
        if (GameManager.Instance!=null)
        {
            GameManager.Instance.PlayOnLoadingLevel();
        }
    }
}
