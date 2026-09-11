using Sandbox;
using System.Collections.Generic;

public sealed class InventoryFarm : BaseInventoryComponent
{

    protected override void OnItemAdded( BaseInventoryItem item )
    {
        // Проверяем, что это наш предмет
        if ( item is InventoryFarmItem farmItem )
        {
            // Инициализируем данные, если их нет
            if ( farmItem.Data == null )
            {
                farmItem.Data = new InventoryCell { Name = "couch", Amount = 1 };
            }

            Log.Info( $"В инвентарь добавлено: {farmItem.Data.Name} (x{farmItem.Data.Amount})" );
        }

        base.OnItemAdded( item );
    }

}