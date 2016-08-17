using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {

    private Background _background;

    void Start () {
        _background = FindObjectOfType<Background>();
        
	}
	
	void Update () {
        KeyboardCalls();
	}

    void KeyboardCalls()
    {
        if (Input.GetKeyDown(KeyCode.X))
            _background.ChangeColor();
    }
}
