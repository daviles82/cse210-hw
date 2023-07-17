
class SimpleGoal : Goal
{
  private bool isComplete;

  public SimpleGoal(string _name, string _description, int _points) :
  base(_name, _description, _points)
  {
    isComplete = false;
  }

  public override void RecordEvent()
  {
    isComplete = true;
  }

  public override bool IsComplete()
  {
    return isComplete;
  }

  public override string GetCheckboxString()
  {
    return isComplete ? "[X]" : "[ ]";
  }


  public override string GetStringRepresentation()
  {
    return $"Simple Goal: {name}\nDescription: {description}\nPoints: {points}\nIs Complete: {isComplete}";
  }
}