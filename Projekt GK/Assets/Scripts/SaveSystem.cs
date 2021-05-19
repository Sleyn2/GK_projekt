using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Threading;

public static class SaveSystem
{
    //n to scena która w³aœnie zakoñczono a value to wartoœæ uzyskanych punktów
    public static void SaveScore(ScoreData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/saveData.temp";
        FileStream stream = new FileStream(path, FileMode.Create);
        stream.Position = 0;
                             
        formatter.Serialize(stream, data);
        Thread.Sleep(1000);
        stream.Close();
    }

    public static ScoreData LoadScore()
    {
        string path = Application.persistentDataPath + "/saveData.temp";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            stream.Position = 0;

            ScoreData data = formatter.Deserialize(stream) as ScoreData;
            Thread.Sleep(1000);
            stream.Close();
            return data;
        }
        else
        {
            //error loading file
            ScoreData data = new ScoreData();
            return data;
        }
    }
}
