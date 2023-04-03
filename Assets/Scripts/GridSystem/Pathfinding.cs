using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding {

    private const int MOVE_STRAIGHT_COST = 10;
    private const int MOVE_DIAGONAL_COST = 14;

    private GridScheme<PathNode> grid;
    private List<PathNode> openList;
    private List<PathNode> closedList;
    public Pathfinding(int width, int height) {
        grid = new GridScheme<PathNode>(width, height, 1f, Vector3.zero, (GridScheme<PathNode> g, int x, int y) => new PathNode(g, x, y));
    }

    public GridScheme<PathNode> getGrid() {
        return grid;
    }

    /**
        Finds the path between 2 nodes, given the start position and the end position.
        Basically it implements the A* algorithm
    */
    public List<PathNode> findPath(int startX, int startY, int endX, int endY) {
        PathNode startNode = grid.getValue(startX, startY);
        PathNode endNode = grid.getValue(endX, endY);

        openList = new List<PathNode>() { startNode };
        closedList = new List<PathNode>();

        for (int x = 0; x < grid.getWidth(); x++) {
            for (int y = 0; y < grid.getHeight(); y++) {
                PathNode pathNode = grid.getValue(x, y);
                pathNode.gCost = int.MaxValue;
                pathNode.calculateFCost();
                pathNode.previousNode = null;
            }
        }

        startNode.gCost = 0;
        startNode.hCost = calculateDistanceCost(startNode, endNode);
        startNode.calculateFCost();

        while (openList.Count > 0) {
            PathNode currentNode = getLowestFCostNode(openList);

            if (currentNode == endNode) {
                return calculatePath(endNode);
            }

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            foreach (PathNode neighbourNode in getNeighbourList(currentNode)) {
                if (closedList.Contains(neighbourNode)) {
                    continue;
                }

                int tentativeGCost = currentNode.gCost + calculateDistanceCost(currentNode, neighbourNode);
                if (tentativeGCost < neighbourNode.gCost) {
                    neighbourNode.previousNode = currentNode;
                    neighbourNode.gCost = tentativeGCost;
                    neighbourNode.hCost = calculateDistanceCost(neighbourNode, endNode);
                    neighbourNode.calculateFCost();

                    if (!openList.Contains(neighbourNode)) {
                        openList.Add(neighbourNode);
                    }
                }
            }
        }
        return null;
    }

    /**
        Calculates the cost of the distance between 2 nodes
    */
    private int calculateDistanceCost(PathNode firstNode, PathNode secondNode) {
        int xDistance = Mathf.Abs(firstNode.x - secondNode.x);
        int yDistance = Mathf.Abs(firstNode.y - secondNode.y);
        int remaining = Mathf.Abs(xDistance - yDistance);
        return MOVE_DIAGONAL_COST * Mathf.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaining;
    }

    /**
        Searches for the lowest final cost, given a list of nodes
    */
    private PathNode getLowestFCostNode(List<PathNode> pathNodeList) {
        PathNode lowestFCostNode = pathNodeList[0];
        for (int i = 1; i < pathNodeList.Count; i++) {
            if (pathNodeList[i].fCost < lowestFCostNode.fCost) {
                lowestFCostNode = pathNodeList[i];
            }
        }
        return lowestFCostNode;
    }

    /**
        Returns all the neighbours of a given node
    */
    private List<PathNode> getNeighbourList(PathNode currentNode) {
        List<PathNode> neighbourList = new List<PathNode>();

        if (currentNode.x - 1 >= 0) {
            // going left
            neighbourList.Add(getNode(currentNode.x - 1, currentNode.y));

            // going left down
            if (currentNode.y - 1 >= 0) {
                neighbourList.Add(getNode(currentNode.x - 1, currentNode.y - 1));
            }

            // going left up
            if (currentNode.y + 1 < grid.getHeight()) {
                neighbourList.Add(getNode(currentNode.x - 1, currentNode.y + 1));
            }
        }

        if (currentNode.x + 1 < grid.getWidth()) {
            // going right
            neighbourList.Add(getNode(currentNode.x + 1, currentNode.y));

            // going right down
            if (currentNode.y - 1 >= 0) {
                neighbourList.Add(getNode(currentNode.x + 1, currentNode.y - 1));
            }

            // going right up
            if (currentNode.y + 1 < grid.getHeight()) {
                neighbourList.Add(getNode(currentNode.x + 1, currentNode.y + 1));
            }
        }

        // going down
        if (currentNode.y - 1 >= 0) {
            neighbourList.Add(getNode(currentNode.x, currentNode.y - 1));
        }

        // going up
        if (currentNode.y + 1 < grid.getHeight()) {
            neighbourList.Add(getNode(currentNode.x, currentNode.y + 1));
        }

        return neighbourList;
    }

    /**
        Returns the PathNode object, given the x and y coordinates of the grid
    */
    private PathNode getNode(int x, int y) {
        return grid.getValue(x, y);
    }

    /**
        Builds the path from the endNode, using the parent node.
        The last node's parent is null
    */
    private List<PathNode> calculatePath(PathNode endNode) {
        List<PathNode> path = new List<PathNode>();
        path.Add(endNode);
        PathNode currentNode = endNode;
        while (currentNode.previousNode != null) {
            path.Add(currentNode.previousNode);
            currentNode = currentNode.previousNode;
        }

        path.Reverse();
        return path;
    }
}
