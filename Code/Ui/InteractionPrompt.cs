using Sandbox;

public sealed class InteractionPrompt : Component
{
    [Property]
    public TextRenderer NameText { get; set; }

    [Property]
    public TextRenderer ActionText { get; set; }

    [Property]
    public CameraComponent Camera { get; set; }

    private BaseInventoryItem Target;

    protected override void OnStart()
    {
        Hide();
    }

    protected override void OnUpdate()
    {
        if ( Target == null || Camera == null )
            return;

        GameObject.WorldPosition =
            Target.GameObject.WorldPosition + Vector3.Up * 80f;

        var direction =
            Camera.WorldPosition - GameObject.WorldPosition;

        GameObject.WorldRotation =
            Rotation.LookAt( direction ) *
            Rotation.FromYaw( 180f );
    }

    public void Show( BaseInventoryItem item )
    {
        Target = item;

        NameText.Text = item.DisplayName;
        ActionText.Text = "[E] Pick Up";

        NameText.Enabled = true;
        ActionText.Enabled = true;
    }

    public void Hide()
    {
        Target = null;

        NameText.Enabled = false;
        ActionText.Enabled = false;
    }
}