using Godot;
using Godot.Collections;

namespace DungeonGame.scripts.components;

[GlobalClass]
public partial class DungeonGeneratorComponent : Node
{
    [Export] public TileMap DungeonTileMap;
    [Export] public Vector2I MainRoomSize = new Vector2I(6, 6);

    [Export] public int GroundLayer = 1;
    [Export] public int AtlasSourceId;

    private void GenerateMainRoom()
    {
        Vector2I cellCoords = new(1, 1);
        Array<Vector2I> cellsCoords = new();

        for (var x = 0; x < MainRoomSize.X; x++)
        {
            for (var y = 0; y < MainRoomSize.Y; y++)
            {
                cellsCoords.Add(new Vector2I(x, y));
            }
        }

        DungeonTileMap.SetCellsTerrainConnect(GroundLayer, cellsCoords, 0, 1, false);
    }

    public override void _Ready()
    {
        GD.Print("Ready");
        GenerateMainRoom();
    }
}