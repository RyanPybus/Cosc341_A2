using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Master : MonoBehaviour
{
    public SceneSaver SceneSaver;

    List<GameObject> unOrderedList;
    List<GameObject> OrderedList;
    public GameObject Circle;
    public float radius;
    public float scale;
    public int count;
    public bool nextRound;

    public CSVWriter CSVWriter;

    // 0,4,8,3,7,2,6,1,5,0

    // Start is called before the first frame update
    void Start()
    {
        nextRound = false;
        SceneSaver.UpdateNumbers();
        count = 0;
        radius = SceneSaver.radius;
        scale = SceneSaver.scale;
        CSVWriter.size = scale;
        CSVWriter.amplitude = radius;

        // create circles
        unOrderedList = new List<GameObject>();
        for (int i = 0; i < 9; i++) {
            float x = radius * Mathf.Cos(i * Mathf.PI * 2 / 9); 
            float y = radius * Mathf.Sin(i * Mathf.PI * 2 / 9);
            Vector2 pos = new Vector2(x, y);
            unOrderedList.Add((GameObject)Instantiate(Circle, pos, Quaternion.identity));
            unOrderedList[i].transform.localScale = new Vector2(scale,scale);
        }

        OrderedList = new List<GameObject>();
        OrderedList.Add(unOrderedList[0]);
        OrderedList.Add(unOrderedList[4]);
        OrderedList.Add(unOrderedList[8]);
        OrderedList.Add(unOrderedList[3]);
        OrderedList.Add(unOrderedList[7]);
        OrderedList.Add(unOrderedList[2]);
        OrderedList.Add(unOrderedList[6]);
        OrderedList.Add(unOrderedList[1]);
        OrderedList.Add(unOrderedList[5]);
        OrderedList.Add(unOrderedList[0]);

        OrderedList[count].GetComponent<SpriteRenderer>().color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextRound)
        {
            SceneSaver.count++;
            Debug.Log("FIN");
            foreach (GameObject obj in OrderedList)
            {
                Destroy(obj);
            }
            Start();
        }
    }

    public void nextTarget(GameObject hit)
    {
        if (hit == OrderedList[count])
        {
            OrderedList[count].GetComponent<SpriteRenderer>().color = Color.white;
            count++;
            if (count > 9)
            {
                nextRound = true;
                return;
            }
            OrderedList[count].GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            CSVWriter.wrong = 1;
        }
    }
}
