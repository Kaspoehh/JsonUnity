using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "New Database", menuName = "JsonUtility/Database")]
public class DatabaseToSave : ScriptableObject
{
	public DatabaseData databaseData;
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
}