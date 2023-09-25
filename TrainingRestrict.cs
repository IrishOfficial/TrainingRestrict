using System;
using System.Collections.Generic;
using Oxide.Core.Libraries.Covalence;
using Oxide.Core.Plugins;
using UnityEngine;

namespace Oxide.Plugins
{
    [Info("Training Restrict", "Irish", "1.0.0")]
	[Description("Prevents looting of items and players by trial admins")]
    class TrainingRestrict : CovalencePlugin
    {
		
		private const string permissionName = "trainingrestrict.active";
		
		void Init()
		{
			permission.RegisterPermission(permissionName, this);
		}
		
        object OnItemPickup(Item item, BasePlayer player)
        {
            if (player.IsAdmin && permission.UserHasPermission(player.UserIDString, permissionName))
                return false;
            return null;
        }
        
        bool CanLootPlayer(BasePlayer target, BasePlayer looter)
		{
    		if (looter.IsAdmin && permission.UserHasPermission(looter.UserIDString, permissionName))
    			return false;
            return true;
		}

        object CanLootEntity(BasePlayer player, BaseEntity entity)
        {
            if (player.IsAdmin && permission.UserHasPermission(player.UserIDString, permissionName))
                return false;
            return null;
        }
        
	bool CanDropActiveItem(BasePlayer player)
	{
           if (player.IsAdmin && permission.UserHasPermission(player.UserIDString, permissionName))
               return false;
           return true;
	}
    }
}
