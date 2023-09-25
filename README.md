# Features
- Permission based to only effect admins with the pemission active
- Restricts picking up items off the ground
- Restricts looting players
- Restricts looking crates, boxes, and containers
- Prevents admins active item from dropping into the world on death
- Config file to enable/disable desired features

# Introduction

The primary feature of this plugin is to help restrict access to items in game newer staff members while they are being trained and building trust. You can also use this if you would like your staff to never be able to have access to these abilities depending on your internal policies.

# Permission

- ```trainingrestrict.active``` -- Activates the protections for that user/group and disables their ability to interact with the protected entities.

# Configuration
Default configuration:

```json
{
  "DisableDroppingActiveItemByAdmins": true,
  "DisableItemPickupByAdmins": true,
  "DisableLootingEntitiesByAdmins": true,
  "DisableLootingPlayersByAdmins": true
}
```
