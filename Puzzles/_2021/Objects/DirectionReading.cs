namespace AdventOfCode.Puzzles._2021.Objects;

public class DirectionReading
{
    private readonly BearingEnum _bearing;
    private readonly int _distance;

    public DirectionReading(string bearing, string distance)
    {
        Enum.TryParse(bearing, out this._bearing);
        this._distance = Int32.Parse(distance);
    }

    public BearingEnum Bearing
    {
        get { return _bearing; }
    }

    public int Change
    {
        get { return _distance; }
    }
}