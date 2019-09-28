using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;

public class Avatar : Entity {

    public override void __init__()
    {
        base.__init__();
        Debug.Log("Avatar Init ....");
    }

    public override void onEnterSpace()
    {
        base.onEnterSpace();
        Debug.Log("Avatar onEnterSpace ....");
    }

    public override void onEnterWorld()
    {
        base.onEnterWorld();
        Debug.Log("Avatar onEnterWorld ....");
    }
}
