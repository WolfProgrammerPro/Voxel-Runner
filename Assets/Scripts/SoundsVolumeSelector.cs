public class SoundsVolumeSelector : Selector<float>
{
    public override void SubscribeToUpdateAction()
    {
        if (GameManager.Instance != null)
        {
            GameManager.OnSoundVolumeChange += actionToUpdate;
        }
    }

    public override void SetChoosedValue(float value)
    {
        base.SetChoosedValue(value);
        GameManager.Instance.SetSoundsVolume(value);
    }

    public override void WriteChoosedValue()
    {
        base.WriteChoosedValue();
        choosedValue = GameManager.Instance.SoundsVolume;
    }
}
