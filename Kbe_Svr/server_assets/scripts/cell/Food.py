# -*- coding: utf-8 -*-
import KBEngine;
from KBEDebug import *;

class Food(KBEngine.Entity):
    def __init__(self):
        KBEngine.Entity.__init__(self);
        INFO_MSG("Cell Food init ...");

    def onDestroy(self):
        INFO_MSG("Cell::Food::onDestroy ... name = %s id = %i " % (self.className,self.id))
        KBEngine.globalData["CellRoom"].RefreshFood();
