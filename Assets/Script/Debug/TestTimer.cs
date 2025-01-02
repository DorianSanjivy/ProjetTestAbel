using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTimer;

public class TestTimer : MonoBehaviour
{
    Timer timer1;

    // Start is called before the first frame update
    void Start()
    {
        // timer : Unity Timer on Github (https://github.com/akbiggs/UnityTimer/tree/master?tab=readme-ov-file)
        timer1 = Timer.Register(5f, () => Debug.Log("5 second timer finish"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
