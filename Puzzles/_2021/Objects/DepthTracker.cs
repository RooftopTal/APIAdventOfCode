namespace AdventOfCode.Puzzles._2021.Objects;

public class DepthTracker
{
    private readonly List<int> _depths;

    public DepthTracker()
    {
        this._depths = new List<int>();
    }

    /*
     * Depths must always have 4 entries; this keeps that true
     */
    public void UpdateDepths(int newDepth)
    {
        _depths.Add(newDepth);

        if (_depths.Count > 4)
        {
            _depths.RemoveAt(0);
        }
    }

    public bool IsTrackable()
    {
        return _depths.Count == 4;
    }

    public bool DepthIncreased()
    {
        int oldDepth = _depths.GetRange(0, 3).Sum();
        int newDepth = _depths.GetRange(1, 3).Sum();
        return newDepth > oldDepth;
    }
}