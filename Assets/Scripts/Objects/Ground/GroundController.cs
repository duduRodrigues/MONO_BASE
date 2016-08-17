using UnityEngine;
using System.Collections;
using Assets.Scripts.Auxiliar.MonoEnums;

public class GroundController : MonoBehaviour {

    private EColor _color;
    private Background _background;
    private ColorController[] _childrenColorControllers;

    void Start()
    {
        _background = FindObjectOfType<Background>();
        _color = ((_background.color == EColor.White) || (_background.color == EColor.Both)) ? EColor.Black : EColor.White;

        _childrenColorControllers = transform.GetComponentsInChildren<ColorController>();
        updateChildrenColors();
    }

    void Update()
    {
        if(_color == _background.color)
        {
            _color = (_background.color == EColor.White) ? EColor.Black : EColor.White;
            updateChildrenColors();
        }

    }

    private void updateChildrenColors()
    {
         for (int i = 0; i < _childrenColorControllers.Length; i++)
            _childrenColorControllers[i].SetFatherColor(_color);
    }
}
