using UnityEngine;

public class SaveLoad : MonoBehaviour
{
	public DatabaseToSave databaseToSave;

	[ContextMenu("Save Database")]
	private void Save()
	{
		if (databaseToSave != null)
		{
			string text = JsonUtility.ToJson(databaseToSave.databaseData);
			Debug.Log(text + "Json String");
		}
		else
		{
			Debug.LogError("database not set!");
		}
	}
}


