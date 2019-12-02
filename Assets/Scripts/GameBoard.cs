using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    //Monolithic
    private static GameBoard _instance;
    public static GameBoard Instance
    { 
    get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameBoard>();
                if (_instance == null)
                {
                    Debug.LogError("Can't find GameBoard instance.");
                    return null;
                }
            }
            return _instance;
        }
    }

    private bool[][] LeftEcueilCombinaison;
    private bool[][] RightEcueilCombinaison;

    // Start is called before the first frame update
    void Start()
    {
        // Init EcueilCombinaison
        LeftEcueilCombinaison = new bool[3][];
        RightEcueilCombinaison = new bool[3][];
        LeftEcueilCombinaison[0] = new bool[] { false, true, false, false, true };
        RightEcueilCombinaison[0] = new bool[] { false, true, true, false, true };
        LeftEcueilCombinaison[1] = new bool[] { false, false, true, false, true };
        RightEcueilCombinaison[1] = new bool[] { false, true, false, true, true };
        LeftEcueilCombinaison[2] = new bool[] { false, false, false, true, true };
        RightEcueilCombinaison[2] = new bool[] { false, false, true, true, true };


        // Random arrangement for ecueil
        int selectedCombinaison = Random.Range(0, 3);
        Debug.Log("Combinaison de l'écueil : " + (selectedCombinaison + 1));
        // Arrange EcueilHaut
        Ecueil[] ecueils = gameObject.GetComponentsInChildren<Ecueil>();
        foreach (Ecueil ecueil in ecueils)
        {
            if (ecueil.IsOnTop)
            {
                if (ecueil.IsOnLeft)
                {
                    ecueil.Arrange(LeftEcueilCombinaison[selectedCombinaison]);
                }
                else
                {
                    ecueil.Arrange(RightEcueilCombinaison[selectedCombinaison]);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
