﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;

public class Account : AccountBase
{
    public override void __init__()
    {
        base.__init__();
        Debug.Log("Account Init !!!");
        KBEngine.Event.fireOut("onLoginSuccess");
    }
}
