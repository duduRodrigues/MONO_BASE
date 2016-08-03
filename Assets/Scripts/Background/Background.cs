using UnityEngine;
using System.Collections;
using Assets.Scripts.Auxiliar.MonoEnums;

public class Background : MonoBehaviour {
    public EColor color;

    // Use this for initialization
    void Start () {
        if (color == EColor.Both)
            color = EColor.White;
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void ChangeColor()
    {
        color = color == EColor.White ? EColor.Black : EColor.White;
    }

    public EColor GetColor()
    {
        return color;
    }
}
