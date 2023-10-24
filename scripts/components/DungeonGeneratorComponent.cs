using System;
using Godot;
using Godot.Collections;

namespace DungeonGame.scripts.components;

[GlobalClass]
public partial class DungeonGeneratorComponent : Node
{
    [Export] public TileMap DungeonTileMap;
    [Export] public Vector2I MainRoomSize = new Vector2I(6, 6);

    [Export] public int VoidLayer;
    [Export] public int GroundLayer = 1;
    [Export] public int AtlasSourceId;

    private void GenerateVoidBackground()
    {
        var rectSize = GetViewport().GetVisibleRect().Size;
        Array<Vector2I> cellsCoords = new();
        var backgroundSize = new Vector2(
            MainRoomSize.X * 2 + rectSize.X / 16,
            MainRoomSize.Y * 2 + rectSize.Y / 16
        );

        for (var x = 0; x < backgroundSize.X; x++)
        {
            for (var y = 0; y < backgroundSize.Y; y++)
            {
                cellsCoords.Add(new Vector2I(
                    (int)(x - (backgroundSize.X / 2)),
                    (int)(y - (backgroundSize.Y / 2))
                ));
            }
        }

        DungeonTileMap.SetCellsTerrainConnect(VoidLayer, cellsCoords, 0, 0, false);
    }

    private void GenerateMainRoom()
    {
        Array<Vector2I> cellsCoords = new();

        for (var x = 0; x < MainRoomSize.X; x++)
        {
            for (var y = 0; y < MainRoomSize.Y; y++)
            {
                cellsCoords.Add(new Vector2I(x, y));
            }
        }

        DungeonTileMap.SetCellsTerrainConnect(GroundLayer, cellsCoords, 0, 2, false);
    }

    public override void _Ready()
    {
        GenerateVoidBackground();
        GenerateMainRoom();
    }
}