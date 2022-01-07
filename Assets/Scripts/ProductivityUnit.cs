using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    public float ProductionSpeedToMultiply = 2f;

    private ResourcePile m_CurrentTransportTarget;

    // We override the GoTo function to remove the current transport target, as any go to order will cancel the transport
    public override void GoTo(Vector3 position)
    {
        base.GoTo(position);
    }
    
    protected override void BuildingInRange()
    {
        ResourcePile rp = (m_Target is ResourcePile resourcePile) ? resourcePile : null;
        if (rp != m_CurrentTransportTarget)
        {
            if (m_CurrentTransportTarget) m_CurrentTransportTarget.ProductionSpeed /= ProductionSpeedToMultiply;
            rp.ProductionSpeed *= ProductionSpeedToMultiply;
            m_CurrentTransportTarget = rp;
        }
    }
    
    //Override all the UI function to give a new name and display what it is currently transporting
    public override string GetName()
    {
        return "Productivity";
    }

    public override string GetData()
    {
        return $"Increases resource item production in a base";
    }

    public override void GetContent(ref List<Building.InventoryEntry> content) {}
}
