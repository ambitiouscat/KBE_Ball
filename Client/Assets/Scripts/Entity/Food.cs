using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;
public class Food : FoodBase {

    public override void __init__()
    {
        base.__init__();
        Debug.Log("Food Init ....");
    }

    public override void onEnterWorld()
    {
        base.onEnterWorld();
        KBEngine.Event.fireOut("onOtherAvatarEnterWorld", this);
    }

    public override void onLeaveWorld()
    {
        base.onLeaveWorld();
        KBEngine.Event.fireOut("onLeaveWorld",this);
        Debug.Log("Food::onLeaveWorld ... className = " + className + id);
    }

    public override void onDestroy()
    {
        base.onDestroy();
        Debug.Log("Food::onDestroy ... className = " + className + id);
    }
}
