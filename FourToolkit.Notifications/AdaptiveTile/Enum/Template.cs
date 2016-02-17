namespace FourToolkit.Notifications.AdaptiveTile.Enum
{
    public enum Template
    {
        None, TileSmall, TileMedium, TileWide, TileLarge
    }

    public static class TemplateExt
    {
        public static double GetWidth(this Template size)
        {
            switch (size)
            {
                case Template.TileSmall:
                    return 70;
                case Template.TileMedium:
                    return 150;
                case Template.TileWide:
                case Template.TileLarge:
                    return 310;
            }
            return 0;
        }

        public static double GetHeight(this Template size)
        {
            switch (size)
            {
                case Template.TileSmall:
                    return 70;
                case Template.TileMedium:
                case Template.TileWide:
                    return 150;
                case Template.TileLarge:
                    return 310;
            }
            return 0;
        }
    }
}
