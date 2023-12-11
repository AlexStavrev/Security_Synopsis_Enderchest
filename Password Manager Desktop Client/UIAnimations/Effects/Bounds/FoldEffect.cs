using Password_Manager_Desktop_Client.UIAnimations.Effects;

namespace VisualEffects.Effects.Bounds;

public class FoldEffect : IEffect
{
    public EffectInteractions Interaction
    {
        get { return EffectInteractions.BOUNDS; }
    }

    public int GetCurrentValue(Control control)
    {
        return control.Width * control.Height;
    }

    public void SetValue(Control control, int originalValue, int valueToReach, int newValue)
    {
        int actualValueChange = Math.Abs(originalValue - valueToReach);
        int currentValue = this.GetCurrentValue(control);

        double absoluteChangePerc = ((double)((originalValue - newValue) * 100)) / actualValueChange;
        absoluteChangePerc = Math.Abs(absoluteChangePerc);

        if (absoluteChangePerc > 100.0f)
            return;
    }

    public int GetMinimumValue(Control control)
    {
        if (control.MinimumSize.IsEmpty)
            return 0;

        return control.MinimumSize.Width * control.MinimumSize.Height;
    }

    public int GetMaximumValue(Control control)
    {
        if (control.MaximumSize.IsEmpty)
            return int.MaxValue;

        return control.MaximumSize.Width * control.MaximumSize.Height;
    }
}
