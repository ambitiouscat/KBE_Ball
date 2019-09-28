/*
	Generated by KBEngine!
	Please do not modify this file!
	Please inherit this module, such as: (class Avatar : public AvatarBase)
	tools = kbcmd
*/

#pragma once
#include "KBECommon.h"
#include "Entity.h"
#include "KBETypes.h"
#include "EntityCallAvatarBase.h"

namespace KBEngine
{

class Method;
class Property;
class MemoryStream;

// defined in */scripts/entity_defs/Avatar.def
	// Please inherit and implement "class Avatar : public AvatarBase"
class KBENGINEPLUGINS_API AvatarBase : public Entity
{
public:
	EntityBaseEntityCall_AvatarBase* pBaseEntityCall;
	EntityCellEntityCall_AvatarBase* pCellEntityCall;



	void onComponentsEnterworld() override;
	void onComponentsLeaveworld() override;

	void onGetBase() override;
	void onGetCell() override;
	void onLoseCell() override;

	EntityCall* getBaseEntityCall() override;
	EntityCall* getCellEntityCall() override;


	void onRemoteMethodCall(MemoryStream& stream) override;
	void onUpdatePropertys(MemoryStream& stream) override;
	void callPropertysSetMethods() override;

	AvatarBase();
	virtual ~AvatarBase();

	void attachComponents() override;
	void detachComponents() override;

};

}