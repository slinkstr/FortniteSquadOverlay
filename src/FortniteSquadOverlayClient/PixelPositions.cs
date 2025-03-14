﻿using System;
using System.Linq;

namespace FortniteSquadOverlayClient
{
    public class PixelPositions
    {
        public Size Resolution          { get; set; }
        public int SelectedSlotOffset   { get; set; }
        public Size SlotSize            { get; set; }
        public Coord[] Slots            { get; set; }
        public Coord[] ShieldIcon       { get; set; }
        public Coord[] FuelIcon         { get; set; }
        public Coord[] SpectatingText   { get; set; }
        public Coord Keys               { get; set; }

        public PixelPositions Scale(int scale)
        {
            double scaleMult = (double)scale / 100;
            
            return new PixelPositions()
            {
                Resolution         = Resolution,
                SelectedSlotOffset = (int)Math.Floor(SelectedSlotOffset * scaleMult),
                SlotSize           = new Size((int)(SlotSize.Width * scaleMult), (int)(SlotSize.Height * scaleMult)),
                Slots              = Slots.Select(x => ScaleAboutBottomRight(x, Resolution, scale)).ToArray(),
                ShieldIcon         = ShieldIcon.Select(x => ScaleAboutBottomLeft(x, Resolution, scale)).ToArray(),
                FuelIcon           = FuelIcon.Select(x => ScaleAboutBottomRight(x, Resolution, scale)).ToArray(),
                SpectatingText     = SpectatingText,
                Keys               = ScaleAboutTopRight(Keys, Resolution, scale),
            };
        }

        public PixelPositions InterpolateResolution(Size newResolution)
        {
            return new PixelPositions()
            {
                Resolution         = newResolution,
                SelectedSlotOffset = ScaleLength(SelectedSlotOffset, Resolution.Height, newResolution.Height),
                SlotSize           = ScaleSize(SlotSize, Resolution, newResolution),
                Slots              = Slots.Select(x => ScalePoint(x, Resolution, newResolution)).ToArray(),
                ShieldIcon         = ShieldIcon.Select(x => ScalePoint(x, Resolution, newResolution)).ToArray(),
                FuelIcon           = FuelIcon.Select(x => ScalePoint(x, Resolution, newResolution)).ToArray(),
                SpectatingText     = SpectatingText.Select(x => ScalePoint(x, Resolution, newResolution)).ToArray(),
                Keys               = ScalePoint(Keys, Resolution, newResolution),
            };
        }

        public static PixelPositions GetMatchingPositions(int width, int height, int scale)
        {
            PixelPositions retval = null;
            PixelPositions[] knownPositions = [ Known1080p, Known1440p ];
            foreach (var position in knownPositions)
            {
                if (position.Resolution.Width == width && position.Resolution.Height == height)
                {
                    retval = position;
                    break;
                }
            }

            retval ??= Known1440p.InterpolateResolution(new Size(width, height));

            retval = retval.Scale(scale);
            return retval;
        }

        public static readonly PixelPositions Known1440p = new PixelPositions()
        {
            Resolution         = new Size(2560, 1440),
            SelectedSlotOffset = -13,
            SlotSize           = new Size(104, 104),
            Slots =
            [
                new Coord(1993, 1227),
                new Coord(2102, 1227),
                new Coord(2211, 1227),
                new Coord(2320, 1227),
                new Coord(2428, 1227)
            ],
            ShieldIcon =
            [
                new Coord(44, 1267), // normal
                new Coord(98, 1320), // ranked/rumble
                new Coord(66, 1267) // creative
            ],
            FuelIcon =
            [
                new Coord(2047, 1244)
            ],
            SpectatingText =
            [
                new Coord(1181, 26),
                new Coord(1200, 26)
            ],
            Keys               = new Coord(2456, 1021),
        };

        public static readonly PixelPositions Known1080p = new PixelPositions()
        {
            Resolution         = new Size(1920, 1080),
            SelectedSlotOffset = -11,
            SlotSize           = new Size(78, 78),
            Slots =
            [
                new Coord(1495, 920),
                new Coord(1576, 920),
                new Coord(1658, 920),
                new Coord(1740, 920),
                new Coord(1821, 920)
            ],
            ShieldIcon =
            [
                new Coord(33, 950),
                new Coord(74, 990),
                new Coord(50, 950)

            ],
            FuelIcon =
            [
                new Coord(1535, 933)
            ],
            SpectatingText =
            [
                new Coord(885, 20),
                new Coord(900, 20)
            ],
            Keys               = new Coord(1842, 765),
        };

        private static int ScaleLength(int position, int size, int newSize)
        {
            return (int)((double)position / size * newSize);
        }

        private static Coord ScalePoint(Coord point, Size currentRes, Size newRes)
        {
            var newX = ScaleLength(point.X, currentRes.Width, newRes.Width);
            var newY = ScaleLength(point.Y, currentRes.Height, newRes.Height);
            return new Coord(newX, newY);
        }

        private static Size ScaleSize(Size size, Size currentRes, Size newRes)
        {
            var newWidth  = ScaleLength(size.Width , currentRes.Width , newRes.Width);
            var newHeight = ScaleLength(size.Height, currentRes.Height, newRes.Height);
            return new Size(newWidth, newHeight);
        }

        private static Coord ScaleAboutTopLeft(Coord point, Size size, int scale)
        {
            return ScaleAboutPoint(point, new Coord(0, 0), scale);
        }

        private static Coord ScaleAboutBottomLeft(Coord point, Size size, int scale)
        {
            return ScaleAboutPoint(point, new Coord(0, size.Height), scale);
        }

        private static Coord ScaleAboutTopRight(Coord point, Size size, int scale)
        {
            return ScaleAboutPoint(point, new Coord(size.Width, 0), scale);
        }

        private static Coord ScaleAboutBottomRight(Coord point, Size size, int scale)
        {
            return ScaleAboutPoint(point, new Coord(size.Width, size.Height), scale);
        }

        private static Coord ScaleAboutTopMiddle(Coord point, Size size, int scale)
        {
            return ScaleAboutPoint(point, new Coord(size.Width / 2, 0), scale);
        }

        private static Coord ScaleAboutPoint(Coord point, Coord scalePoint, int scale)
        {
            double scaleMult = (double)scale / 100;

            int diffX = point.X - scalePoint.X;
            int diffY = point.Y - scalePoint.Y;
            double diffXScaled = diffX * scaleMult;
            double diffYScaled = diffY * scaleMult;
            int newX = point.X - diffX + (int)diffXScaled;
            int newY = point.Y - diffY + (int)diffYScaled;

            return new Coord(newX, newY);
        }
    }

    public struct Coord
    {
        public int X;
        public int Y;

        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public struct Size
    {
        public int Width;
        public int Height;

        public Size(int width, int height)
        {
            Width  = width;
            Height = height;
        }
    }
}
