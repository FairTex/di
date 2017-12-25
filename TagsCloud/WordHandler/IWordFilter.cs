namespace TagsCloud
{
    public interface IHandler
    {
        string[] Handle(string[] words);
    }
}