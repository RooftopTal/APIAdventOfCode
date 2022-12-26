namespace AdventOfCode.Common;

public static class EnumerableExtensions
{
    public static IEnumerable<List<TSource>> Split<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        var list = new List<TSource>();

        foreach (var element in source)
        {
            if (predicate(element))
            {
                if (list.Count > 0)
                {
                    yield return list;
                    list = new List<TSource>();
                }
            }
            else
            {
                list.Add(element);
            }
        }

        if (list.Count > 0)
        {
            yield return list;
        }
    }

    public static IEnumerable<TResult> ToFormattedList<TElement, TResult>(
        this IEnumerable<TElement> source,
        int count,
        Func<List<TElement>, TResult> formatter)
    {
        return source.SplitGroups(count).Select(arg => formatter(arg.ToList()));
    }

    public static IEnumerable<IEnumerable<T>> SplitGroups<T>(this IEnumerable<T> source, int size)
    {
        var i = 0;
        return
            from element in source
            group element by i++ / size into splitGroups
            select splitGroups.AsEnumerable();
    }
}