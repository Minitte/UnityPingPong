
public class GameSettings
{

    public enum GameMode
    {
        CLASSIC
    }

    /// <summary>
    /// Game mode setting
    /// </summary>
    public static GameMode Mode = GameMode.CLASSIC;

    private GameSettings() {}
}