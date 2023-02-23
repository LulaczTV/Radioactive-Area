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
        [Description("Loaded map name")]
        public string MapName { get; set; } = "MainMap";
        [Description("Should SCPs take damage?")]
        public bool SCPsDamage { get; set; } = false;
        [Description("How much damage player take per second. You can use float numbers ex. 1.5, 2.1")]
        public float Damage { get; set; } = 1.1f;

        public bool Scp049 { get; set; } = false;
        public bool Scp096 { get; set; } = false;
        public bool Scp106 { get; set; } = false;
        public bool Scp173 { get; set; } = false;
        public bool Scp939 { get; set; } = false;


    }
}
