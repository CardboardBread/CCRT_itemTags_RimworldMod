using System.Collections.Generic;
using UnityEngine;

namespace ChiefCurtains.ItemTags
{
    // Collection of unity Colors borrowed from CharacterEditor's color picker.
    // These currently draw the static colors used by tags.
    // I would like to have them evetually appear in a color picker window for editing of tag colors.
    public static class ColorUtil
    {
        public static readonly Color White = new Color(1f, 1f, 1f);
        public static readonly Color LightGray = new Color(0.82f, 0.824f, 0.831f);
        public static readonly Color Gray = new Color(0.714f, 0.718f, 0.733f);
        public static readonly Color DarkGray = new Color(0.506f, 0.51f, 0.525f);
        public static readonly Color Graphite = new Color(0.345f, 0.345f, 0.353f);
        public static readonly Color DimGray = new Color(0.245f, 0.245f, 0.245f);
        public static readonly Color DarkDimGray = new Color(0.175f, 0.175f, 0.175f);
        public static readonly Color Asche = new Color(0.115f, 0.115f, 0.115f);
        public static readonly Color Black = new Color(0f, 0f, 0f);
        public static readonly Color NavyBlue = new Color(0f, 0.082f, 0.267f);
        public static readonly Color DarkBlue = new Color(0.137f, 0.235f, 0.486f);
        public static readonly Color RoyalBlue = new Color(0.157f, 0.376f, 0.678f);
        public static readonly Color Blue = new Color(0.004f, 0.42f, 0.718f);
        public static readonly Color PureBlue = new Color(0f, 0f, 1f);
        public static readonly Color LightBlue = new Color(0.129f, 0.569f, 0.816f);
        public static readonly Color SkyBlue = new Color(0.58f, 0.757f, 0.91f);
        public static readonly Color Maroon = new Color(0.373f, 0f, 0.125f);
        public static readonly Color Burgundy = new Color(0.478f, 0.153f, 0.255f);
        public static readonly Color DarkRed = new Color(0.545f, 0f, 0f);
        public static readonly Color Red = new Color(0.624f, 0.039f, 0.055f);
        public static readonly Color PureRed = new Color(1f, 0f, 0f);
        public static readonly Color LightRed = new Color(0.784f, 0.106f, 0.216f);
        public static readonly Color HotPink = new Color(0.863f, 0.345f, 0.631f);
        public static readonly Color Pink = new Color(0.969f, 0.678f, 0.808f);
        public static readonly Color DarkPurple = new Color(0.251f, 0.157f, 0.384f);
        public static readonly Color Purple = new Color(0.341f, 0.176f, 0.561f);
        public static readonly Color LightPurple = new Color(0.631f, 0.576f, 0.784f);
        public static readonly Color Teal = new Color(0.11f, 0.576f, 0.592f);
        public static readonly Color Turquoise = new Color(0.027f, 0.51f, 0.58f);
        public static readonly Color DarkBrown = new Color(0.282f, 0.2f, 0.125f);
        public static readonly Color Brown = new Color(0.388f, 0.204f, 0.102f);
        public static readonly Color LightBrown = new Color(0.58f, 0.353f, 0.196f);
        public static readonly Color Tawny = new Color(0.784f, 0.329f, 0.098f);
        public static readonly Color Blaze = new Color(0.941f, 0.29f, 0.141f);
        public static readonly Color Orange = new Color(0.949f, 0.369f, 0.133f);
        public static readonly Color LightOrange = new Color(0.973f, 0.58f, 0.133f);
        public static readonly Color Gold = new Color(0.824f, 0.624f, 0.055f);
        public static readonly Color YellowGold = new Color(1f, 0.761f, 0.051f);
        public static readonly Color Yellow = new Color(1f, 0.859f, 0.004f);
        public static readonly Color DarkYellow = new Color(0.953f, 0.886f, 0.227f);
        public static readonly Color Chartreuse = new Color(0.922f, 0.91f, 0.067f);
        public static readonly Color LightYellow = new Color(1f, 0.91f, 0.51f);
        public static readonly Color DarkGreen = new Color(0f, 0.345f, 0.149f);
        public static readonly Color Green = new Color(0.137f, 0.663f, 0.29f);
        public static readonly Color PureGreen = new Color(0f, 1f, 0f);
        public static readonly Color LimeGreen = new Color(0.682f, 0.82f, 0.208f);
        public static readonly Color LightGreen = new Color(0.541f, 0.769f, 0.537f);
        public static readonly Color DarkOlive = new Color(0.255f, 0.282f, 0.149f);
        public static readonly Color Olive = new Color(0.451f, 0.463f, 0.294f);
        public static readonly Color OliveDrab = new Color(0.357f, 0.337f, 0.263f);
        public static readonly Color FoilageGreen = new Color(0.482f, 0.498f, 0.443f);
        public static readonly Color Tan = new Color(0.718f, 0.631f, 0.486f);
        public static readonly Color Beige = new Color(0.827f, 0.741f, 0.545f);
        public static readonly Color Khaki = new Color(0.933f, 0.835f, 0.678f);
        public static readonly Color Peach = new Color(0.996f, 0.859f, 0.733f);
        public static readonly List<Color> ColorList = new List<Color>
        {
            White, LightGray, Gray, DarkGray, Graphite, Black, NavyBlue, DarkBlue, RoyalBlue, Blue, PureBlue, LightBlue,
            SkyBlue, Maroon, Burgundy, DarkRed, Red, PureRed, LightRed, HotPink, Pink, DarkPurple, Purple, LightPurple,
            Teal, Turquoise, DarkBrown, Brown, LightBrown, Tawny, Blaze, Orange, LightOrange, Gold, YellowGold, Yellow,
            DarkYellow, Chartreuse, LightYellow, DarkGreen, Green, PureGreen, LimeGreen, LightGreen, DarkOlive, Olive,
            OliveDrab, FoilageGreen, Tan, Beige, Khaki, Peach
        };
    }
}
