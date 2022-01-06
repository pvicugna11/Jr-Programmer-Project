using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    // We override the GoTo function to remove the current transport target, as any go to order will cancel the transport
    public override void GoTo(Vector3 position)
    {
        base.GoTo(position);
    }
    
    protected override void BuildingInRange() {}
    
    //Override all the UI function to give a new name and display what it is currently transporting
    public override string GetName()
    {
        return "Productivity";
    }

    public override string GetData()
    {
        return $"Can move but has no further functionality";
    }

    public override void GetContent(ref List<Building.InventoryEntry> content) {}
}
