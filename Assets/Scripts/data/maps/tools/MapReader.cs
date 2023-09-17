﻿using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapReader
{
    public void ReadForPlaytime(MapManager manager)
    {
        Tilemap level1 = manager.level1;
        Tilemap level2 = manager.level2;
        Tilemap level3 = manager.level3;
        string path = Application.dataPath + "/Resources/Maps/" + manager.mapData.path + ".pokemap";
        StreamReader reader = File.OpenText(path);
        string inString = reader.ReadToEnd().Replace("?", "AAAA").Replace("@", "AA");
        Debug.Log(inString.Length);
        byte[] data = System.Convert.FromBase64String(inString);
        manager.collision = new byte[manager.mapData.width + 2, manager.mapData.height + 2];
        manager.wildData = new byte[manager.mapData.width + 2, manager.mapData.height + 2];
        level1.ClearAllTiles();
        level2.ClearAllTiles();
        level3.ClearAllTiles();
        for (int x = 0; x < manager.mapData.width; x++)
        {
            for (int y = 0; y < manager.mapData.height; y++)
            {
                int offset = (x * manager.mapData.height + y) * 26 + 2;
                level1.SetTile(new Vector3Int(2 * x, 2 * y),
                    Tiles.TileTable[data[offset] + (data[offset + 1] * 256)]);
                level2.SetTile(new Vector3Int(2 * x, 2 * y),
                    Tiles.TileTable[data[offset + 2] + (data[offset + 3] * 256)]);
                level3.SetTile(new Vector3Int(2 * x, 2 * y),
                    Tiles.TileTable[data[offset + 4] + (data[offset + 5] * 256)]);
                level1.SetTile(new Vector3Int(2 * x + 1, 2 * y),
                    Tiles.TileTable[data[offset + 6] + (data[offset + 7] * 256)]);
                level2.SetTile(new Vector3Int(2 * x + 1, 2 * y),
                    Tiles.TileTable[data[offset + 8] + (data[offset + 9] * 256)]);
                level3.SetTile(new Vector3Int(2 * x + 1, 2 * y),
                    Tiles.TileTable[data[offset + 10] + (data[offset + 11] * 256)]);
                level1.SetTile(new Vector3Int(2 * x, 2 * y + 1),
                    Tiles.TileTable[data[offset + 12] + (data[offset + 13] * 256)]);
                level2.SetTile(new Vector3Int(2 * x, 2 * y + 1),
                    Tiles.TileTable[data[offset + 14] + (data[offset + 15] * 256)]);
                level3.SetTile(new Vector3Int(2 * x, 2 * y + 1),
                    Tiles.TileTable[data[offset + 16] + (data[offset + 17] * 256)]);
                level1.SetTile(new Vector3Int(2 * x + 1, 2 * y + 1),
                    Tiles.TileTable[data[offset + 18] + (data[offset + 19] * 256)]);
                level2.SetTile(new Vector3Int(2 * x + 1, 2 * y + 1),
                    Tiles.TileTable[data[offset + 20] + (data[offset + 21] * 256)]);
                level3.SetTile(new Vector3Int(2 * x + 1, 2 * y + 1),
                    Tiles.TileTable[data[offset + 22] + (data[offset + 23] * 256)]);
                manager.collision[x + 1, y + 1] = data[offset + 24];
                manager.wildData[x + 1, y + 1] = data[offset + 24];
            }
        }
        foreach (Connection i in manager.mapData.connection)
        {
            MapData connectedMap = Map.MapTable[(int)i.map];
            string connectionPath = Application.dataPath + "/Resources/Maps/" + connectedMap.path + ".pokemap";
            StreamReader connectionReader = File.OpenText(connectionPath);
            string connectionString = connectionReader.ReadToEnd().Replace("?", "AAAA").Replace("@", "AA");
            byte[] connectionData = System.Convert.FromBase64String(connectionString);
            switch (i.direction)
            {
                case Direction.N:
                    for (int x = 0; x < connectedMap.width; x++)
                    {
                        if(x + i.offset >= 0 && x + i.offset < manager.mapData.width)
                        manager.collision[x + i.offset + 1, manager.mapData.height + 1]
                            = connectionData[(26 * x * manager.mapData.height) + 26];
                        for (int y = 0; y < connectedMap.height; y++)
                        {
                            int offset = (x * connectedMap.height + y) * 26 + 2;
                            level1.SetTile(new Vector3Int(2 * x + i.offset, 2 * y + (2 * manager.mapData.height)),
                                Tiles.TileTable[connectionData[offset] + (connectionData[offset + 1] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x + i.offset, 2 * y + (2 * manager.mapData.height)),
                                Tiles.TileTable[connectionData[offset + 2] + (connectionData[offset + 3] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x + i.offset, 2 * y + (2 * manager.mapData.height)),
                                Tiles.TileTable[connectionData[offset + 4] + (connectionData[offset + 5] * 256)]);
                            level1.SetTile(new Vector3Int(2 * x + i.offset + 1, 2 * y + (2 * manager.mapData.height)),
                                Tiles.TileTable[connectionData[offset + 6] + (connectionData[offset + 7] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x + i.offset + 1, 2 * y + (2 * manager.mapData.height)),
                                Tiles.TileTable[connectionData[offset + 8] + (connectionData[offset + 9] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x + i.offset + 1, 2 * y + (2 * manager.mapData.height)),
                                Tiles.TileTable[connectionData[offset + 10] + (connectionData[offset + 11] * 256)]);
                            level1.SetTile(new Vector3Int(2 * x + i.offset, 2 * y + 1 + (2 * manager.mapData.height)),
                                Tiles.TileTable[connectionData[offset + 12] + (connectionData[offset + 13] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x + i.offset, 2 * y + 1 + (2 * manager.mapData.height)),
                                Tiles.TileTable[connectionData[offset + 14] + (connectionData[offset + 15] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x + i.offset, 2 * y + 1 + (2 * manager.mapData.height)),
                                Tiles.TileTable[connectionData[offset + 16] + (connectionData[offset + 17] * 256)]);
                            level1.SetTile(new Vector3Int(2 * x + i.offset + 1, 2 * y + 1 + (2 * manager.mapData.height)),
                                Tiles.TileTable[connectionData[offset + 18] + (connectionData[offset + 19] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x + i.offset + 1, 2 * y + 1 + (2 * manager.mapData.height)),
                                Tiles.TileTable[connectionData[offset + 20] + (connectionData[offset + 21] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x + i.offset + 1, 2 * y + 1 + (2 * manager.mapData.height)),
                                Tiles.TileTable[connectionData[offset + 22] + (connectionData[offset + 23] * 256)]);
                        }
                    }
                    break;
                case Direction.S:
                    for (int x = 0; x < connectedMap.width; x++)
                    {
                        if (x + i.offset >= 0 && x + i.offset < manager.mapData.width)
                            manager.collision[x + i.offset + 1, 0]
                                = connectionData[(26 * ((x + 1) * manager.mapData.height - 1)) + 26];
                        for (int y = 0; y < connectedMap.height; y++)
                        {
                            int offset = (x * connectedMap.height + y) * 26 + 2;
                            level1.SetTile(new Vector3Int(2 * x + i.offset, 2 * y - (2 * connectedMap.height)),
                                Tiles.TileTable[connectionData[offset] + (connectionData[offset + 1] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x + i.offset, 2 * y - (2 * connectedMap.height)),
                                Tiles.TileTable[connectionData[offset + 2] + (connectionData[offset + 3] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x + i.offset, 2 * y - (2 * connectedMap.height)),
                                Tiles.TileTable[connectionData[offset + 4] + (connectionData[offset + 5] * 256)]);
                            level1.SetTile(new Vector3Int(2 * x + i.offset + 1, 2 * y - (2 * connectedMap.height)),
                                Tiles.TileTable[connectionData[offset + 6] + (connectionData[offset + 7] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x + i.offset + 1, 2 * y - (2 * connectedMap.height)),
                                Tiles.TileTable[connectionData[offset + 8] + (connectionData[offset + 9] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x + i.offset + 1, 2 * y - (2 * connectedMap.height)),
                                Tiles.TileTable[connectionData[offset + 10] + (connectionData[offset + 11] * 256)]);
                            level1.SetTile(new Vector3Int(2 * x + i.offset, 2 * y + 1 - (2 * connectedMap.height)),
                                Tiles.TileTable[connectionData[offset + 12] + (connectionData[offset + 13] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x + i.offset, 2 * y + 1 - (2 * connectedMap.height)),
                                Tiles.TileTable[connectionData[offset + 14] + (connectionData[offset + 15] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x + i.offset, 2 * y + 1 - (2 * connectedMap.height)),
                                Tiles.TileTable[connectionData[offset + 16] + (connectionData[offset + 17] * 256)]);
                            level1.SetTile(new Vector3Int(2 * x + i.offset + 1, 2 * y + 1 - (2 * connectedMap.height)),
                                Tiles.TileTable[connectionData[offset + 18] + (connectionData[offset + 19] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x + i.offset + 1, 2 * y + 1 - (2 * connectedMap.height)),
                                Tiles.TileTable[connectionData[offset + 20] + (connectionData[offset + 21] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x + i.offset + 1, 2 * y + 1 - (2 * connectedMap.height)),
                                Tiles.TileTable[connectionData[offset + 22] + (connectionData[offset + 23] * 256)]);
                        }
                    }
                    break;
                case Direction.E:
                    for (int x = 0; x < connectedMap.width; x++)
                    {
                        for (int y = 0; y < connectedMap.height; y++)
                        {
                            int offset = (x * connectedMap.height + y) * 26 + 2;
                            if (x == 0 && y + i.offset >= 0 && y + i.offset < manager.mapData.height)
                            {
                                manager.collision[manager.mapData.width + 1, y + i.offset + 1]
                                    = connectionData[offset + 24];
                            }
                            level1.SetTile(new Vector3Int(2 * x + (2 * manager.mapData.width), 2 * y + i.offset),
                                Tiles.TileTable[connectionData[offset] + (connectionData[offset + 1] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x + (2 * manager.mapData.width), 2 * y + i.offset),
                                Tiles.TileTable[connectionData[offset + 2] + (connectionData[offset + 3] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x + (2 * manager.mapData.width), 2 * y + i.offset),
                                Tiles.TileTable[connectionData[offset + 4] + (connectionData[offset + 5] * 256)]);
                            level1.SetTile(new Vector3Int(2 * x + (2 * manager.mapData.width) + 1, 2 * y + i.offset),
                                Tiles.TileTable[connectionData[offset + 6] + (connectionData[offset + 7] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x + (2 * manager.mapData.width) + 1, 2 * y + i.offset),
                                Tiles.TileTable[connectionData[offset + 8] + (connectionData[offset + 9] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x + (2 * manager.mapData.width) + 1, 2 * y + i.offset),
                                Tiles.TileTable[connectionData[offset + 10] + (connectionData[offset + 11] * 256)]);
                            level1.SetTile(new Vector3Int(2 * x + (2 * manager.mapData.width), 2 * y + 1 + i.offset),
                                Tiles.TileTable[connectionData[offset + 12] + (connectionData[offset + 13] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x + (2 * manager.mapData.width), 2 * y + 1 + i.offset),
                                Tiles.TileTable[connectionData[offset + 14] + (connectionData[offset + 15] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x + (2 * manager.mapData.width), 2 * y + 1 + i.offset),
                                Tiles.TileTable[connectionData[offset + 16] + (connectionData[offset + 17] * 256)]);
                            level1.SetTile(new Vector3Int(2 * x + (2 * manager.mapData.width) + 1, 2 * y + 1 + i.offset),
                                Tiles.TileTable[connectionData[offset + 18] + (connectionData[offset + 19] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x + (2 * manager.mapData.width) + 1, 2 * y + 1 + i.offset),
                                Tiles.TileTable[connectionData[offset + 20] + (connectionData[offset + 21] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x + (2 * manager.mapData.width) + 1, 2 * y + 1 + i.offset),
                                Tiles.TileTable[connectionData[offset + 22] + (connectionData[offset + 23] * 256)]);
                        }
                    }
                    break;
                case Direction.W:
                    for (int x = 0; x < connectedMap.width; x++)
                    {
                        for (int y = 0; y < connectedMap.height; y++)
                        {
                            int offset = (x * connectedMap.height + y) * 26 + 2;
                            if (x == connectedMap.width - 1 && y + i.offset >= 0 && y + i.offset < manager.mapData.height)
                            {
                                manager.collision[0, y + i.offset + 1]
                                    = connectionData[offset + 24];
                            }
                            level1.SetTile(new Vector3Int(2 * x - (2 * connectedMap.width), 2 * y + i.offset),
                                Tiles.TileTable[connectionData[offset] + (connectionData[offset + 1] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x - (2 * connectedMap.width), 2 * y + i.offset),
                                Tiles.TileTable[connectionData[offset + 2] + (connectionData[offset + 3] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x - (2 * connectedMap.width), 2 * y + i.offset),
                                Tiles.TileTable[connectionData[offset + 4] + (connectionData[offset + 5] * 256)]);
                            level1.SetTile(new Vector3Int(2 * x - (2 * connectedMap.width) + 1, 2 * y + i.offset),
                                Tiles.TileTable[connectionData[offset + 6] + (connectionData[offset + 7] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x - (2 * connectedMap.width) + 1, 2 * y + i.offset),
                                Tiles.TileTable[connectionData[offset + 8] + (connectionData[offset + 9] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x - (2 * connectedMap.width) + 1, 2 * y + i.offset),
                                Tiles.TileTable[connectionData[offset + 10] + (connectionData[offset + 11] * 256)]);
                            level1.SetTile(new Vector3Int(2 * x - (2 * connectedMap.width), 2 * y + 1 + i.offset),
                                Tiles.TileTable[connectionData[offset + 12] + (connectionData[offset + 13] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x - (2 * connectedMap.width), 2 * y + 1 + i.offset),
                                Tiles.TileTable[connectionData[offset + 14] + (connectionData[offset + 15] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x - (2 * connectedMap.width), 2 * y + 1 + i.offset),
                                Tiles.TileTable[connectionData[offset + 16] + (connectionData[offset + 17] * 256)]);
                            level1.SetTile(new Vector3Int(2 * x - (2 * connectedMap.width) + 1, 2 * y + 1 + i.offset),
                                Tiles.TileTable[connectionData[offset + 18] + (connectionData[offset + 19] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x - (2 * connectedMap.width) + 1, 2 * y + 1 + i.offset),
                                Tiles.TileTable[connectionData[offset + 20] + (connectionData[offset + 21] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x - (2 * connectedMap.width) + 1, 2 * y + 1 + i.offset),
                                Tiles.TileTable[connectionData[offset + 22] + (connectionData[offset + 23] * 256)]);
                        }
                    }
                    break;
            }
        }
        Debug.Log("Loaded successfully");
    }

    public void RenderNeighborsForEditing(MapHelper mapHelper)
    {
        Tilemap level1 = mapHelper.level1;
        Tilemap level2 = mapHelper.level2;
        Tilemap level3 = mapHelper.level3;
        foreach (Connection i in mapHelper.mapData.connection)
        {
            MapData connectedMap = Map.MapTable[(int)i.map];
            if (!File.Exists(Application.dataPath + "/Resources/Maps/" + connectedMap.path + ".pokemap"))
            {
                Debug.Log("Neighbor " + i.map + " does not exist");
                continue;
            }
            string connectionPath = Application.dataPath + "/Resources/Maps/" + connectedMap.path + ".pokemap";
            StreamReader connectionReader = File.OpenText(connectionPath);
            string connectionString = connectionReader.ReadToEnd().Replace("?", "AAAA").Replace("@", "AA");
            byte[] connectionData = System.Convert.FromBase64String(connectionString);
            switch (i.direction)
            {
                case Direction.N:
                    for (int x = 0; x < connectedMap.width; x++)
                    {
                        for (int y = 0; y < connectedMap.height; y++)
                        {
                            int offset = (x * connectedMap.height + y) * 26 + 2;
                            level1.SetTile(new Vector3Int(2 * x + i.offset, 2 * y + (2 * mapHelper.mapData.height)),
                                Tiles.TileTable[connectionData[offset] + (connectionData[offset + 1] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x + i.offset, 2 * y + (2 * mapHelper.mapData.height)),
                                Tiles.TileTable[connectionData[offset + 2] + (connectionData[offset + 3] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x + i.offset, 2 * y + (2 * mapHelper.mapData.height)),
                                Tiles.TileTable[connectionData[offset + 4] + (connectionData[offset + 5] * 256)]);
                            level1.SetTile(new Vector3Int(2 * x + i.offset + 1, 2 * y + (2 * mapHelper.mapData.height)),
                                Tiles.TileTable[connectionData[offset + 6] + (connectionData[offset + 7] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x + i.offset + 1, 2 * y + (2 * mapHelper.mapData.height)),
                                Tiles.TileTable[connectionData[offset + 8] + (connectionData[offset + 9] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x + i.offset + 1, 2 * y + (2 * mapHelper.mapData.height)),
                                Tiles.TileTable[connectionData[offset + 10] + (connectionData[offset + 11] * 256)]);
                            level1.SetTile(new Vector3Int(2 * x + i.offset, 2 * y + 1 + (2 * mapHelper.mapData.height)),
                                Tiles.TileTable[connectionData[offset + 12] + (connectionData[offset + 13] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x + i.offset, 2 * y + 1 + (2 * mapHelper.mapData.height)),
                                Tiles.TileTable[connectionData[offset + 14] + (connectionData[offset + 15] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x + i.offset, 2 * y + 1 + (2 * mapHelper.mapData.height)),
                                Tiles.TileTable[connectionData[offset + 16] + (connectionData[offset + 17] * 256)]);
                            level1.SetTile(new Vector3Int(2 * x + i.offset + 1, 2 * y + 1 + (2 * mapHelper.mapData.height)),
                                Tiles.TileTable[connectionData[offset + 18] + (connectionData[offset + 19] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x + i.offset + 1, 2 * y + 1 + (2 * mapHelper.mapData.height)),
                                Tiles.TileTable[connectionData[offset + 20] + (connectionData[offset + 21] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x + i.offset + 1, 2 * y + 1 + (2 * mapHelper.mapData.height)),
                                Tiles.TileTable[connectionData[offset + 22] + (connectionData[offset + 23] * 256)]);
                        }
                    }
                    break;
                case Direction.S:
                    for (int x = 0; x < connectedMap.width; x++)
                    {
                        for (int y = 0; y < connectedMap.height; y++)
                        {
                            int offset = (x * connectedMap.height + y) * 26 + 2;
                            level1.SetTile(new Vector3Int(2 * x + i.offset, 2 * y - (2 * connectedMap.height)),
                                Tiles.TileTable[connectionData[offset] + (connectionData[offset + 1] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x + i.offset, 2 * y - (2 * connectedMap.height)),
                                Tiles.TileTable[connectionData[offset + 2] + (connectionData[offset + 3] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x + i.offset, 2 * y - (2 * connectedMap.height)),
                                Tiles.TileTable[connectionData[offset + 4] + (connectionData[offset + 5] * 256)]);
                            level1.SetTile(new Vector3Int(2 * x + i.offset + 1, 2 * y - (2 * connectedMap.height)),
                                Tiles.TileTable[connectionData[offset + 6] + (connectionData[offset + 7] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x + i.offset + 1, 2 * y - (2 * connectedMap.height)),
                                Tiles.TileTable[connectionData[offset + 8] + (connectionData[offset + 9] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x + i.offset + 1, 2 * y - (2 * connectedMap.height)),
                                Tiles.TileTable[connectionData[offset + 10] + (connectionData[offset + 11] * 256)]);
                            level1.SetTile(new Vector3Int(2 * x + i.offset, 2 * y + 1 - (2 * connectedMap.height)),
                                Tiles.TileTable[connectionData[offset + 12] + (connectionData[offset + 13] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x + i.offset, 2 * y + 1 - (2 * connectedMap.height)),
                                Tiles.TileTable[connectionData[offset + 14] + (connectionData[offset + 15] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x + i.offset, 2 * y + 1 - (2 * connectedMap.height)),
                                Tiles.TileTable[connectionData[offset + 16] + (connectionData[offset + 17] * 256)]);
                            level1.SetTile(new Vector3Int(2 * x + i.offset + 1, 2 * y + 1 - (2 * connectedMap.height)),
                                Tiles.TileTable[connectionData[offset + 18] + (connectionData[offset + 19] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x + i.offset + 1, 2 * y + 1 - (2 * connectedMap.height)),
                                Tiles.TileTable[connectionData[offset + 20] + (connectionData[offset + 21] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x + i.offset + 1, 2 * y + 1 - (2 * connectedMap.height)),
                                Tiles.TileTable[connectionData[offset + 22] + (connectionData[offset + 23] * 256)]);
                        }
                    }
                    break;
                case Direction.E:
                    for (int x = 0; x < connectedMap.width; x++)
                    {
                        for (int y = 0; y < connectedMap.height; y++)
                        {
                            int offset = (x * connectedMap.height + y) * 26 + 2;
                            level1.SetTile(new Vector3Int(2 * x + (2 * mapHelper.mapData.width), 2 * y + i.offset),
                                Tiles.TileTable[connectionData[offset] + (connectionData[offset + 1] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x + (2 * mapHelper.mapData.width), 2 * y + i.offset),
                                Tiles.TileTable[connectionData[offset + 2] + (connectionData[offset + 3] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x + (2 * mapHelper.mapData.width), 2 * y + i.offset),
                                Tiles.TileTable[connectionData[offset + 4] + (connectionData[offset + 5] * 256)]);
                            level1.SetTile(new Vector3Int(2 * x + (2 * mapHelper.mapData.width) + 1, 2 * y + i.offset),
                                Tiles.TileTable[connectionData[offset + 6] + (connectionData[offset + 7] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x + (2 * mapHelper.mapData.width) + 1, 2 * y + i.offset),
                                Tiles.TileTable[connectionData[offset + 8] + (connectionData[offset + 9] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x + (2 * mapHelper.mapData.width) + 1, 2 * y + i.offset),
                                Tiles.TileTable[connectionData[offset + 10] + (connectionData[offset + 11] * 256)]);
                            level1.SetTile(new Vector3Int(2 * x + (2 * mapHelper.mapData.width), 2 * y + 1 + i.offset),
                                Tiles.TileTable[connectionData[offset + 12] + (connectionData[offset + 13] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x + (2 * mapHelper.mapData.width), 2 * y + 1 + i.offset),
                                Tiles.TileTable[connectionData[offset + 14] + (connectionData[offset + 15] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x + (2 * mapHelper.mapData.width), 2 * y + 1 + i.offset),
                                Tiles.TileTable[connectionData[offset + 16] + (connectionData[offset + 17] * 256)]);
                            level1.SetTile(new Vector3Int(2 * x + (2 * mapHelper.mapData.width) + 1, 2 * y + 1 + i.offset),
                                Tiles.TileTable[connectionData[offset + 18] + (connectionData[offset + 19] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x + (2 * mapHelper.mapData.width) + 1, 2 * y + 1 + i.offset),
                                Tiles.TileTable[connectionData[offset + 20] + (connectionData[offset + 21] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x + (2 * mapHelper.mapData.width) + 1, 2 * y + 1 + i.offset),
                                Tiles.TileTable[connectionData[offset + 22] + (connectionData[offset + 23] * 256)]);
                        }
                    }
                    break;
                case Direction.W:
                    for (int x = 0; x < connectedMap.width; x++)
                    {
                        for (int y = 0; y < connectedMap.height; y++)
                        {
                            int offset = (x * connectedMap.height + y) * 26 + 2;
                            level1.SetTile(new Vector3Int(2 * x - (2 * connectedMap.width), 2 * y + i.offset),
                                Tiles.TileTable[connectionData[offset] + (connectionData[offset + 1] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x - (2 * connectedMap.width), 2 * y + i.offset),
                                Tiles.TileTable[connectionData[offset + 2] + (connectionData[offset + 3] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x - (2 * connectedMap.width), 2 * y + i.offset),
                                Tiles.TileTable[connectionData[offset + 4] + (connectionData[offset + 5] * 256)]);
                            level1.SetTile(new Vector3Int(2 * x - (2 * connectedMap.width) + 1, 2 * y + i.offset),
                                Tiles.TileTable[connectionData[offset + 6] + (connectionData[offset + 7] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x - (2 * connectedMap.width) + 1, 2 * y + i.offset),
                                Tiles.TileTable[connectionData[offset + 8] + (connectionData[offset + 9] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x - (2 * connectedMap.width) + 1, 2 * y + i.offset),
                                Tiles.TileTable[connectionData[offset + 10] + (connectionData[offset + 11] * 256)]);
                            level1.SetTile(new Vector3Int(2 * x - (2 * connectedMap.width), 2 * y + 1 + i.offset),
                                Tiles.TileTable[connectionData[offset + 12] + (connectionData[offset + 13] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x - (2 * connectedMap.width), 2 * y + 1 + i.offset),
                                Tiles.TileTable[connectionData[offset + 14] + (connectionData[offset + 15] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x - (2 * connectedMap.width), 2 * y + 1 + i.offset),
                                Tiles.TileTable[connectionData[offset + 16] + (connectionData[offset + 17] * 256)]);
                            level1.SetTile(new Vector3Int(2 * x - (2 * connectedMap.width) + 1, 2 * y + 1 + i.offset),
                                Tiles.TileTable[connectionData[offset + 18] + (connectionData[offset + 19] * 256)]);
                            level2.SetTile(new Vector3Int(2 * x - (2 * connectedMap.width) + 1, 2 * y + 1 + i.offset),
                                Tiles.TileTable[connectionData[offset + 20] + (connectionData[offset + 21] * 256)]);
                            level3.SetTile(new Vector3Int(2 * x - (2 * connectedMap.width) + 1, 2 * y + 1 + i.offset),
                                Tiles.TileTable[connectionData[offset + 22] + (connectionData[offset + 23] * 256)]);
                        }
                    }
                    break;
            }
        }
    }
    public void ReadForEditing(MapHelper mapHelper)
    {
        Tilemap level1 = mapHelper.level1;
        Tilemap level2 = mapHelper.level2;
        Tilemap level3 = mapHelper.level3;
        Tilemap collision = mapHelper.collisionMap;
        Tilemap wildData = mapHelper.wildDataMap;
        string path = Application.dataPath + "/Resources/Maps/" + mapHelper.mapData.path + ".pokemap";
        StreamReader reader = File.OpenText(path);
        string inString = reader.ReadToEnd().Replace("?","AAAA").Replace("@","AA");
        Debug.Log(inString.Length);
        byte[] data = System.Convert.FromBase64String(inString);
        level1.ClearAllTiles();
        level2.ClearAllTiles();
        level3.ClearAllTiles();
        collision.ClearAllTiles();
        wildData.ClearAllTiles();
        for (int x = 0; x < mapHelper.mapData.width; x++)
        {
            for (int y = 0; y < mapHelper.mapData.height; y++)
            {
                int offset = (x * mapHelper.mapData.height + y) * 26 + 2;
                level1.SetTile(new Vector3Int(2 * x, 2 * y),
                    Tiles.TileTable[data[offset] + (data[offset + 1] * 256)]);
                level2.SetTile(new Vector3Int(2 * x, 2 * y),
                    Tiles.TileTable[data[offset + 2] + (data[offset + 3] * 256)]);
                level3.SetTile(new Vector3Int(2 * x, 2 * y),
                    Tiles.TileTable[data[offset + 4] + (data[offset + 5] * 256)]);
                level1.SetTile(new Vector3Int(2 * x + 1, 2 * y),
                    Tiles.TileTable[data[offset + 6] + (data[offset + 7] * 256)]);
                level2.SetTile(new Vector3Int(2 * x + 1, 2 * y),
                    Tiles.TileTable[data[offset + 8] + (data[offset + 9] * 256)]);
                level3.SetTile(new Vector3Int(2 * x + 1, 2 * y),
                    Tiles.TileTable[data[offset + 10] + (data[offset + 11] * 256)]);
                level1.SetTile(new Vector3Int(2 * x, 2 * y + 1),
                    Tiles.TileTable[data[offset + 12] + (data[offset + 13] * 256)]);
                level2.SetTile(new Vector3Int(2 * x, 2 * y + 1),
                    Tiles.TileTable[data[offset + 14] + (data[offset + 15] * 256)]);
                level3.SetTile(new Vector3Int(2 * x, 2 * y + 1),
                    Tiles.TileTable[data[offset + 16] + (data[offset + 17] * 256)]);
                level1.SetTile(new Vector3Int(2 * x + 1, 2 * y + 1),
                    Tiles.TileTable[data[offset + 18] + (data[offset + 19] * 256)]);
                level2.SetTile(new Vector3Int(2 * x + 1, 2 * y + 1),
                    Tiles.TileTable[data[offset + 20] + (data[offset + 21] * 256)]);
                level3.SetTile(new Vector3Int(2 * x + 1, 2 * y + 1),
                    Tiles.TileTable[data[offset + 22] + (data[offset + 23] * 256)]);
                collision.SetTile(new Vector3Int(x, y),
                    Tiles.CollisionTileTable[data[offset + 24]]);
                wildData.SetTile(new Vector3Int(x, y),
                    Tiles.CollisionTileTable[data[offset + 25]]);

            }
        }
        RenderNeighborsForEditing(mapHelper);
        Debug.Log("Loaded successfully");
    }

    public void CreateNewMap(MapHelper mapHelper)
    {
        Tilemap level1 = mapHelper.level1;
        Tilemap level2 = mapHelper.level2;
        Tilemap level3 = mapHelper.level3;
        Tilemap collision = mapHelper.collisionMap;
        Tilemap wildData = mapHelper.wildDataMap;
        level1.ClearAllTiles();
        level2.ClearAllTiles();
        level3.ClearAllTiles();
        collision.ClearAllTiles();
        wildData.ClearAllTiles();
        for (int x = 0; x < mapHelper.mapData.width; x++)
        {
            for (int y = 0; y < mapHelper.mapData.height; y++)
            {
                int offset = (x * mapHelper.mapData.height + y) * 26 + 2;
                level1.SetTile(new Vector3Int(2 * x, 2 * y),
                    Tiles.TileTable[(int)TileID.GrassTile2]);
                level1.SetTile(new Vector3Int(2 * x + 1, 2 * y),
                    Tiles.TileTable[(int)TileID.GrassTile1]);
                level1.SetTile(new Vector3Int(2 * x, 2 * y + 1),
                    Tiles.TileTable[(int)TileID.GrassTile1]);
                level1.SetTile(new Vector3Int(2 * x + 1, 2 * y + 1),
                    Tiles.TileTable[(int)TileID.GrassTile2]);
                collision.SetTile(new Vector3Int(x, y),
                    Tiles.CollisionTileTable[(int)CollisionID.Level3]);
                wildData.SetTile(new Vector3Int(x, y),
                    Tiles.CollisionTileTable[(int)CollisionID.Impassable]);

            }
        }
        RenderNeighborsForEditing(mapHelper);
        Debug.Log("Created map successfully");
    }
}