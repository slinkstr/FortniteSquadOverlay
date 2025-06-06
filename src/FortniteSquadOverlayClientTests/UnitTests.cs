﻿using System.Drawing;
using System.IO.Compression;
using FortniteSquadOverlayClient;

namespace FortniteSquadOverlayClientTests
{
    public class UnitTests
    {
        public static IEnumerable<object[]> IsPlayingtData => new List<object[]>
        {
            //new object[] { ".\\test-data\\screens\\1080p-100hud\\bus.png"               , PixelPositions.Known1080p, false }, // debatable
            new object[] { ".\\test-data\\screens\\1080p-100hud\\downed.png"            , PixelPositions.Known1080p, true },
            new object[] { ".\\test-data\\screens\\1080p-100hud\\midgame.png"           , PixelPositions.Known1080p, true },
            new object[] { ".\\test-data\\screens\\1080p-100hud\\pregame.png"           , PixelPositions.Known1080p, true },

            new object[] { ".\\test-data\\screens\\1440p-80hud\\driving.png"            , PixelPositions.Known1440p.Scale(80), true },
            new object[] { ".\\test-data\\screens\\1440p-80hud\\midgame.png"            , PixelPositions.Known1440p.Scale(80), true },
            new object[] { ".\\test-data\\screens\\1440p-80hud\\midgame-ranked.png"     , PixelPositions.Known1440p.Scale(80), true },
            
            new object[] { ".\\test-data\\screens\\1440p-80hud-colorblind\\deut-5.png"  , PixelPositions.Known1440p.Scale(80), true },

            //new object[] { ".\\test-data\\screens\\1440p-100hud\\driving.png"           , PixelPositions.Known1440p, true }, // debatable
            new object[] { ".\\test-data\\screens\\1440p-100hud\\midgame.png"           , PixelPositions.Known1440p, true },
            new object[] { ".\\test-data\\screens\\1440p-100hud\\main-menu.png"         , PixelPositions.Known1440p, false },
            new object[] { ".\\test-data\\screens\\1440p-100hud\\midgame-ranked.png"    , PixelPositions.Known1440p, true },
            
            new object[] { ".\\test-data\\screens\\1440p-100hud-colorblind\\deut-5.png" , PixelPositions.Known1440p, true },
            new object[] { ".\\test-data\\screens\\1440p-100hud-colorblind\\deut-10.png", PixelPositions.Known1440p, true },
            new object[] { ".\\test-data\\screens\\1440p-100hud-colorblind\\prot-5.png" , PixelPositions.Known1440p, true },
            new object[] { ".\\test-data\\screens\\1440p-100hud-colorblind\\prot-10.png", PixelPositions.Known1440p, true },
            new object[] { ".\\test-data\\screens\\1440p-100hud-colorblind\\trit-5.png" , PixelPositions.Known1440p, true },
            new object[] { ".\\test-data\\screens\\1440p-100hud-colorblind\\trit-10.png", PixelPositions.Known1440p, true },
        };

        [Theory]
        [MemberData(nameof(IsPlayingtData))]
        public void IsPlaying(string imagePath, PixelPositions positions, bool expectedResult)
        {
            Bitmap bitmap = PngToBitmap(imagePath);

            var result = ImageProcessing.IsPlaying(bitmap, positions);

            Assert.Equal(expectedResult, result);
        }

        public static IEnumerable<object[]> IsDrivingData => new List<object[]>
        {
            new object[] { ".\\test-data\\screens\\1440p-80hud\\driving.png" , PixelPositions.Known1440p.Scale(80), true },
            new object[] { ".\\test-data\\screens\\1440p-80hud\\midgame.png" , PixelPositions.Known1440p.Scale(80), false },
            new object[] { ".\\test-data\\screens\\1440p-100hud\\driving.png", PixelPositions.Known1440p, true },
        };

        [Theory]
        [MemberData(nameof(IsDrivingData))]
        public void IsDriving(string imagePath, PixelPositions positions, bool expectedResult)
        {
            Bitmap bitmap = PngToBitmap(imagePath);

            var result = ImageProcessing.IsDriving(bitmap, positions);

            Assert.Equal(expectedResult, result);
        }

        public static IEnumerable<object[]> IsSpectatingData => new List<object[]>
        {
            new object[] { ".\\test-data\\screens\\1080p-100hud\\spectating.png", PixelPositions.Known1080p, true },
            new object[] { ".\\test-data\\screens\\1440p-80hud\\spectating.png" , PixelPositions.Known1440p.Scale(80), true },
            new object[] { ".\\test-data\\screens\\1440p-100hud\\midgame.png"   , PixelPositions.Known1440p.Scale(80), false },
        };

        [Theory]
        [MemberData(nameof(IsSpectatingData))]
        public void IsSpectating(string imagePath, PixelPositions positions, bool expectedResult)
        {
            Bitmap bitmap = PngToBitmap(imagePath);

            var result = ImageProcessing.IsSpectating(bitmap, positions);

            Assert.Equal(expectedResult, result);
        }

        // ************************************************************************************************************

        private static Bitmap PngToBitmap(string path)
        {
            return new Bitmap(path);
        }

        private static string gzipToText(string path)
        {
            using FileStream   originalStream   = File.OpenRead(path);
            using GZipStream   decompressStream = new(originalStream, CompressionMode.Decompress);
            using StreamReader reader           = new StreamReader(decompressStream);
            string result = reader.ReadToEnd();
            return result;
        }
    }
}
