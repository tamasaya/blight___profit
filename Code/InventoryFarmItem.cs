using Sandbox;
using System.Collections.Generic;

// 1. Твой класс данных (как ты и хотел)
public class InventoryCell
{
    public string Name { get; set; }
    public int Amount { get; set; } = 0;
    public int MaxAmount { get; set; } = 64;
}

// 2. Твой компонент предмета, который наследуется от BaseInventoryItem
// и связывает его с данными
public sealed class InventoryFarmItem : BaseInventoryItem
{
    public InventoryCell Data { get; set; }
}