using Godot;

namespace DungeonGame.scripts.components;

public partial class DungeonGeneratorComponent : Node
{
    [Export] public TileMap DungeonTileMap;
    [Export] public Vector2I MainRoomSize = new Vector2I(6, 6);

    [Export]
    public int GroundLayer = 1;
    [Export]
    public int AtlasSourceId = 0;

    private void GenerateMainRoom()
    {
        Vector2I cellCoords = new(1, 1);

        GD.Print("Generating room");

        for (var x = 0; x < MainRoomSize.X; x++)
        {
            for (var y = 0; y < MainRoomSize.Y; y++)
            {
                Vector2I coords = new(x, y);
                DungeonTileMap.SetCell(GroundLayer, coords, AtlasSourceId, cellCoords);
            }
        }
    }

    public override void _Ready()
    {
        GenerateMainRoom();
    }
}