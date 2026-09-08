using Sandbox;

public sealed class InventoryInteractionWatcher : Component
{
    [Property]
    public CameraComponent Camera { get; set; }

    [Property]
    public InteractionPrompt Prompt { get; set; }

    [Property]
    public float Distance { get; set; } = 700f;

    private BaseInventoryItem CurrentTarget;

    protected override void OnUpdate()
    {
        CheckTarget();
    }

    private void CheckTarget()
    {
        var start = Camera.WorldPosition;
        var end = start + Camera.Transform.World.Forward * Distance;

        var trace = Scene.Trace
            .Ray( start, end )
            .Run();

        BaseInventoryItem newTarget = null;

        if ( trace.Hit )
        {
            newTarget =
                trace.GameObject.Components.Get<BaseInventoryItem>();
        }

        SetTarget( newTarget );
    }

    private void SetTarget( BaseInventoryItem newTarget )
    {
        if ( CurrentTarget == newTarget )
            return;

        CurrentTarget = newTarget;

        if ( CurrentTarget == null )
        {
            Prompt?.Hide();
            return;
        }

        Prompt?.Show( CurrentTarget );
    }
}