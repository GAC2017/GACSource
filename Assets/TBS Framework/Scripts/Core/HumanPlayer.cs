class HumanPlayer : Player
{
    public override void Play(CellGrid cellGrid)
    {
        cellGrid.CellGridState = new CellGridStateWaitingForInput(cellGrid);

		//Check triggers and see if any is activated and apply the effect
		foreach (Trigger trigger in cellGrid.Triggers) 
		{
			for (int i = 0; i < cellGrid.Units.Count; i++) 
			{
				Unit target = cellGrid.Units [i];

				if (target.IsUnitAffectedByTrigger (trigger)) 
				{
					bool isTargetDead = target.ApplyTriggerEffectAndCheckDead(trigger);

					if (isTargetDead)
						i--;
				}
			}
		}
	}
}