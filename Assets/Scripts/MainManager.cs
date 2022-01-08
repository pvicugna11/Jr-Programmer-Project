using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public Color TeamColor;

    private void Awake()
    {
        // シングルトン
        // MainManagerのインスタンスが1つしか存在しないことを保証する
        if (Instance)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadColor();
    }

    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        // JSONに変換
        string json = JsonUtility.ToJson(data);

        // 文字列をファイルに書き出す
        // 第一引数は，ファイルへのパス；永続的なデータディレクトリにsavefile.jsonというファイルを追加
        // Application.persistentDataPath：https://docs.unity3d.com/ja/2019.4/ScriptReference/Application-persistentDataPath.html
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        // ファイルが存在するかどうかをチェックする
        if (File.Exists(path))
        {
            // ファイルの内容を読む
            string json = File.ReadAllText(path);
            // テキストをSaveDataのインスタンスに変換し直す．
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            TeamColor = data.TeamColor;
        }
    }
}
