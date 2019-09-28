# -*- coding: utf-8 -*-
import KBEngine;
from KBEDebug import *;

class Room(KBEngine.Entity):
    def __init__(self):
        KBEngine.Proxy.__init__(self);
        INFO_MSG("Base Room init ...");

        self.createCellEntityInNewSpace(None);
        KBEngine.globalData["Room"] = self;

    def enterRoom(self,AvatarBaseCall,Pos,Direction):
        INFO_MSG("Base::Room::enterRoom ...");
        AvatarBaseCall.createCell(self.cell);