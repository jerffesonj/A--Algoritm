using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TileScript : MonoBehaviour
{
    public int x;
    public int y;
    public TileScript ultimoTile;
    public TMP_Text localText;
    public TMP_Text GText;
    public TMP_Text HText;
    public TMP_Text FText;
    public bool andavel = true;

    public int gCost;
    public int hCost;
    public int fCost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        GText.text = gCost.ToString();
        HText.text = hCost.ToString();
        FText.text = fCost.ToString();
    }
    public void SetText()
    {
        localText.text = x + "," + y;
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    public void GoingCheckTile()
    {
        GetComponent<SpriteRenderer>().color = Color.green;
    }
    public void CheckedTile()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }
}
