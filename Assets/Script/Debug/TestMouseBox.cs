using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMouseBox : MonoBehaviour
{
    public ScreenShakeTest shake;
    public MouseBox CharacterBox;
    public Sprite[] HoverMouseSprites;
    // Start is called before the first frame update
    void Start()
    {
        CharacterBox.MouseSprites = HoverMouseSprites;
        CharacterBox.HoverFunction = (Vector2 position) => { return true; };
        CharacterBox.ClickFunction = (Vector2 v) => { shake.CameraShakeOnce(); return true; };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
