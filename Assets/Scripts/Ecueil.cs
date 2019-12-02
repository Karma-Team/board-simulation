using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ecueil : MonoBehaviour
{
    private bool _isOnLeft;
    public bool IsOnLeft
    {
        get => _isOnLeft;
    }
    private bool _isOnTop;
    public bool IsOnTop
    {
        get => _isOnTop;
    }

    private Cup[] cups;

    // Start is called before the first frame update
    void Start()
    {
        _isOnLeft = gameObject.transform.position.x < 1.5;
        _isOnTop = gameObject.transform.position.z > 1.0;
        // Get cups
        cups = gameObject.GetComponentsInChildren<Cup>();
        if (cups == null || cups.Length == 0)
        {
            Debug.LogError("Ecueil can't find its cups.");
            return;
        }
        // Sort cups - buble sort des familles
        for (int ptrCup = 1; ptrCup < cups.Length; ++ptrCup)
        {
            for (int ptrSort = cups.Length-1; ptrSort > ptrCup; --ptrSort)
            {
                bool swap = false;
                if (this.IsOnTop)
                {
                    swap = cups[ptrSort - 1].Position.x > cups[ptrSort].Position.x;
                }
                else
                {
                    swap = cups[ptrSort - 1].Position.z > cups[ptrSort].Position.z;
                }
                if (swap)
                {
                    Cup cupTmp = cups[ptrSort];
                    cups[ptrSort] = cups[ptrSort - 1];
                    cups[ptrSort - 1] = cupTmp;
                }
            }
        }
    }

    private void CupSwap(int posCup1, int posCup2)
    {
        cups[posCup1].SwapCup(cups[posCup2]);
        Cup cupTmp = cups[posCup1];
        cups[posCup1] = cups[posCup2];
        cups[posCup2] = cupTmp;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Arrange(bool[] isRed)
    {
        int ptrCup, ptr;
        for (ptr = 0; ptr < isRed.Length; ++ptr)
        {
            for (ptrCup = ptr; ptrCup <= cups.Length; ++ptrCup)
            {
                if (ptrCup == cups.Length)
                {
                    Debug.LogError("Cup not found...");
                    break;
                }
                if (cups[ptrCup].IsRed == isRed[ptr])
                {
                    if (ptrCup != ptr)
                    {
                        this.CupSwap(ptrCup, ptr);
                    }
                    break;
                }
            }
        }
    }
}
