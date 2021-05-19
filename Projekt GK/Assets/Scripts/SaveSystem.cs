using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Threading;
using System;

public static class SaveSystem
{
    //n to scena która w³aœnie zakoñczono a value to wartoœæ uzyskanych punktów
    public static void SaveScore(ScoreData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.dataPath + "/save.data";
        FileStream stream = new FileStream(path, FileMode.Create);
        stream.Position = 0;
                             
        formatter.Serialize(stream, data);
        Thread.Sleep(1000);
        stream.Close();
    }

    public static ScoreData LoadScore()
    {
        string path = Application.dataPath + "/save.data";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            stream.Position = 0;
            ScoreData data = new ScoreData();
            try
            {
                data = (ScoreData)formatter.Deserialize(stream);
            }
            catch(Exception ex)
            {
                Debug.Log(ex.ToString());
            }
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
