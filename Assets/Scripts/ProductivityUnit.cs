using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    public float ProductionSpeed = 1f;
    private float ProductionSpeedInit;

    private Building m_CurrentTransportTarget;
    private ResourcePile rp = new ResourcePile();

    void Start()
    {
        ProductionSpeedInit = rp.ProductionSpeed;
    }

    protected override void Update()
    {
        if (m_Target != m_CurrentTransportTarget || !m_Target)
        {
            rp.ProductionSpeed = ProductionSpeedInit;
            m_CurrentTransportTarget = m_Target;
        }

        if (m_Target)
        {
            float distance = Vector3.Distance(m_Target.transform.position, transform.position);
            if (distance < 2.0f)
            {
                m_Agent.isStopped = true;
                BuildingInRange();
            }
        }
    }

    // We override the GoTo function to remove the current transport target, as any go to order will cancel the transport
    public override void GoTo(Vector3 position)
    {
        base.GoTo(position);
        m_CurrentTransportTarget = null;
    }
    
    protected override void BuildingInRange()
    {
        rp = (m_Target is ResourcePile resourcePile) ? resourcePile : rp;
        rp.ProductionSpeed = ProductionSpeed;
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
