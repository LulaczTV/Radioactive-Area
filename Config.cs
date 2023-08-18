using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Interfaces;
using Exiled.API.Enums;

namespace Radioactive_Area
{
    public sealed class Config : IConfig
    {
        [Description("does nothing")]
        public bool Debug { get; set; } = false;
        public bool IsEnabled { get; set; } = true;

        [Description("Rooms that will be contaminated")]
        public List<RoomType> RoomTypes { get; set; } = new List<RoomType>();
        [Description("Roles that won't be affected by radiation")]
        public List<PlayerRoles.RoleTypeId> Roles { get; set; } = new List<PlayerRoles.RoleTypeId>()
        {
            PlayerRoles.RoleTypeId.Scp173,
        };
        [Description("Loaded map name")]
        public string MapName { get; set; } = "MainMap";
        [Description("How much damage player take per second. You can use float numbers ex. 1.5, 2.1")]
        public float Damage { get; set; } = 1.1f;
    }
}
