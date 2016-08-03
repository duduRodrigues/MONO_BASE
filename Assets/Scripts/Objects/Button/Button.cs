using UnityEngine;
using System.Collections;
using Assets.Scripts.Auxiliar.MonoEnums;

public class Button : MonoBehaviour {

    public bool IsPressed { get; set; }
    public bool IsPressedByPlayer { get; set; }
    public bool IsPressedByBox   { get; set; }

    // Use this for initialization
    void Start()
    {
        IsPressedByPlayer = false;
        IsPressedByBox = false;
        IsPressed = false;
    }

    // Update Is called once per frame
    void Update()
    {
        IsPressed = (IsPressedByPlayer || IsPressedByBox);
    }

    void OnTrIggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == ETagName.Player.GetDescription())
            IsPressedByPlayer = true;

        if (col.gameObject.tag == ETagName.Box.GetDescription())
            IsPressedByBox = true;
    }

    void OnTrIggerExIt2D(Collider2D col)
    {
        if (col.gameObject.tag == ETagName.Player.GetDescription())
            IsPressedByPlayer = false;

        if (col.gameObject.tag == ETagName.Box.GetDescription())
            IsPressedByBox = false;
    }

    public void resetButton()
    {
        IsPressedByBox = false;
        IsPressedByPlayer = false;
        IsPressed = false;
    }
}
