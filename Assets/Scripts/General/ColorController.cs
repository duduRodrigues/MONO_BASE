using UnityEngine;
using System.Collections;
using Assets.Scripts.Auxiliar.MonoEnums;

public class ColorController : MonoBehaviour {

    public EColor color;
    private EColor _actualColor;
    private Background _background;
    private SpriteColorController[] _childrenColorControllers;

    void Start()
    {
        _background = FindObjectOfType<Background>();

        if (color == EColor.Both)
            _actualColor = ((_background.color == EColor.White) || (_background.color == EColor.Both)) ? EColor.Black : EColor.White;
        else
            _actualColor = color;

        _childrenColorControllers = transform.GetComponentsInChildren<SpriteColorController>();
        updateChildrenColors();
    }

    void Update()
    {
        if(color == EColor.Both && _actualColor == _background.color)
        {
            _actualColor = (_background.color == EColor.White) ? EColor.Black : EColor.White;
            updateChildrenColors();
        }

    }

    private void updateChildrenColors()
    {
         for (int i = 0; i < _childrenColorControllers.Length; i++)
            _childrenColorControllers[i].SetFatherColor(_actualColor);
    }
}
