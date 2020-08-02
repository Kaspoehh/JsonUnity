using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Database", menuName = "JsonUtility/Database")]
public class DatabaseToSave : ScriptableObject
{
	public DatabaseData databaseData;

	private void Awake()
	{

	//	for (int i = 0; i < databaseData.numbersToSave.Length; i++)
	//	{
	//		var imagePath = ("Images/" + databaseData.numbersToSave[i].ImageName);
	//		var sprite = Resources.Load<Sprite>(imagePath);
	//		databaseData.numbersToSave[i].image = sprite;
	//	}
	}

	private void OnEnable()
	{
		//for (int i = 0; i < databaseData.numbersToSave.Length; i++)
		//{
		//	var imagePath = ("/Images" + databaseData.numbersToSave[i].ImageName);
		//	var sprite = Resources.Load<Sprite>("Images/test");
		//	databaseData.numbersToSave[i].image = null;
		//}

		//SetImageToNull
		//for (int i = 0; i < databaseData.numbersToSave.Length; i++)
		//{
		//	databaseData.numbersToSave[i].image = null;
		//}
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