# -*- coding: utf-8 -*-
import KBEngine;
from KBEDebug import *;

class Avatar(KBEngine.Proxy):
    def __init__(self):
        KBEngine.Proxy.__init__(self);
        INFO_MSG("Base Avatar init ...");


    def onClientEnabled(self):
        INFO_MSG("Base::Avatar::onClientEnabled ...");
        KBEngine.globalData["Room"].enterRoom(self,None,None);


    def createCell(self,RoomCellCall):
        INFO_MSG("Base::Avatar::createCell ...");
        self.createCellEntity(RoomCellCall);