namespace APIAdventOfCode.Models
{
    public class AOCResponse
    {
        public AOCResponse(string answer)
        {
            Answer = answer;
        }

        public string? Answer { get; set; }
    }
}