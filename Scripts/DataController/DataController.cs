using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataController
{
    private static DataController _instance;

    private string _recordsDataPath = Application.persistentDataPath + "/Records.txt";

    public string RecordsDataPath { get => _recordsDataPath; set => _recordsDataPath = value; }
    public static DataController Instance 
    { 
        get 
        {
            if (_instance == null) _instance = new DataController();
            return _instance;
        }
    }

    public async void WriteNewRecordDataAsync(string data)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(_recordsDataPath, true, System.Text.Encoding.Default))
            {
                await sw.WriteLineAsync(data);
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    public string ReadRecordsData()
    {
        try
        {
            using (StreamReader sr = new StreamReader(_recordsDataPath))
            {
                return sr.ReadToEnd();
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            return null;
        }
    }
}
