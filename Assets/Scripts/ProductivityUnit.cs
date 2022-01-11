using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    private ResourcePile m_CurrentPile = null;
    public float ProductivityMultiplier = 2;

    public override void GoTo(Building target)
    {
        ResetProductivity();
        base.GoTo(target);
    }

    // We override the GoTo function to remove the current transport target, as any go to order will cancel the transport
    public override void GoTo(Vector3 position)
    {
        ResetProductivity();
        base.GoTo(position);
    }
    
    protected override void BuildingInRange()
    {
        if (!m_CurrentPile)
        {
            ResourcePile pile = m_Target as ResourcePile;

            if (pile)
            {
                m_CurrentPile = pile;
                m_CurrentPile.ProductionSpeed *= ProductivityMultiplier;
            }
        }
    }

    private void ResetProductivity()
    {
        if (m_CurrentPile != null)
        {
            m_CurrentPile.ProductionSpeed /= ProductivityMultiplier;
            m_CurrentPile = null;
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
