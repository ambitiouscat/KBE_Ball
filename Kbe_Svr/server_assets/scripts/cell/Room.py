# -*- coding: utf-8 -*-
import KBEngine;
from KBEDebug import *;
import GameUtils;

MAX_FOOD_CNT = 100

class Room(KBEngine.Entity):
    def __init__(self):
        KBEngine.Entity.__init__(self);
        INFO_MSG("Cell Room init ...");
        KBEngine.globalData["CellRoom"] = self;
        for i in range(MAX_FOOD_CNT):
            self.RefreshFood();

    def RefreshFood(self):
        pos = GameUtils.randomPosition3D();
        KBEngine.createEntity("Food", self.spaceID, pos, (0.0, 0.0, 0.0), {});