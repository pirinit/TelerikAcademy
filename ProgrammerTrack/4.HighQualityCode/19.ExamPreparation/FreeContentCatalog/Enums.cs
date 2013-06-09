namespace FreeContentCatalog
{
    public enum CommandType
    {
        AddBook,
        AddMovie,
        AddSong,
        AddApplication,
        Update,
        Find
    }
    public enum ContentType
    {
        Book,
        Movie,
        Song,
        Application
    }

    public enum ContentProperties
    {
        Title = 0,
        Author,
        Size,
        Url
    }

}
