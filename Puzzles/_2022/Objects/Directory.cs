namespace APIAdventOfCode.Puzzles._2022.Objects
{
    public class Directory
    {
        public string Name { get; }
        public Directory? ParentDirectory { get; }
        public List<Directory> ChildDirectories { get; }
        public List<File> ChildFiles { get; }

        public Directory(string name, Directory? parentDirectory)
        {
            Name = name;
            ParentDirectory = parentDirectory;
            ChildDirectories = new List<Directory>();
            ChildFiles = new List<File>();
        }

        public int FindDirectorySize()
        {
            var childDirectorySize = 0;
            foreach (Directory dir in ChildDirectories)
            {
                childDirectorySize += dir.FindDirectorySize();
            }

            return childDirectorySize + FindChildFileSize();
        }

        public int FindChildFileSize()
        {
            return ChildFiles.Select(x => x.Size)
                .Sum();
        }

        public void AddDirectory(Directory directory)
        {
            ChildDirectories.Add(directory);
        }

        public void AddFile(File file)
        {
            ChildFiles.Add(file);
        } 
    }
}
