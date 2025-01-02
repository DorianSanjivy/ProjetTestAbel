using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeTest : MonoBehaviour
{
    public Wiggle CameraShake;

    public Transform MainCamera;

    public void CameraShakeOnce()
    {
        CameraShake.RandomWiggle();
    }

    // Start is called before the first frame update
    void Start()
    {
        CameraShake.Init();
    }

    // Update is called once per frame
    void Update()
    {
        CameraShake.Update(Time.deltaTime);
        Vector2 t = CameraShake.GetValue();
        Vector3 tt = new Vector3(t.x, t.y, -10);
        MainCamera.position = tt;

        if(Input.GetKeyDown(KeyCode.Space)){
            CameraShakeOnce();
        }
    }
}
