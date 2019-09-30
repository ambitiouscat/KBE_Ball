# -*- coding: utf-8 -*-
import KBEngine;
from KBEDebug import *;
# 速度增加量
ADD_SPEED = 0.1
#   吃到食物减速度
SUB_SPEED = 0.2
#   Min speed
MIN_SPEED = 0.5
MAX_SPEED = 1.5

AVATAR_CRESH = 1; #碰撞体积
TIMER_CHECK_AVATAR_SPEED = 1;


class Avatar(KBEngine.Entity):
    def __init__(self):
        KBEngine.Entity.__init__(self);
        INFO_MSG("Cell Avatar init ...");

    def onGetWitness(self):
        DEBUG_MSG("Cell::Avatar::onGetWitness");
        self.addProximity(AVATAR_CRESH, 0, 0);

    def onEnterTrap(self,entityEntering,range_xz,range_y,controllerID,userarg):
        DEBUG_MSG("Cell::Avatar::onEnterTrap ...");
        if entityEntering.className == "Food":
            entityEntering.destroy();
            self.EnergyChange(1);
            if self.MoveSpeed > MIN_SPEED:
                self.MoveSpeed -= SUB_SPEED;
                self.IsRun = True;

    def onLeaveTrap(self,entityLeaving,range_xz,range_y,controllerID,userarg):
        pass;

    def EnergyChange(self,Change):
        self.GatherEnergy += Change;

    def SetRun(self,value):
        self.IsRun = value;
        self.CheckAvatarSpeed();

    def ChangeSpeed(self,Offset):
        if self.MoveSpeed + Offset > MAX_SPEED or self.MoveSpeed + Offset < MIN_SPEED:
            return ;
        self.MoveSpeed += Offset;

    def CheckAvatarSpeed(self):
        if self.IsRun:
            if self.MoveSpeed < MIN_SPEED:
                self.MoveSpeed = 0.0;
                self.ChangeSpeed(MIN_SPEED);
            else:
                self.ChangeSpeed(ADD_SPEED);
            self.addTimer(0.1,0,TIMER_CHECK_AVATAR_SPEED);
            INFO_MSG("add_timer TIMER_CHECK_AVATAR_SPEED = %i" % (TIMER_CHECK_AVATAR_SPEED));
            #self.MoveSpeed = 0.0;
        else:
            self.MoveSpeed = 0.0;

    def onTimer(self, tid, userArg):
        if userArg == TIMER_CHECK_AVATAR_SPEED:
            INFO_MSG("Enter Timer Process Timer Param = %i" % (TIMER_CHECK_AVATAR_SPEED));
            self.CheckAvatarSpeed();