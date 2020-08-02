using Packages.Rider.Editor.UnitTesting;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public DatabaseToSave database;
    public string savePath;

    [ContextMenu("Save")]
    public void Save()
    {
        Debug.Log(savePath + "The Save Path");
		string saveData = JsonUtility.ToJson(database, true);
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(string.Concat(Application.dataPath, savePath));
		bf.Serialize(file, saveData);
		file.Close();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(string.Concat(Application.dataPath, savePath), FileMode.Open);
			JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), database);
			file.Close();
		}
    }

	private void Start()
	{
		database.LoadSprites();
	}

}


