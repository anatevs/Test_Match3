namespace GameCore
{
    public struct ItemData
    {
        public int ShapeId;

        public int ColorId;

        public int AvatarId;

        public ItemData(int shapeId, int colorId, int avatarId)
        {
            ShapeId = shapeId;
            ColorId = colorId;
            AvatarId = avatarId;
        }
    }
}