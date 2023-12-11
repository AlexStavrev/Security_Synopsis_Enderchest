using Password_Manager_Desktop_Client.UIAnimations.Animators;
using Password_Manager_Desktop_Client.UIAnimations.Effects;
using Password_Manager_Desktop_Client.UIAnimations.Effects.Bounds;
using Password_Manager_Desktop_Client.UIAnimations.Extensions;

namespace Password_Manager_Desktop_Client.UIAnimations;

public class ExampleFoldAnimation
{
    private readonly List<AnimationStatus> _cancellationTokens;

    public Control Control { get; private set; }
    public Size MaxSize { get; set; }
    public Size MinSize { get; set; }
    public int Duration { get; set; }
    public int Delay { get; set; }

    public ExampleFoldAnimation(Control control)
    {
        _cancellationTokens = new List<AnimationStatus>();

        Control = control;
        MaxSize = control.Size;
        MinSize = control.MinimumSize;
        Duration = 1000;
        Delay = 0;
    }

    public void Show()
    {
        int duration = Duration;
        if (_cancellationTokens.Any(animation => !animation.IsCompleted))
        {
            var token = _cancellationTokens.First(animation => !animation.IsCompleted);
            duration = (int)token.ElapsedMilliseconds;
        }

        //cancel hide animation if in progress
        Cancel();

        var cT1 = Control.Animate(new HorizontalFoldEffect(),
             EasingFunctions.CircEaseIn, MaxSize.Height, duration, Delay);

        var cT2 = Control.Animate(new VerticalFoldEffect(),
             EasingFunctions.CircEaseOut, MaxSize.Width, duration, Delay);

        _cancellationTokens.Add(cT1);
        _cancellationTokens.Add(cT2);
    }

    public void Hide()
    {
        int duration = Duration;

        if (_cancellationTokens.Any(animation => !animation.IsCompleted))
        {
            var token = _cancellationTokens.First(animation => !animation.IsCompleted);
            duration = (int)token.ElapsedMilliseconds;
        }

        //cancel show animation if in progress
        Cancel();

        var cT1 = Control.Animate(new HorizontalFoldEffect(),
            EasingFunctions.CircEaseOut, MinSize.Height, duration, Delay);

        var cT2 = Control.Animate(new VerticalFoldEffect(),
            EasingFunctions.CircEaseIn, MinSize.Width, duration, Delay);

        _cancellationTokens.Add(cT1);
        _cancellationTokens.Add(cT2);
    }

    public void Cancel()
    {
        foreach (var token in _cancellationTokens)
            token.CancellationToken.Cancel();

        _cancellationTokens.Clear();
    }
}