using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode {

    private GridScheme<PathNode> grid;
    public int x;
    public int y;
    public int gCost;
    public int hCost;
    public int fCost;
    public PathNode previousNode;

    public bool isWalkable;
    public PathNode(GridScheme<PathNode> grid, int x, int y) {
        this.grid = grid;
        this.x = x;
        this.y = y;
        this.isWalkable = true;
    }

    public void calculateFCost() {
        fCost = gCost + hCost;
    }

    public void setIsWalkable(bool isWalkable) {
        this.isWalkable = isWalkable;
    }

    public override string ToString() {
        return x + "," + y;
    }
}
