using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScheme {
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private int [,] gridArray;

    private TextMesh[,] debugTextArray;

    public GridScheme(int width, int height, float cellSize, Vector3 originPosition) {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;
        this.gridArray = new int [width, height];
        this.debugTextArray = new TextMesh[width, height];


        for (int x = 0; x < gridArray.GetLength(0); x++) {
            for (int y = 0; y < gridArray.GetLength(1); y++) {
                this.debugTextArray[x, y] = Utils.createWorldText(gridArray[x, y].ToString(), null, getWorldPosition(x, y) + new Vector3(cellSize, cellSize) * 0.5f, 20, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(getWorldPosition(x, y), getWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(getWorldPosition(x, y), getWorldPosition(x + 1, y), Color.white, 100f);
            }
        }
        Debug.DrawLine(getWorldPosition(0, height), getWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(getWorldPosition(width, 0), getWorldPosition(width, height), Color.white, 100f);


        setValue(1, 1, 42);
    }

    private Vector3 getWorldPosition(int x, int y) {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    private void getCoordinates(Vector3 worldPosition, out int x, out int y) {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }

    public void setValue(int x, int y, int value) {
        if (x >= 0 && y >= 0 && x < width && y < height) {
            gridArray[x, y] = value;
            this.debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
    }

    public int getValue(int x, int y) {
        if (x >= 0 && y >= 0 && x < width && y < height) {
            return gridArray[x, y];
        } else {
            return -1;
        }
    }

    public int getValue(Vector3 worldPosition) {
        int x, y;
        getCoordinates(worldPosition, out x, out y);
        return getValue(x, y);
    }
    
}
