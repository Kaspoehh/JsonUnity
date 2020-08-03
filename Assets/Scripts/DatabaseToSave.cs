using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Database", menuName = "JsonUtility/Database")]
public class DatabaseToSave : ScriptableObject
{
	public string SaveName;
	public DatabaseData databaseData;

	private void Awake()
	{
	}

	public void LoadSprites()
	{
		for (int i = 0; i < databaseData.numbersToSave.Length; i++)
		{
			string imagePath = ("Images/" + databaseData.numbersToSave[i].ImageName);
			var sprite = Resources.Load<Sprite>(imagePath);
			databaseData.numbersToSave[i].image = sprite;
		}
	}

	/*Clearing Database data*/
	[ContextMenu("Reset Database")]
	public void Reset()
	{
		databaseData.numbersToSave = null; 
	}

	/*Saving And Loading*/
	[ContextMenu("Save")]
	public void Save()
	{
		string json = JsonUtility.ToJson(databaseData, true);
		File.WriteAllText(string.Concat(Application.dataPath, SaveName), json);
		Debug.Log("Saved @ location " + (string.Concat(Application.dataPath, SaveName)));
	}

	[ContextMenu("Load")]
	public void Load()
	{
		if (File.Exists(string.Concat(Application.dataPath, SaveName)))
		{
			string json = File.ReadAllText(string.Concat(Application.dataPath, SaveName));

			DatabaseData _databasedata = JsonUtility.FromJson<DatabaseData>(json);

			databaseData = _databasedata;
		}
		else
		{
			Debug.LogError("There is no save file");
		}
	}
}

[Serializable]
public class DatabaseData
{
	public Data[] numbersToSave = new Data[5];
}

[Serializable]
public class Data
{
	public int numbersToSave;
	public string ImageName;
	public Sprite image;

}