using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;

public class Avatar : AvatarBase {

    public void RegisterEvent()
    {
        if (isPlayer())
            KBEngine.Event.registerIn("updatePlayer", this, "updatePlayer");
    }

    public override void __init__()
    {
        base.__init__();
        RegisterEvent();
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
        Debug.Log("Avatar onEnterWorld .... isPlayer() = " + isPlayer() + this.id);
        if (isPlayer())
        {
            KBEngine.Event.fireOut("onSelfAvatarEnterWorld",this);
        }
        else
        {
            KBEngine.Event.fireOut("onOtherAvatarEnterWorld", this);
        }
    }

    public override void onMoveSpeedChanged(float oldValue)
    {
        base.onMoveSpeedChanged(oldValue);
        KBEngine.Event.fireOut("onMoveSpeedChanged",this);
    }

    public virtual void updatePlayer(float x,float y, float z, float yaw)
    {
        position.x = x;
        position.y = y;
        position.z = z;

        direction.z = yaw;
    }
}
