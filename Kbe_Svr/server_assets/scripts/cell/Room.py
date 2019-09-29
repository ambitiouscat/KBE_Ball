# -*- coding: utf-8 -*-
import KBEngine;
from KBEDebug import *;
import GameUtils;

class Room(KBEngine.Entity):
    def __init__(self):
        KBEngine.Entity.__init__(self);
        INFO_MSG("Cell Room init ...");
        pos = GameUtils.randomPosition3d();
        KBEngine.createEntity("Food",self.spaceID,pos)