
abstract class Goal
{
  protected string name, description;
  protected int points;

  public Goal(string _name, string _description, int _points)
  {
    name = _name;
    description = _description;
    points = _points;
    
  }

    public string Name
  {
    get { return name; }
  }

  public string Description
  {
    get { return description; }
  }

  public int Points
  {
    get { return points; }
  }


public abstract void RecordEvent();

public abstract bool IsComplete();


public virtual string GetCheckboxString()
{
    return "[ ]";
}
public abstract string GetStringRepresentation();

}