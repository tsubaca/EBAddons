using EloBuddy;
using EloBuddy.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lux
{
    static class Extensions
    {

        public static bool Valid(this Obj_AI_Base target, float range = 1000)
        {
            return target != null && target.IsValidTarget(range);
        }

    }
}
