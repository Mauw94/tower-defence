using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace towerdef.Models
{
    public class Animation
    {
        public int CurrentFrame { get; set; }
        public int FrameCount { get; set; }
        public float FrameSpeed { get; set; }
        public bool IsLooping { get; set; }
        public List<Texture2D> Textures{ get; set; }

        public Animation(List<Texture2D> textures)
        {
            Textures = textures;
            FrameCount = textures.Count;
            IsLooping = true;
            FrameSpeed = 0.05f;
        }
    }
}
