namespace Password_Manager_Desktop_Client.UIAnimations.Effects.Bounds;

public class TopAnchoredHeightEffect : IEffect
{
    public int GetCurrentValue(Control control)
    {
        return control.Height;
    }

    public void SetValue(Control control, int originalValue, int valueToReach, int newValue)
    {
        control.Height = newValue;
    }

    public int GetMinimumValue(Control control)
    {
        return control.MinimumSize.IsEmpty ? int.MinValue
            : control.MinimumSize.Height;
    }

    public int GetMaximumValue(Control control)
    {
        return control.MaximumSize.IsEmpty ? int.MaxValue
            : control.MaximumSize.Height;
    }

    public EffectInteractions Interaction
    {
        get { return EffectInteractions.HEIGHT; }
    }
}
