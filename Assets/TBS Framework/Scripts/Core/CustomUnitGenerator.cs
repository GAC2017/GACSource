using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomUnitGenerator : MonoBehaviour, IUnitGenerator
{
    public Transform UnitsParent;
    public Transform CellsParent;
	public Transform TriggersParent;

    /// <summary>
    /// Returns units that are already children of UnitsParent object.
    /// </summary>
    public List<Unit> SpawnUnits(List<Cell> cells)
    {
        List<Unit> ret = new List<Unit>();
        for (int i = 0; i < UnitsParent.childCount; i++)
        {
            var unit = UnitsParent.GetChild(i).GetComponent<Unit>();
            if(unit !=null)
            {
                var cell = cells.OrderBy(h => Math.Abs((h.transform.position - unit.transform.position).magnitude)).First();
                if (!cell.IsTaken)
                {
                    cell.IsTaken = true;
                    unit.Cell = cell;
                    unit.transform.position = cell.transform.position;
                    unit.Initialize();
                    ret.Add(unit);
                }//Unit gets snapped to the nearest cell
                else
                {
                    Destroy(unit.gameObject);
                }//If the nearest cell is taken, the unit gets destroyed.
            }
            else
            {
                Debug.LogError("Invalid object in Units Parent game object");
            }
            
        }
        return ret;
    }

	/// <summary>
	/// Returns trigger that are already children of TriggersParent object.
	/// To be called by CellGrid.
	/// </summary>
	public List<Trigger> SpawnTriggers(List<Cell> cells)
	{
		List<Trigger> ret = new List<Trigger>();
		for (int i = 0; i < TriggersParent.childCount; i++)
		{
			var trigger = TriggersParent.GetChild(i).GetComponent<Trigger>();
			if(trigger !=null)
			{
				var cell = cells.OrderBy(h => Math.Abs((h.transform.position - trigger.transform.position).magnitude)).First();
				if (!cell.IsTaken)
				{
					cell.IsTaken = false;//SUPER IMPORTANT: THIS ALLOWS UNITS TO STEP INTO THE TRIGGER!!!
					trigger.Cell = cell;
					trigger.transform.position = cell.transform.position;
					trigger.Initialize();
					ret.Add(trigger);
				}//Trigger gets snapped to the nearest cell
				else
				{
					Destroy(trigger.gameObject);
				}//If the nearest cell is taken, the unit gets destroyed.
			}
			else
			{
				Debug.LogError("Invalid object in Triggers Parent game object");
			}

		}
		return ret;
	}

    public void SnapToGrid()
    {
        List<Transform> cells = new List<Transform>();

        foreach(Transform cell in CellsParent)
        {
            cells.Add(cell);
        }

        foreach(Transform unit in UnitsParent)
        {
            var closestCell = cells.OrderBy(h => Math.Abs((h.transform.position - unit.transform.position).magnitude)).First();
            if (!closestCell.GetComponent<Cell>().IsTaken)
            {
                Vector3 offset = new Vector3(0,0, closestCell.GetComponent<Cell>().GetCellDimensions().z);
                unit.position = closestCell.transform.position - offset;
            }//Unit gets snapped to the nearest cell
        }
    }
}

