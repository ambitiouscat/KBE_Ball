/*
	Generated by KBEngine!
	Please do not modify this file!
	
	tools = kbcmd
*/

#pragma once

#include "KBECommon.h"
#include "EntityCall.h"
#include "KBETypes.h"
#include "CustomDataTypes.h"


// defined in */scripts/entity_defs/Food.def

namespace KBEngine
{

class KBENGINEPLUGINS_API EntityBaseEntityCall_FoodBase : public EntityCall
{
public:

	EntityBaseEntityCall_FoodBase(int32 eid, const FString& ename);

	virtual ~EntityBaseEntityCall_FoodBase();
};

class KBENGINEPLUGINS_API EntityCellEntityCall_FoodBase : public EntityCall
{
public:

	EntityCellEntityCall_FoodBase(int32 eid, const FString& ename);

	virtual ~EntityCellEntityCall_FoodBase();
};

}