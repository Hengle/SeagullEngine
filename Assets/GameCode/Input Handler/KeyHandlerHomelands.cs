﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyHandlerHomelands : IKeyHandler
{
    HomelandsGame _game;
    public KeyHandlerHomelands(HomelandsGame game)
    {
        _game = game;
    }
    public bool HandleKeys(KeyHandlerInfo keyHandlerInfo)
    {
        Dictionary<KeyCode, KeyCodeInfo> keys = keyHandlerInfo._keysInterfaced;

        if (keys.ContainsKey(KeyCode.Space))
        {
            KeyCodeInfo kci = keys[KeyCode.Space];
            Dictionary<eInput,bool> inputs = kci._keyCodeInfo;
            if (inputs[eInput.Up])
            {
                _game._viewer.ToggleNextView();
            }
        }

        return false;
    }
}
