using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour 
{
    [SerializeField]
    private Vector2 GridXY;
    [SerializeField]
    private Vector2 Distance;
    [SerializeField]
    private Vector2 GridElementSize;

    [SerializeField]
    private GameObject GridSprite;

    [SerializeField]
    private Transform GridHolderTransform;

    [SerializeField]
    private GameObject[,] Grid;

    [SerializeField]
    private int numberOfMines;


	// Use this for initialization
	void Start ()
    {
        if (Grid == null)
        {
            CreateGrid();
        }
        //Reset();
    }

    //private void Reset()
    //{
    //    for (int i = 0; i < )
    //}

    private void CreateGrid()
    {
        Grid = new GameObject[(int)GridXY.x, (int)GridXY.y];

        Vector2 nextPosition = Vector3.zero;
        for (int i = 0; i < GridXY.x; i++)
        {
            for (int j = 0; j < GridXY.y; j++)
            {
                GameObject gridElement = (GameObject)Instantiate(GridSprite, nextPosition, Quaternion.identity);
                gridElement.name = "" + i + "," + j;
                gridElement.transform.SetParent(GridHolderTransform);
                Grid[i, j] = gridElement;
                nextPosition.y += Distance.y;
            }
            nextPosition.y = 0;
            nextPosition.x += Distance.x;
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Debug.Log("mouse clicked");
            GetGridElementClicked(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    void GetGridElementClicked(Vector2 mousePosition)
    {
        //Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
        //Debug.Log("mouse position = "+mousePosition.x +" , "+mousePosition.y);
        for (int i = 0; i < GridXY.x; i++)
        {
            for (int j = 0; j < GridXY.y; j++)
            {
                if((Grid[i, j].transform.position.x + GridElementSize.x > mousePosition.x && Grid[i, j].transform.position.x - GridElementSize.x < mousePosition.x))
                {
                    if((Grid[i, j].transform.position.y + GridElementSize.y > mousePosition.y && Grid[i, j].transform.position.y - GridElementSize.y < mousePosition.y))
                    {
                        Debug.Log("clicked on "+Grid[i,j].name);
                        break;
                    }
                }
            }
        }
    }
}
