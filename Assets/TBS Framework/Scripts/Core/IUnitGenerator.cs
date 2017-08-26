using System.Collections.Generic;

public interface IUnitGenerator
{
    List<Unit> SpawnUnits(List<Cell> cells);
	List<Trigger> SpawnTriggers(List<Cell> cells);
}

