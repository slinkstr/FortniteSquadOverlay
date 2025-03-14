﻿using System.Drawing;
using FortniteSquadOverlayClient.Properties;

namespace FortniteSquadOverlayClient
{
    public static class ImageProcessing
    {
        public static bool IsPlaying(Bitmap screenshot, PixelPositions positions)
        {
            if (screenshot == null) { return false; }

            foreach (var pos in positions.ShieldIcon)
            {
                var pix = screenshot.GetPixel(pos.X, pos.Y);
                if (BrightEnough(pix, 175)) { return true; }
            }
            Program.Logger.LogDebug("Could not detect shield icon.");
            return false;
        }

        public static bool IsDriving(Bitmap screenshot, PixelPositions positions)
        {
            if (screenshot == null) { return false; }

            foreach (var pos in positions.FuelIcon)
            {
                var pix = screenshot.GetPixel(pos.X, pos.Y);
                if (!BrightEnough(pix, 255)) { return false; }
            }
            Program.Logger.LogDebug("Detected driving.");
            return true;
        }

        public static bool IsSpectating(Bitmap screenshot, PixelPositions positions)
        {
            if (screenshot == null) { return false; }

            foreach (var pos in positions.SpectatingText)
            {
                var pix = screenshot.GetPixel(pos.X, pos.Y);
                if (!BrightEnough(pix, 255)) { return false; }
            }
            Program.Logger.LogDebug("Detected spectating.");
            return true;
        }

        public static Bitmap MarkStaleImage(Bitmap bmp)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                int width = bmp.Width;
                int height = bmp.Height;

                Image outdated = Resources.outdated;

                Rectangle rect = new Rectangle(0, 0, width, height);
                using (Brush darken = new SolidBrush(Color.FromArgb(96, Color.Black)))
                {
                    g.FillRectangle(darken, rect);
                }

                var smallestSide = (height < width) ? height : width;
                var leftEdge = (width / 2) - (smallestSide / 2);
                var topEdge = (height / 2) - (smallestSide / 2);

                g.DrawImage(outdated, new Rectangle(leftEdge + (int)(smallestSide * 0.05),
                                                    topEdge + (int)(smallestSide * 0.05),
                                                    smallestSide - (int)(smallestSide * 0.10),
                                                    smallestSide - (int)(smallestSide * 0.10)));
            }
            return bmp;
        }

        public static Bitmap CropGear(Bitmap bmp, PixelPositions positions)
        {
            int slotSelected = -1;
            for (int i = 0; i < positions.Slots.Length; i++)
            {
                var pix = bmp.GetPixel(positions.Slots[i].X, positions.Slots[i].Y);

                if (pix.R < 255 || pix.G < 255 || pix.B < 255)
                {
                    // FIXME: wtf is this checking for?
                    if (pix.R != 127 || pix.G != 127 || pix.B != 127)
                    {
                        continue;
                    }
                }

                slotSelected = i;
                break;
            }

            Program.Logger.LogDebug($"Selected slot: {slotSelected}.");

            Bitmap cropped = new Bitmap(positions.SlotSize.Width * 5, positions.SlotSize.Height);
            using (Graphics g = Graphics.FromImage(cropped))
            {
                for (int i = 0; i < positions.Slots.Length; i++)
                {
                    var ofs = (slotSelected == i) ? positions.SelectedSlotOffset : 0;
                    g.DrawImage(bmp,
                                new Rectangle(i * positions.SlotSize.Width, 0, positions.SlotSize.Width, positions.SlotSize.Height),
                                new Rectangle(positions.Slots[i].X, positions.Slots[i].Y + ofs, positions.SlotSize.Width, positions.SlotSize.Height),
                                GraphicsUnit.Pixel);
                }

                // keys (defunct but keeping commented in case they add it back)
                //g.DrawImage(bmp,
                //            new Rectangle(positions.SlotSize.Width * 5, 0, positions.SlotSize.Width, positions.SlotSize.Height),
                //            new Rectangle(positions.Keys.X, positions.Keys.Y, positions.SlotSize.Width, positions.SlotSize.Height),
                //            GraphicsUnit.Pixel);
            }

            return cropped;
        }

        public static void RenderDebugMarkers(ref Bitmap blankScreenshot, PixelPositions positions)
        {
            Pen pen = new Pen(Color.Red, 1);

            using (Graphics g = Graphics.FromImage(blankScreenshot))
            {
                foreach (var slot in positions.Slots)
                {
                    g.DrawRectangle(pen, new Rectangle(slot.X - 1, slot.Y - 1, positions.SlotSize.Width + 1, positions.SlotSize.Height + 1));
                }

                // keys (defunct but keeping commented in case they add it back)
                //g.DrawRectangle(pen, new Rectangle(positions.Keys.X - 1, positions.Keys.Y - 1, positions.SlotSize.Width + 1, positions.SlotSize.Height + 1));

                foreach (var pos in positions.ShieldIcon)
                {
                    g.DrawEllipse(pen, pos.X - 1, pos.Y - 1, 2, 2);
                }

                foreach (var pos in positions.FuelIcon)
                {
                    g.DrawEllipse(pen, pos.X - 1, pos.Y - 1, 2, 2);
                }

                foreach (var pos in positions.SpectatingText)
                {
                    g.DrawEllipse(pen, pos.X - 1, pos.Y - 1, 2, 2);
                }
            }
        }

        private static bool BrightEnough(Color color, int threshold)
        {
            if (color.R < threshold || color.G < threshold || color.B < threshold)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
