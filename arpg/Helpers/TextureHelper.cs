using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace towerdef.Helpers
{
    public static class TextureHelper
    {
        public static Texture2D HealthTexture { get; set; }
        public static Texture2D BasicTowerTexture { get; set; }
        public static Texture2D MissileTexture { get; set; }
        public static Texture2D HudTexture { get; set; }
        public static Texture2D UndoButtonTexture { get; set; }
        public static List<Texture2D> Enemy1WalkingTextures { get; set; }
        public static List<Texture2D> Enemy2WalkingTextures { get; set; }
        public static Texture2D FireTowerTexture { get; internal set; }
    }
}
