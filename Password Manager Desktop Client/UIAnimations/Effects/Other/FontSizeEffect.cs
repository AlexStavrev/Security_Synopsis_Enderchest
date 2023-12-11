using Password_Manager_Desktop_Client.UIAnimations.Effects;

namespace Password_Manager_Desktop_Client.UIAnimations.Effects.Other;

public class FontSizeEffect : IEffect
{
    public EffectInteractions Interaction
    {
        get { return EffectInteractions.SIZE; }
    }

    public int GetCurrentValue(Control control)
    {
        return (int)control.Font.SizeInPoints;
    }

    public void SetValue(Control control, int originalValue, int valueToReach, int newValue)
    {
        control.Font = new Font(control.Font.FontFamily, newValue);
    }

    public int GetMinimumValue(Control control)
    {
        return 0;
    }

    public int GetMaximumValue(Control control)
    {
        return int.MaxValue;
    }
}
