﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NeighborBuilderSquare : NeighborBuilder
{
    MapInfo mapInfo;
    public NeighborBuilderSquare(MapInfo mi)
    {
        mapInfo = mi;
    }
    public override void SetNeighbors(Pos p)
    {
        p._neighbors = new List<Pos>();
        float x = p._gridLoc.x();
        float y = p._gridLoc.y();
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i != 0 || j != 0)
                {
                    float X = mapInfo.wrapEW ? (mapInfo._settings._xDim + x + i) % mapInfo._settings._xDim : x + i;
                    float Y = mapInfo.wrapNS ? (mapInfo._settings._yDim + y + j) % mapInfo._settings._yDim : y + j;

                    Loc l2 = new Loc(X, Y);
                    if (mapInfo.pathMap.ContainsKey(l2.key()))
                    {
                        Pos potentialNeighbor = mapInfo.pathMap[l2.key()];
                        if (mapInfo.locations[p]._terrain._type == mapInfo.locations[potentialNeighbor]._terrain._type)
                        {
                            p._neighbors.Add(potentialNeighbor);
                        }
                    }
                }
            }
        }
    }
}
