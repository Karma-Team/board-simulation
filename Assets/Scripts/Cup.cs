using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    private bool _isRed;
    public bool IsRed
    {
        get => _isRed;
    }

    public Vector3 Position
    {
        get
        {
            return gameObject.transform.position;
        }

        set
        {
            gameObject.transform.position = value;
            //xpos = Position.x;
        }
    }

    public void Move(Vector3 direction)
    {
        gameObject.transform.Translate(direction);
    }

    public void SwapCup(Cup otherCup)
    {
        Vector3 otherCupPos = otherCup.Position;
        Vector3 thisCupPos = this.Position;
        thisCupPos.z += 100;
        otherCup.Position = thisCupPos;
        this.Position = otherCupPos;
        thisCupPos.z -= 100;
        otherCup.Position = thisCupPos;
    }

    // Start is called before the first frame update
    void Start()
    {
        _isRed = gameObject.name.Contains("Rouge");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
