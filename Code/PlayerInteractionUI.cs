using Sandbox;

public sealed class PlayerInteractionUI : Component
{
    private PlayerController Controller;
    private BaseInventoryItem CurrentItem;

    [Property]
    public TextRenderer NameText { get; set; }

    [Property]
    public TextRenderer ActionText { get; set; }

    [Property]
    public GameObject PromptRoot { get; set; }

    [Property]
    public float HeightOffset { get; set; } = 60f;

    private CameraComponent Camera;

    protected override void OnStart()
    {
        Controller = Components.Get<PlayerController>();
        Camera = GameObject.GetComponentInChildren<CameraComponent>();

        var orange = new Color( 1f, 0.5f, 0.05f );

        NameText.Color = orange;
        ActionText.Color = orange;

        Hide();
    }

    protected override void OnUpdate()
    {
        var hoveredItem = Controller?.Hovered as BaseInventoryItem;

        if ( hoveredItem != CurrentItem )
        {
            CurrentItem = hoveredItem;

            if ( CurrentItem == null )
            {
                Hide();
            }
            else
            {
                Show( CurrentItem );
            }
        }

        UpdatePromptPosition();
    }

    private void Show( BaseInventoryItem item )
    {
        NameText.Text = item.DisplayName;
        ActionText.Text = "[E] Pick Up";

        NameText.Enabled = true;
        ActionText.Enabled = true;
    }

    private void Hide()
    {
        NameText.Enabled = false;
        ActionText.Enabled = false;
    }

    private void UpdatePromptPosition()
    {
        if ( CurrentItem == null || PromptRoot == null || Camera == null )
            return;

        PromptRoot.WorldPosition =
            CurrentItem.GameObject.WorldPosition
            + Vector3.Up * HeightOffset;

        var direction =
            Camera.WorldPosition - PromptRoot.WorldPosition;

        PromptRoot.WorldRotation =
            Rotation.LookAt( direction ) *
            Rotation.FromYaw( 180f );
    }
}