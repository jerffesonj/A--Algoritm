using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardController : MonoBehaviour
{
    public static BoardController instance;

    public int startX;
    public int startY;
    public int endX;
    public int endY;

    public int menorValor = 999999;
    

    public List<GameObject> listaAberta;
    public List<GameObject> listaFechada;

    public GameObject proxTile;
    public GameObject ultimoTile;

    public GenerateBoard board;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

    }

    private void Start()
    {
        startX = Random.Range(0, board.numLinhas);
        startY = Random.Range(0, board.numColunas);
        endX = Random.Range(0, board.numLinhas);
        endY = Random.Range(0, board.numColunas);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            CheckCasinha();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

    }

    void CheckCasinha()
    {
        listaAberta.Add(board.tabuleiro[startX, startY]);

        proxTile = board.tabuleiro[startX, startY];
        ultimoTile = board.tabuleiro[startX, startY];

        TileScript tile;

        for (int i = 0; i < board.numColunas * board.numColunas; i++)
        {
            if (proxTile.GetComponent<TileScript>().x == endX && proxTile.GetComponent<TileScript>().y == endY || listaAberta.Count<=0)
            {
                List<GameObject> teste = new List<GameObject>();
                GameObject tileTeste = proxTile.gameObject;

                for (int j = 0; j < board.numColunas * board.numColunas; j++)
                {
                    teste.Add(tileTeste);
                    if (tileTeste.GetComponent<TileScript>().ultimoTile != null)
                        tileTeste = tileTeste.GetComponent<TileScript>().ultimoTile.gameObject;

                }

                foreach (GameObject obj in teste)
                {
                    obj.GetComponent<SpriteRenderer>().color = Color.blue;
                }
                if (proxTile.GetComponent<TileScript>().x == endX && proxTile.GetComponent<TileScript>().y == endY)
                {
                    
                    print("Chegou ao destino");
                }
                if(listaAberta.Count <= 0)
                {
                    print("Sem saida");
                }
                break;
            }


            menorValor = 99999;

            for (int j = 0; j < listaAberta.Count; j++)
            {
                //if (listaAberta[j] != board.tabuleiro[startX, startY])
                {
                    if (listaAberta[j].GetComponent<TileScript>().fCost <= menorValor)
                    {
                        menorValor = listaAberta[j].GetComponent<TileScript>().fCost;
                        proxTile = listaAberta[j];
                        listaAberta.Remove(listaAberta[j]);
                    }
                }
            }

            if (proxTile.GetComponent<TileScript>().x + 1 < board.numLinhas)
            {
                tile = board.tabuleiro[proxTile.GetComponent<TileScript>().x + 1, proxTile.GetComponent<TileScript>().y].GetComponent<TileScript>();
                if (tile.andavel)
                {
                    if (!listaFechada.Contains(tile.gameObject))
                    {
                        if (!listaAberta.Contains(tile.gameObject))
                        {
                            tile.gCost = 10;
                            tile.hCost = 10 * ((Mathf.Abs(startX + i - endX)) + Mathf.Abs((startY - endY)));
                            tile.CalculateFCost();

                            tile.ultimoTile = proxTile.GetComponent<TileScript>();

                            listaAberta.Add(tile.gameObject);
                            print("entrou cima");
                            tile.GoingCheckTile();
                        }
                    }
                }
            }
            if (proxTile.GetComponent<TileScript>().x - 1 >= 0)
            {
                tile = board.tabuleiro[proxTile.GetComponent<TileScript>().x - 1, proxTile.GetComponent<TileScript>().y].GetComponent<TileScript>();
                if (tile.andavel)
                {
                    if (!listaFechada.Contains(tile.gameObject))
                    {
                        if (!listaAberta.Contains(tile.gameObject))
                        {
                            tile.gCost = 10;
                            tile.hCost = 10 * ((Mathf.Abs(startX - i - endX)) + Mathf.Abs((startY - endY)));
                            tile.CalculateFCost();
                            tile.ultimoTile = proxTile.GetComponent<TileScript>();

                            listaAberta.Add(tile.gameObject);
                            print("entrou baixo");
                            tile.GoingCheckTile();
                        }
                    }
                }
            }
            if (proxTile.GetComponent<TileScript>().y + 1 < board.numColunas)
            {
                tile = board.tabuleiro[proxTile.GetComponent<TileScript>().x, proxTile.GetComponent<TileScript>().y + 1].GetComponent<TileScript>();
                if (tile.andavel)
                {
                    if (!listaFechada.Contains(tile.gameObject))
                    {
                        if (!listaAberta.Contains(tile.gameObject))
                        {
                            tile.gCost = 10;
                            tile.hCost = 10 * ((Mathf.Abs(startX - endX)) + Mathf.Abs((startY + i - endY)));
                            tile.CalculateFCost();
                            tile.ultimoTile = proxTile.GetComponent<TileScript>();

                            listaAberta.Add(tile.gameObject);
                            print("entrou direita");
                            tile.GoingCheckTile();

                        }
                    }
                }
            }
            if (proxTile.GetComponent<TileScript>().y - 1 >= 0)
            {
                tile = board.tabuleiro[proxTile.GetComponent<TileScript>().x, proxTile.GetComponent<TileScript>().y - 1].GetComponent<TileScript>();
                if (tile.andavel)
                {
                    if (!listaFechada.Contains(tile.gameObject))
                    {
                        if (!listaAberta.Contains(tile.gameObject))
                        {
                            tile.gCost = 10;
                            tile.hCost = 10 * ((Mathf.Abs(startX - endX)) + Mathf.Abs((startY - i - endY)));
                            tile.CalculateFCost();

                            tile.ultimoTile = proxTile.GetComponent<TileScript>();

                            listaAberta.Add(tile.gameObject);
                            print("entrou esquerda");
                            tile.GoingCheckTile();
                        }
                    }
                }
            }

            print(ultimoTile.GetComponent<TileScript>().x + "    " + ultimoTile.GetComponent<TileScript>().y);
            listaFechada.Add(proxTile);
            proxTile.GetComponent<TileScript>().CheckedTile();
        }



    }
}
