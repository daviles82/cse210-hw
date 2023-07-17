
class EternalGoal : Goal
{


  public EternalGoal(string _name, string _description, int _points) :
base(_name, _description, _points)
  {

  }

  public override void RecordEvent()
  {

  }

  public override bool IsComplete()
  {
    return false;
  }

  public override string GetStringRepresentation()
  {
    return $"Eternal Goal: {name}\nDescription: {description}\nPoints: {points}";
  }
}