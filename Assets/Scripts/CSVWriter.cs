using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVWriter : MonoBehaviour
{
    public string filename = "";
    public string ID;

    public enum Device { mouse,pad}
    public Device device;

    public float size;
    public float amplitude;

    public float time = 0.0f;
    public float finalTime = 0.0f;
    public int wrong = 0;

    // Start is called before the first frame update
    void Start()
    {
        filename = Application.dataPath + "/" + device + ID + ".csv";
        TextWriter w = new StreamWriter(filename, false);
        w.WriteLine("ID,Size,Amplitude,Time,Wrong,Device");
        w.Close();

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }

    public void WriteCSV()
    {
        TextWriter w = new StreamWriter(filename, true);
        finalTime = time;

        w.WriteLine(ID + ", " + size + ", " + amplitude + ", " + finalTime + ", " + wrong + ", " + device);
        w.Close();

        time = 0;
        wrong = 0;
        finalTime = 0;
    }
}
