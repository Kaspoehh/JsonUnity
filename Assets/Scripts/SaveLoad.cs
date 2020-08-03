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
		string saveData = JsonUtility.ToJson(this, true);
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(string.Concat(Application.dataPath, savePath));
		File.WriteAllText(file.ToString(), saveData);
		bf.Serialize(file, saveData);
		file.Close();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        if (File.Exists(string.Concat(Application.dataPath, savePath)))
        {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(string.Concat(Application.dataPath, savePath), FileMode.Open);
			//JsonUtility.FromJsonOverwrite(/*bf.Deserialize(file).ToString()*/file.ToString(), database.databaseData);
			string json = File.ReadAllText(file.ToString());
			JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
			file.Close();
		}
		else
		{
			Debug.LogError("File doesnt excist yet");
		}
    }

	private void Start()
	{
		database.LoadSprites();
	}

}


