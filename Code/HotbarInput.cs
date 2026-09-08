using Sandbox;

public sealed class HotbarInput : Component
{
    private BaseInventoryComponent Inventory;

    protected override void OnStart()
    {
        Inventory = Components.Get<BaseInventoryComponent>();

        if ( Inventory == null )
        {
            Log.Warning( "HotbarInput: Inventory not found" );
        }
    }

    protected override void OnUpdate()
    {
        if ( Inventory == null )
            return;

        for ( int i = 0; i < 8; i++ )
        {
            if ( Input.Keyboard.Pressed( (i + 1).ToString() ) )
            {
                SelectSlot( i );
            }
        }
    }

    private void SelectSlot( int slot )
    {
        var item = Inventory.GetSlot( slot );

        if ( item == null )
            return;

        Inventory.Switch( item );
    }
}