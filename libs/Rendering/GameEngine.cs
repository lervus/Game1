﻿using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Nodes;

namespace libs;

using System.Security.Cryptography;
using Newtonsoft.Json;

public static class GameEngine
{
    private static GameObject? _focusedObject;

    private static Map map = new Map();

    private static List<GameObject> gameObjects = new List<GameObject>();

    //TODO implement a listener interface


    public static Map GetMap()
    {
        return map;
    }

    public static GameObject GetFocusedObject()
    {
        return _focusedObject;
    }

    public static void Setup()
    {
        dynamic gameData = FileHandler.ReadJson();

        map.MapWidth = gameData.map.width;
        map.MapHeight = gameData.map.height;

        foreach (var gameObject in gameData.gameObjects)
        {
            GameObject newObj = new GameObject();
            int type = (int)gameObject.Type;

            switch (type)
            {
    //             case 0: // Wall
    //     newObj = gameObject.ToObject<Wall>();
    //     break;
    // case 1: // Box
    //     newObj = gameObject.ToObject<Box>();
    //     break;
    // case 2: // StorageLocation
    //     newObj = gameObject.ToObject<StorageLocation>();
    //     break;
    // case 3: // Player
    //     newObj = gameObject.ToObject<Player>();
    //     break;
    // case 4: // BoxOnStorage
    //     newObj = gameObject.ToObject<BoxOnStorage>();
    //     break;
    // case 5: // PlayerOnStorage
    //     newObj = gameObject.ToObject<PlayerOnStorage>();
    //     break;
    // case 6: // EmptyStorageLocation
    //     newObj = gameObject.ToObject<EmptyStorageLocation>();
    //     break;
    // case 7: // BoxOnWrongStorage
    //     newObj = gameObject.ToObject<BoxOnWrongStorage>();
    //     break;
    // case 8: // PlayerOnWrongStorage
    //     newObj = gameObject.ToObject<PlayerOnWrongStorage>();
    //     break;
    // case 9: // TargetStorageLocation
    //     newObj = gameObject.ToObject<TargetStorageLocation>();
    //     break;
    // case 10: // Floor
    //     newObj = gameObject.ToObject<Floor>();
    //     break;
    // case 11: // EmptySpace
    //     newObj = gameObject.ToObject<EmptySpace>();
    //     break;
    // case 12: // Target
    //     newObj = gameObject.ToObject<Target>();
    //     // break;
                case 0:
                    newObj = gameObject.ToObject<Queen>();
                    break;
                case 1:
                    newObj = gameObject.ToObject<King>();
                    break;
                case 2:
                    newObj = gameObject.ToObject<Bishop>();
                    break;
                case 3:
                    newObj = gameObject.ToObject<Knight>();
                    break;
                case 4:
                    newObj = gameObject.ToObject<Rook>();
                    break;
                case 5:
                    newObj = gameObject.ToObject<Pawn>();
                    break;
            }

            AddGameObject(newObj);
        }
    }

    public static void Render()
    {
        //Clean the map
        Console.Clear();

        _focusedObject = gameObjects[0];

        map.Initialize();

        PlaceGameObjects();

        //Render the map
        for (int i = 0; i < map.MapHeight; i++)
        {
            for (int j = 0; j < map.MapWidth; j++)
            {
                DrawObject(map.Get(i, j));
            }
            Console.WriteLine();
        }
    }

    public static void AddGameObject(GameObject gameObject)
    {
        gameObjects.Add(gameObject);
    }

    private static void PlaceGameObjects()
    {

        gameObjects.ForEach(delegate (GameObject obj)
        {
            map.Set(obj);
        });
    }

    private static void DrawObject(GameObject gameObject)
    {

        Console.ResetColor();

        if (gameObject != null)
        {
            Console.ForegroundColor = gameObject.Color;
            Console.Write(gameObject.CharRepresentation);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(' ');
        }
    }
}
