namespace APIAdventOfCode.Puzzles._2022.Objects
{
    public class Communique
    {

        private readonly String _encodedMessage;
        
        public CommsMarker FirstMarker { get; }

        public Communique(String encodedMessage)
        {
            _encodedMessage = encodedMessage;

            FirstMarker = FindMarker();
        }

        private CommsMarker FindMarker()
        {
            int charsProcessed = 0;
            CommsBuffer commsBuffer = new CommsBuffer();

            foreach (char bit in _encodedMessage.ToCharArray()) {
                charsProcessed++;
                commsBuffer.UpdateBuffer(bit);

                if (commsBuffer.IsMarker(bit))
                {
                    return new CommsMarker(
                        charsProcessed,
                        commsBuffer.GetCurrentMarker());
                }
            }

            throw new Exception("Could not find marker in communique");
        }
    }

    public class CommsMarker
    {
        public int CharsToMarker { get; set;}
        public String Marker { get; set; }

        public CommsMarker(int charsToMarker, String marker)
        {
            CharsToMarker = charsToMarker;
            Marker = marker;
        }
    }

    public class CommsBuffer
    {
        private readonly int _bufferLength = 14;
        private readonly int _markerLength = 14;
        private List<char> _currentBits { get; }

        public CommsBuffer() {
            _currentBits = new List<char>();
        }


        public void UpdateBuffer(char bit)
        {
            _currentBits.Add(bit);
            
            if (_currentBits.Count > _bufferLength) { 
                _currentBits.RemoveAt(0);
            }
        }

        public String GetCurrentMarker()
        {
            return String.Concat(_currentBits);
        }

        public bool IsMarker(char bit)
        {
            return _currentBits.Distinct().Count() == _markerLength;
        }
    }
}
