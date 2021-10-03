using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBoard : MonoBehaviour
{
    public GameObject tile;

    public int numLinhas;
    public int numColunas;

    public GameObject[,] tabuleiro;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( GenerateNewBoard());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GenerateNewBoard()
    {
        tabuleiro = new GameObject [numLinhas, numColunas];
        for (int coluna = 0; coluna < numColunas; coluna++)
        {
            for (int linha = 0; linha < numLinhas; linha++)
            {
                GameObject tileClone = Instantiate(tile, this.transform.position + new Vector3(coluna * 0.15f, linha * 0.15f, 0), Quaternion.identity);
                tileClone.transform.SetParent(this.transform);
                tileClone.GetComponent<TileScript>().x = linha;
                tileClone.GetComponent<TileScript>().y = coluna;

                if (Random.Range(0, 100) <= 75)
                {
                    tileClone.GetComponent<TileScript>().andavel = true;
                    tileClone.GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    tileClone.GetComponent<TileScript>().andavel = false;
                    tileClone.GetComponent<SpriteRenderer>().enabled = false;
                }
                tabuleiro[linha, coluna] = tileClone;


                tileClone.GetComponent<TileScript>().SetText();
                yield return new WaitForSeconds(0);
            }
        }
    }
}
