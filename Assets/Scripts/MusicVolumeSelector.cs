public class MusicVolumeSelector : Selector<float>
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
        GameManager.Instance.SetMusicVolume(value);
    }
    public override void WriteChoosedValue()
    {
        base.WriteChoosedValue();
        choosedValue = GameManager.Instance.MusicVolume;
    }

}
