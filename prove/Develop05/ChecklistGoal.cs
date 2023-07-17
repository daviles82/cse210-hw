
class ChecklistGoal : Goal
{
  private int target, bonus, progress;

  public ChecklistGoal(string _name, string _description, int _points, int _target, int _bonus) :
  base(_name, _description, _points)
  {
    target = _target;
    bonus = _bonus;
    progress = 0;
  }

  public int Target
  {
    get { return target; }
  }

  public int Bonus
  {
    get { return bonus; }
  }

  public int Progress
  {
    get { return progress; }
    set { progress = value; }
  }


  public override void RecordEvent()
  {
      progress++;
  }

  public override bool IsComplete()
  {
    return progress == target;
  }

  public override string GetCheckboxString()
  {
    if (IsComplete())
    {
        return "[X]";
    }
    else
    {
        return "[ ]";
    }
  }

  public override string GetStringRepresentation()
  {
    return $"Checklist Goal: {name}\nDescription: {description}\nPoints: {points}\nTarget: {target}\nBonus: {bonus}\nAmount Completed: {progress}";
  }

}