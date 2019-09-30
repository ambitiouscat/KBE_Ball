#include "AvatarBase.h"
#include "KBVar.h"
#include "EntityDef.h"
#include "ScriptModule.h"
#include "Property.h"
#include "Method.h"
#include "DataTypes.h"
#include "CustomDataTypes.h"
#include "MemoryStream.h"
#include "EntityComponent.h"

namespace KBEngine
{



void AvatarBase::onComponentsEnterworld()
{
}

void AvatarBase::onComponentsLeaveworld()
{
}

void AvatarBase::onGetBase()
{
	if(pBaseEntityCall)
		delete pBaseEntityCall;

	pBaseEntityCall = new EntityBaseEntityCall_AvatarBase(id(), className());
}

void AvatarBase::onGetCell()
{
	if(pCellEntityCall)
		delete pCellEntityCall;

	pCellEntityCall = new EntityCellEntityCall_AvatarBase(id(), className());
}

void AvatarBase::onLoseCell()
{
	delete pCellEntityCall;
	pCellEntityCall = NULL;
}

EntityCall* AvatarBase::getBaseEntityCall()
{
	return pBaseEntityCall;
}

EntityCall* AvatarBase::getCellEntityCall()
{
	return pCellEntityCall;
}

void AvatarBase::onRemoteMethodCall(MemoryStream& stream)
{
}

void AvatarBase::onUpdatePropertys(MemoryStream& stream)
{
	ScriptModule* sm = *EntityDef::moduledefs.Find("Avatar");

	while(stream.length() > 0)
	{
		uint16 componentPropertyUType = 0;
		uint16 properUtype = 0;

		if (sm->usePropertyDescrAlias)
		{
			componentPropertyUType = stream.readUint8();
			properUtype = stream.read<uint8>();
		}
		else
		{
			componentPropertyUType = stream.readUint16();
			properUtype = stream.read<uint16>();
		}

		if(componentPropertyUType > 0)
		{
			KBE_ASSERT(false);

			return;
		}

		Property* pProp = sm->idpropertys[properUtype];

		switch(pProp->properUtype)
		{
			case 2:
			{
				uint32 oldval_GatherEnergy = GatherEnergy;
				GatherEnergy = stream.readUint32();

				if(pProp->isBase())
				{
					if(inited())
						onGatherEnergyChanged(oldval_GatherEnergy);
				}
				else
				{
					if(inWorld())
						onGatherEnergyChanged(oldval_GatherEnergy);
				}

				break;
			}
			case 1:
			{
				float oldval_MoveSpeed = MoveSpeed;
				MoveSpeed = stream.readFloat();

				if(pProp->isBase())
				{
					if(inited())
						onMoveSpeedChanged(oldval_MoveSpeed);
				}
				else
				{
					if(inWorld())
						onMoveSpeedChanged(oldval_MoveSpeed);
				}

				break;
			}
			case 40001:
			{
				FVector oldval_direction = direction;
				direction = stream.readVector3();

				if(pProp->isBase())
				{
					if(inited())
						onDirectionChanged(oldval_direction);
				}
				else
				{
					if(inWorld())
						onDirectionChanged(oldval_direction);
				}

				break;
			}
			case 40000:
			{
				FVector oldval_position = position;
				position = stream.readVector3();

				if(pProp->isBase())
				{
					if(inited())
						onPositionChanged(oldval_position);
				}
				else
				{
					if(inWorld())
						onPositionChanged(oldval_position);
				}

				break;
			}
			case 40002:
			{
				stream.readUint32();
				break;
			}
			default:
				break;
		};
	}
}

void AvatarBase::callPropertysSetMethods()
{
	ScriptModule* sm = EntityDef::moduledefs["Avatar"];
	TMap<uint16, Property*>& pdatas = sm->idpropertys;

	uint32 oldval_GatherEnergy = GatherEnergy;
	Property* pProp_GatherEnergy = pdatas[4];
	if(pProp_GatherEnergy->isBase())
	{
		if(inited() && !inWorld())
			onGatherEnergyChanged(oldval_GatherEnergy);
	}
	else
	{
		if(inWorld())
		{
			if(pProp_GatherEnergy->isOwnerOnly() && !isPlayer())
			{
			}
			else
			{
				onGatherEnergyChanged(oldval_GatherEnergy);
			}
		}
	}

	float oldval_MoveSpeed = MoveSpeed;
	Property* pProp_MoveSpeed = pdatas[5];
	if(pProp_MoveSpeed->isBase())
	{
		if(inited() && !inWorld())
			onMoveSpeedChanged(oldval_MoveSpeed);
	}
	else
	{
		if(inWorld())
		{
			if(pProp_MoveSpeed->isOwnerOnly() && !isPlayer())
			{
			}
			else
			{
				onMoveSpeedChanged(oldval_MoveSpeed);
			}
		}
	}

	FVector oldval_direction = direction;
	Property* pProp_direction = pdatas[2];
	if(pProp_direction->isBase())
	{
		if(inited() && !inWorld())
			onDirectionChanged(oldval_direction);
	}
	else
	{
		if(inWorld())
		{
			if(pProp_direction->isOwnerOnly() && !isPlayer())
			{
			}
			else
			{
				onDirectionChanged(oldval_direction);
			}
		}
	}

	FVector oldval_position = position;
	Property* pProp_position = pdatas[1];
	if(pProp_position->isBase())
	{
		if(inited() && !inWorld())
			onPositionChanged(oldval_position);
	}
	else
	{
		if(inWorld())
		{
			if(pProp_position->isOwnerOnly() && !isPlayer())
			{
			}
			else
			{
				onPositionChanged(oldval_position);
			}
		}
	}

}

AvatarBase::AvatarBase():
	Entity(),
	pBaseEntityCall(NULL),
	pCellEntityCall(NULL),
	GatherEnergy((uint32)FCString::Atoi64(TEXT("0"))),
	MoveSpeed(FCString::Atof(TEXT("1")))
{
}

AvatarBase::~AvatarBase()
{
	if(pBaseEntityCall)
		delete pBaseEntityCall;

	if(pCellEntityCall)
		delete pCellEntityCall;

}

void AvatarBase::attachComponents()
{
}

void AvatarBase::detachComponents()
{
}

}