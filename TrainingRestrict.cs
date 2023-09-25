using System;
using System.Collections.Generic;
using Oxide.Core.Libraries.Covalence;
using Oxide.Core.Plugins;
using UnityEngine;

namespace Oxide.Plugins
{
    [Info("Training Restrict", "Irish", "1.0.1")]
	[Description("Prevents looting of items and players by trial admins")]
    class TrainingRestrict : CovalencePlugin
    {
		
	private const string permissionName = "trainingrestrict.active";
        private TrainingRestrictConfig config;
		
	void Init()
		{
			permission.RegisterPermission(permissionName, this);
            LoadConfig();
		}

        void LoadConfig()
        {
            try
            {
                config = Config.ReadObject<TrainingRestrictConfig>();
                if (config == null)
                {
                    LoadDefaultConfig();
                }
            }
            catch
            {
                LoadDefaultConfig();
            }
        }

        void LoadDefaultConfig()
        {
            config = new TrainingRestrictConfig
            {
                DisableItemPickupByAdmins = true,
                DisableLootingPlayersByAdmins = true,
                DisableLootingEntitiesByAdmins = true,
                DisableDroppingActiveItemByAdmins = true,
            };

            SaveConfig();
        }

        void SaveConfig()
        {
            Config.WriteObject(config, true);
        }

        class TrainingRestrictConfig
    {
       	public bool DisableItemPickupByAdmins { get; set; }
        public bool DisableLootingPlayersByAdmins { get; set; }
        public bool DisableLootingEntitiesByAdmins { get; set; }
        public bool DisableDroppingActiveItemByAdmins { get; set; }
    }
		
        object OnItemPickup(Item item, BasePlayer player)
        {
            if (config.DisableItemPickupByAdmins && player.IsAdmin && permission.UserHasPermission(player.UserIDString, permissionName))
                return false;
            return null;
        }

        bool CanLootPlayer(BasePlayer target, BasePlayer looter)
        {
            if (config.DisableLootingPlayersByAdmins && looter.IsAdmin && permission.UserHasPermission(looter.UserIDString, permissionName))
                return false;
            return true;
        }

        object CanLootEntity(BasePlayer player, BaseEntity entity)
        {
            if (config.DisableLootingEntitiesByAdmins && player.IsAdmin && permission.UserHasPermission(player.UserIDString, permissionName))
                return false;
            return null;
        }

        bool CanDropActiveItem(BasePlayer player)
        {
            if (config.DisableDroppingActiveItemByAdmins && player.IsAdmin && permission.UserHasPermission(player.UserIDString, permissionName))
                return false;
            return true;
        }
    }
}
