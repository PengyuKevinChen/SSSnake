namespace SSSnake
{
    // Credit: Moo ICT @ https://www.youtube.com/watch?v=TzaCn1ZPalI&t=3415s
    public class Settings
    {
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static string directions;

        public Settings()
        {
            Width = 16;
            Height = 16;
            directions = "left";
        }
        
    }
}