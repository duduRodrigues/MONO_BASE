using UnityEngine;
using System.Collections;
using Assets.Scripts.Auxiliar.MonoEnums;

public class ColorController : MonoBehaviour {

    public EColor color;
    private EColor _fatherColor;
    private SpriteRenderer _spriteRenderer;

	void Start () {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (color == _fatherColor)
            _spriteRenderer.enabled = true;
        else
            _spriteRenderer.enabled = false;

	}

    public void SetFatherColor(EColor fatherColor)
    {
        _fatherColor = fatherColor;
    }
}
