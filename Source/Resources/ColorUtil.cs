using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace ChiefCurtains.ItemTags
{
    // Collection of unity Colors borrowed from CharacterEditor's color picker.
    // These currently draw the static colors used by tags.
    // I would like to have them evetually appear in a color picker window for editing of tag colors.
    public static class ColorUtil
    {
        public static Color White => GetColor(1f, 1f, 1f);
        public static Color LightGray => GetColor(0.82f, 0.824f, 0.831f);
        public static Color Gray => GetColor(0.714f, 0.718f, 0.733f);
        public static Color DarkGray => GetColor(0.506f, 0.51f, 0.525f);
        public static Color Graphite => GetColor(0.345f, 0.345f, 0.353f);
        public static Color DimGray => GetColor(0.245f, 0.245f, 0.245f);
        public static Color DarkDimGray => GetColor(0.175f, 0.175f, 0.175f);
        public static Color Asche => GetColor(0.115f, 0.115f, 0.115f);
        public static Color Black => GetColor(0f, 0f, 0f);
        public static Color NavyBlue => GetColor(0f, 0.082f, 0.267f);
        public static Color DarkBlue => GetColor(0.137f, 0.235f, 0.486f);
        public static Color RoyalBlue => GetColor(0.157f, 0.376f, 0.678f);
        public static Color Blue => GetColor(0.004f, 0.42f, 0.718f);
        public static Color PureBlue => GetColor(0f, 0f, 1f);
        public static Color LightBlue => GetColor(0.129f, 0.569f, 0.816f);
        public static Color SkyBlue => GetColor(0.58f, 0.757f, 0.91f);
        public static Color Maroon => GetColor(0.373f, 0f, 0.125f);
        public static Color Burgundy => GetColor(0.478f, 0.153f, 0.255f);
        public static Color DarkRed => GetColor(0.545f, 0f, 0f);
        public static Color Red => GetColor(0.624f, 0.039f, 0.055f);
        public static Color PureRed => GetColor(1f, 0f, 0f);
        public static Color LightRed => GetColor(0.784f, 0.106f, 0.216f);
        public static Color HotPink => GetColor(0.863f, 0.345f, 0.631f);
        public static Color Pink => GetColor(0.969f, 0.678f, 0.808f);
        public static Color DarkPurple => GetColor(0.251f, 0.157f, 0.384f);
        public static Color Purple => GetColor(0.341f, 0.176f, 0.561f);
        public static Color LightPurple => GetColor(0.631f, 0.576f, 0.784f);
        public static Color Teal => GetColor(0.11f, 0.576f, 0.592f);
        public static Color Turquoise => GetColor(0.027f, 0.51f, 0.58f);
        public static Color DarkBrown => GetColor(0.282f, 0.2f, 0.125f);
        public static Color Brown => GetColor(0.388f, 0.204f, 0.102f);
        public static Color LightBrown => GetColor(0.58f, 0.353f, 0.196f);
        public static Color Tawny => GetColor(0.784f, 0.329f, 0.098f);
        public static Color Blaze => GetColor(0.941f, 0.29f, 0.141f);
        public static Color Orange => GetColor(0.949f, 0.369f, 0.133f);
        public static Color LightOrange => GetColor(0.973f, 0.58f, 0.133f);
        public static Color Gold => GetColor(0.824f, 0.624f, 0.055f);
        public static Color YellowGold => GetColor(1f, 0.761f, 0.051f);
        public static Color Yellow => GetColor(1f, 0.859f, 0.004f);
        public static Color DarkYellow => GetColor(0.953f, 0.886f, 0.227f);
        public static Color Chartreuse => GetColor(0.922f, 0.91f, 0.067f);
        public static Color LightYellow => GetColor(1f, 0.91f, 0.51f);
        public static Color DarkGreen => GetColor(0f, 0.345f, 0.149f);
        public static Color Green => GetColor(0.137f, 0.663f, 0.29f);
        public static Color PureGreen => GetColor(0f, 1f, 0f);
        public static Color LimeGreen => GetColor(0.682f, 0.82f, 0.208f);
        public static Color LightGreen => GetColor(0.541f, 0.769f, 0.537f);
        public static Color DarkOlive => GetColor(0.255f, 0.282f, 0.149f);
        public static Color Olive => GetColor(0.451f, 0.463f, 0.294f);
        public static Color OliveDrab => GetColor(0.357f, 0.337f, 0.263f);
        public static Color FoilageGreen => GetColor(0.482f, 0.498f, 0.443f);
        public static Color Tan => GetColor(0.718f, 0.631f, 0.486f);
        public static Color Beige => GetColor(0.827f, 0.741f, 0.545f);
        public static Color Khaki => GetColor(0.933f, 0.835f, 0.678f);
        public static Color Peach => GetColor(0.996f, 0.859f, 0.733f);

        public static List<Color> ColorList = new List<Color>
        {
            White, LightGray, Gray, DarkGray, Graphite, DimGray, Asche, DarkDimGray, Black, NavyBlue, DarkBlue,
            RoyalBlue, Blue, PureBlue, LightBlue, SkyBlue, Maroon, Burgundy, DarkRed, Red, PureRed, LightRed, HotPink,
            Pink, DarkPurple, Purple, LightPurple, Teal, Turquoise, DarkBrown, Brown, LightBrown, Tawny, Blaze, Orange,
            LightOrange, Gold, YellowGold, Yellow, DarkYellow, Chartreuse, LightYellow, DarkGreen, Green, PureGreen,
            LimeGreen, LightGreen, DarkOlive, Olive, OliveDrab, FoilageGreen, Tan, Beige, Khaki, Peach
        };

        public static Dictionary<Tuple<float, float, float>, Color> ColorCache = new Dictionary<Tuple<float, float, float>, Color>();

        public static Color GetColor(Tuple<float, float, float> rgb)
        {
            if (ColorCache.ContainsKey(rgb))
            {
                return ColorCache[rgb];
            }
            else
            {
                var newColor = new Color(rgb.Item1, rgb.Item2, rgb.Item3);
                ColorCache.Add(rgb, newColor);
                return newColor;
            }
        }

        public static Color GetColor(float r, float g, float b) => GetColor(Tuple.Create(r, g, b));
    }
}
