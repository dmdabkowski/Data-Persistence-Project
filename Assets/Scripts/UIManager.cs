using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
    using UnityEditor;
#endif

public class UIManager : MonoBehaviour
{
    [System.Serializable]
    public class GameData
    {
        public string playerName;
        public string bestPlayerName;
        public int bestScore;
    }

    public TMP_InputField playerNameInput;
    public static GameData gameData;

    void Start()
    {
        LoadGameData();
    }
    public void StartButtonEvent()
    {
        if(playerNameInput.text.Length > 0)
        {
            gameData.playerName = playerNameInput.text;
            SceneManager.LoadScene(1);
        }
    }

    public void QuitButtonEvent()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    public static void LoadGameData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            gameData = JsonUtility.FromJson<GameData>(json);
        }
    }

    public static void SaveGameData()
    {
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
}
