﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ePlayerSystem { TurnBased}

public interface IPlayerSystem
{
    Player GetPlayer();
    List<Player> GetPlayers();
    void AddPlayer();
    void ChangePlayer();
}

public static class PlayerSystemFactory
{
    public static IPlayerSystem Make(ePlayerSystem type, HomelandsGame game, int numPlayers)
    {
        if (type == ePlayerSystem.TurnBased)
        {
            return new PlayerSystemTurnBased(game, numPlayers);
        }
        else
        {
            throw new System.NotImplementedException();
        }
    }
}