using UnityEngine;
using System.Collections;

public class MasterMindChangeColor : ContextAction {

    private Color[] _color = new Color[3];
    private int index = 0;

    private EnumColor _enumColor;

    public EnumColor colorEnum
    {
        get { return _enumColor; }
    }

    protected void Awake()
    {
        base.Awake();
        _enumColor = EnumColor.DEFAULT;
        _color[0] = Color.red;
        _color[1] = Color.green;
        _color[2] = Color.blue;
    }
    public override void Action()
    {
        index++;
        if(index > _color.Length -1)
        {
            index = 0;
        }

        renderer.material.color = _color[index];

        ChangeColor(_color[index]);
    }

    private void ChangeColor(Color selfColor)
    {
        if (selfColor == Color.red)
       {
           _enumColor = EnumColor.RED;
       }

        if (selfColor == Color.green)
       {
           _enumColor = EnumColor.GREEN;
       }

        if (selfColor == Color.blue)
       {
           _enumColor = EnumColor.BLUE;
       }
    }
}
