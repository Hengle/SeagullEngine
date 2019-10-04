﻿using UnityEngine;
using System.Collections.Generic;

public interface IMapBuilder 
{
    Dictionary<Pos, HomelandsLocation> Make(MapSettings mapSettings);
}

public enum eMap { Gaea, Basic };

public static class MapBuilderFactory
{
    public static IMapBuilder Make(eMap mapType, HomelandsGame game)
    {
        if (mapType == eMap.Gaea)
        {
            return new MapBuilderGaea(game);
        }
        else if (mapType == eMap.Basic)
        {
            return new MapBuilderBasic(game);
        }
        else
        {
            throw new System.NotImplementedException();
        }
    }
}
