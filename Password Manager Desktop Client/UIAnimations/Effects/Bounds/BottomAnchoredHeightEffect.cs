namespace Password_Manager_Desktop_Client.UIAnimations.Effects.Bounds;

public class BottomAnchoredHeightEffect : IEffect
{
    public int GetCurrentValue(Control control)
    {
        return control.Height;
    }

    public void SetValue(Control control, int originalValue, int valueToReach, int newValue)
    {
        //changing location and size independently can cause flickering:
        //change bounds property instead.

        var size = new Size(control.Width, newValue);
        var location = new Point(control.Left, control.Top +
            (control.Height - newValue));

        control.Bounds = new Rectangle(location, size);
    }

    public int GetMinimumValue(Control control)
    {
        if (control.MinimumSize.IsEmpty)
            return int.MinValue;

        return control.MinimumSize.Height;
    }

    public int GetMaximumValue(Control control)
    {
        if (control.MaximumSize.IsEmpty)
            return int.MaxValue;

        return control.MaximumSize.Height;
    }

    public EffectInteractions Interaction
    {
        get { return EffectInteractions.BOUNDS; }
    }
}
