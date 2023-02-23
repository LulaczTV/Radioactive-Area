using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.Events.EventArgs.Server;
using Exiled.API.Enums;
using Exiled.API.Features;
using MapEditorReborn.Events.EventArgs;
using MEC;
using System.Collections;

///You know for who
//if (MapEditorReborn.API.API.CurrentLoadedMap.Name != null)
//{
//    if (MapEditorReborn.API.API.CurrentLoadedMap.Name.Equals(Plugin.Instance.Config.MapName))
//    {
//        cor = Timing.RunCoroutine(RoomsArea());
//    }
//}
namespace Radioactive_Area
{
    internal sealed class EventHandlers
    {
        CoroutineHandle cor;
        public void OnRoundStarted()
        {
            cor = Timing.RunCoroutine(RoomsArea());
        }
        public void OnRoundEnding(EndingRoundEventArgs ev)
        {
            Timing.KillCoroutines(cor);
        }
        public void OnRoundRestarting()
        {
            Timing.KillCoroutines(cor);
        }

        public IEnumerator<float> RoomsArea()
        {
            for(; ; )
            {
                yield return Timing.WaitForSeconds(1f);
                Radiation();
            }
        }

        public void Radiation()
        {
            foreach (Player player in Player.List)
            {
                foreach (RoomType roomType in Plugin.Instance.Config.RoomTypes)
                {
                    if (player.CurrentRoom.Type == roomType)
                    {
                        if (Plugin.Instance.Config.SCPsDamage && player.Role.Team == PlayerRoles.Team.SCPs)
                        {
                            player.EnableEffect(EffectType.Poisoned);
                            player.Hurt(Plugin.Instance.Config.Damage);
                        }

                        if (player.Role.Side == Side.Mtf || player.Role.Side == Side.ChaosInsurgency)
                        {
                            player.EnableEffect(EffectType.Poisoned);
                            player.Hurt(Plugin.Instance.Config.Damage);
                        }

                        if (Plugin.Instance.Config.Scp049 && player.Role.Type == PlayerRoles.RoleTypeId.Scp049)
                        {
                            player.EnableEffect(EffectType.Poisoned);
                            player.Hurt(Plugin.Instance.Config.Damage);
                        }
                        if (Plugin.Instance.Config.Scp096 && player.Role.Type == PlayerRoles.RoleTypeId.Scp096)
                        {
                            player.EnableEffect(EffectType.Poisoned);
                            player.Hurt(Plugin.Instance.Config.Damage);
                        }
                        if (Plugin.Instance.Config.Scp106 && player.Role.Type == PlayerRoles.RoleTypeId.Scp106)
                        {
                            player.EnableEffect(EffectType.Poisoned);
                            player.Hurt(Plugin.Instance.Config.Damage);
                        }
                        if (Plugin.Instance.Config.Scp173 && player.Role.Type == PlayerRoles.RoleTypeId.Scp173)
                        {
                            player.EnableEffect(EffectType.Poisoned);
                            player.Hurt(Plugin.Instance.Config.Damage);
                        }
                        if (Plugin.Instance.Config.Scp939 && player.Role.Type == PlayerRoles.RoleTypeId.Scp939)
                        {
                            player.EnableEffect(EffectType.Poisoned);
                            player.Hurt(Plugin.Instance.Config.Damage);
                        }
                    }
                    else
                    {
                        player.DisableEffect(EffectType.Poisoned);
                    }
                }
            }
        }
    }
}


