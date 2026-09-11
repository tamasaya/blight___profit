using System.Runtime.CompilerServices;
using Sandbox;

public sealed class MultipliedObject : Component
{
    private bool _isClone = false;

    protected override void OnUpdate()
    {
        var player = Scene.Get<PlayerController>();
        // Смещаем на 100 единиц вперёд
        if ( Input.Keyboard.Pressed( "E" ) )
        {
            // Scene.Camera.AddShake( amplitude: 5f, frequency: 40f, duration: 1f );
            Scene.Camera.AddPunch( new Angles( -0.01f, 0.02f, 0.01f ) );

            if ( _isClone ) return;

            var loc = player.LocalPosition + Vector3.Forward * 100;
            var clone = GameObject.Clone( loc );

            var bec = clone.AddComponent<InventoryFarmItem>();
            bec.DisplayName = "couch";

            // Помечаем клон как клон, чтобы он не размножался
            var cloneComponent = clone.Components.Get<MultipliedObject>();


            if ( cloneComponent != null )
                cloneComponent._isClone = true;
        }

        if ( Input.Keyboard.Pressed( "R" ) )
        {
            var inventory = player.GetComponent<InventoryFarm>();

            Log.Info( $"Слотов {inventory.MaxSlots}" );

            for ( int i = 0; i < inventory.MaxSlots; i++ )
            {
                var itemsInSlot = inventory.GetSlotItems( i );

                foreach ( var item in itemsInSlot )
                {
                    if ( item.IsValid() )
                        Log.Info( $"Слот {i}: {item.DisplayName} {item}" );
                }
            }
        }

    }

    protected override void OnStart()
    {

    }
}



