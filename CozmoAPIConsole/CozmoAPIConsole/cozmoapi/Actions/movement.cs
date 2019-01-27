using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cozmoapi.Actions
{
    public static class movement
    {
        public static Anki.Cozmo.Action SetLiftHeight(Anki.Cozmo.SdkConnection connection, float percent)
        {
            // lift: (32 mm is the minimum height, 92 mm is the maximum height)
            float height_mm = 32.0f + percent * 60.0f;

            Anki.Cozmo.ExternalInterface.SetLiftHeight message = new Anki.Cozmo.ExternalInterface.SetLiftHeight(height_mm: height_mm, max_speed_rad_per_sec: 10.0f, accel_rad_per_sec2: 10.0f, duration_sec: 2.0f);

            return connection.SendAction(message);
        }
    }
}
