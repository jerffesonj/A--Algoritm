using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBoard : MonoBehaviour
{
    public GameObject tilePrefab;

    public int numLinhas;
    public int numColunas;

    public GameObject[,] tabuleiro;

    void Awake()
    {
        GenerateNewBoard();
    }

    void GenerateNewBoard()
    {
        tabuleiro = new GameObject[numLinhas, numColunas];

        GameObject tileClone;
        TileScript tileScript;
        SpriteRenderer tileSprite;

        for (int coluna = 0; coluna < numColunas; coluna++)
        {
            for (int linha = 0; linha < numLinhas; linha++)
            {
                tileClone = Instantiate(tilePrefab, this.transform.position + new Vector3(coluna * 0.15f, linha * 0.15f, 0), Quaternion.identity);
                tileClone.transform.SetParent(this.transform);

                tileScript = tileClone.GetComponent<TileScript>();
                tileScript.SetPosition(linha, coluna);

                tileSprite = tileClone.GetComponent<SpriteRenderer>();

                if (Random.Range(0, 100) <= 75)
                {
                    tileScript.andavel = true;
                    tileSprite.enabled = true;
                }
                else
                {
                    tileScript.andavel = false;
                    tileSprite.enabled = false;
                }
                tabuleiro[linha, coluna] = tileClone;

                tileScript.SetText();
            }
        }
    }
}
