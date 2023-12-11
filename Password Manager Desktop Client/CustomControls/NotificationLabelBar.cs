using Password_Manager_Desktop_Client.UIAnimations;
using Password_Manager_Desktop_Client.UIAnimations.Animators;
using Password_Manager_Desktop_Client.UIAnimations.Effects.Bounds;
using Password_Manager_Desktop_Client.UIAnimations.Extensions;
using System.ComponentModel;


namespace Password_Manager_Desktop_Client.CustomControls;
public partial class NotificationLabelBar : UserControl
{
    private int _height;
    private AnimationStatus _animationStatus;

    [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public override string Text { get => lblMessage.Text; set => lblMessage.Text = value; }

    [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Description("The ForeColor of the close button")]
    public Color ButtonColor
    {
        get => btnHideNotification.ForeColor;
        set
        {
            btnHideNotification.ForeColor = value;
            Invalidate();
        }
    }

    public NotificationLabelBar()
    {
        InitializeComponent();
        _height = this.Height;
    }

    private void OnLoad()
    {
        _animationStatus = this.Animate(new BottomAnchoredHeightEffect(), EasingFunctions.BackEaseIn, 0, 0, 0);
    }

    public async Task ShowNotificationAsync(int milis = 1000)
    {
        _height = TextRenderer.MeasureText(lblMessage.Text, lblMessage.Font).Height;
        if (!_animationStatus.IsCompleted) { return; }
        _animationStatus = this.Animate(new TopAnchoredHeightEffect(), EasingFunctions.BackEaseOut, _height, 1000, 0);
        await Task.Delay(milis);
        HideNotification();
    }

    public void HideNotification()
    {
        if (!_animationStatus.IsCompleted) { return; }
        //_animationStatus.CancellationToken.Cancel();
        _animationStatus = this.Animate(new TopAnchoredHeightEffect(), EasingFunctions.BackEaseOut, 0, 1000, 0);
    }

    private void btnHideNotification_Click(object sender, EventArgs e) => HideNotification();

    private void NotificationLabelBar_Load(object sender, EventArgs e) => OnLoad();

}
