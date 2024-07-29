using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class SceneSaver : MonoBehaviour
{
    public int count; 
    public float radius;
    public float scale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateNumbers()
    {
        if (count > 8) EditorApplication.ExitPlaymode();

        switch (count)
        {
            case 0:
                radius = 1.5f;
                scale = 0.9f;
                break;
            case 1:
                radius = 1.5f;
                scale = 0.6f;
                break;
            case 2:
                radius = 1.5f;
                scale = 0.3f;
                break;
            case 3:
                radius = 3f;
                scale = 0.9f;
                break;
            case 4:
                radius = 3f;
                scale = 0.6f;
                break;
            case 5:
                radius = 3f;
                scale = 0.3f;
                break;
            case 6:
                radius = 4.5f;
                scale = 0.9f;
                break;
            case 7:
                radius = 4.5f;
                scale = 0.6f;
                break;
            case 8:
                radius = 4.5f;
                scale = 0.3f;
                break;
                
        } 
        
    }
}
