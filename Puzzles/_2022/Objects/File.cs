namespace APIAdventOfCode.Puzzles._2022.Objects
{
    public class File
    {
        public File(string name, int size)
        {
            Name = name;
            Size = size; 
        }

        public string Name { get; }
        public int Size { get; }
    }
}
