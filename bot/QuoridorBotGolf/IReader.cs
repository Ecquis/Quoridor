namespace QuoridorBotGolf
{
    public interface IReader
    {
        bool ReadFirstMessage(string data);
        void Read(string data);
    }
}