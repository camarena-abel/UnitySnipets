// Ejemplo de script super básico para almacenar, cargar y guardar una partida en formato JSON

using UnityEngine;
using System.IO;
using System.Collections.Generic;

[System.Serializable]
public class GameData {
    public int life;
    public int coins;
    public List<string> defeatedEnemies;

    public GameData()
    {
        life = 100;
        coins = 0;
        defeatedEnemies = new List<string>();
    }
}

public static class GameState {
    // ruta y nombre de archivo del json
    private static string sgPath = Application.persistentDataPath + "/savegame.json";
    
    // datos de la partida actual
    public static GameData gameData = new GameData();
    
    public static void Save() {
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(sgPath, json);
    }

    public static bool Load() {
        if (File.Exists(sgPath)) {
            // cargamos
            string json = File.ReadAllText(sgPath);
            gameData = JsonUtility.FromJson<GameData>(json);
            return true;
        } else {
            // no existe!
            return false;
        }
    }
}