#include "EntityCallFoodBase.h"
#include "Bundle.h"

namespace KBEngine
{

EntityBaseEntityCall_FoodBase::EntityBaseEntityCall_FoodBase(int32 eid, const FString& ename) : EntityCall(eid, ename)
{
	type = ENTITYCALL_TYPE_BASE;
}

EntityBaseEntityCall_FoodBase::~EntityBaseEntityCall_FoodBase()
{
}



EntityCellEntityCall_FoodBase::EntityCellEntityCall_FoodBase(int32 eid, const FString& ename) : EntityCall(eid, ename)
{
	type = ENTITYCALL_TYPE_CELL;
}

EntityCellEntityCall_FoodBase::~EntityCellEntityCall_FoodBase()
{
}


}