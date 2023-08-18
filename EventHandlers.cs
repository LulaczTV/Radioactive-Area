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

///some shitty test with MER
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
                        foreach(PlayerRoles.RoleTypeId roleType in Plugin.Instance.Config.Roles)
                        {
                            return;
                        }

                        player.EnableEffect(EffectType.Poisoned);
                        player.Hurt(Plugin.Instance.Config.Damage);
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


