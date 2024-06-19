using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnalyticsEvent = Unity.Services.Analytics.Event;

public class EventManager : MonoBehaviour
{
    public class GameCompleteEvent : AnalyticsEvent
    {
		public GameCompleteEvent() : base("GameComplete")
		{
		}

		public float totalTime { set { SetParameter("totalTime", value);}}

    }

	public class LevelStartEvent : AnalyticsEvent
    {
		public LevelStartEvent() : base("LevelStart")
		{
		}

		public int userLevel { set { SetParameter("userLevel", value); } }
    }

	public class LevelEndEvent : AnalyticsEvent
    {
		public LevelEndEvent() : base("LevelEnd")
		{
		}

		public int userLevel { set { SetParameter("userLevel", value); } }
		public float levelTime { set { SetParameter("levelTime", value); } }
		public int levelGraffiti { set { SetParameter("levelGraffiti", value); } }
		public float levelTotal { set { SetParameter("levelTotal", value); } }

    }

	public class GameOverEvent : AnalyticsEvent
    {
		public GameOverEvent() : base("GameOver")
		{
		}

		public int userLevel { set { SetParameter("userLevel", value); } }
		public string enemyType { set { SetParameter("enemyType", value); } }
		public int deathCount { set { SetParameter("deathCount", value); } }
		public int deathFall { set { SetParameter("deathFall", value); } }
		public int deathEnemy { set { SetParameter("deathEnemy", value); } }
    }

	public class WeaponEvent : AnalyticsEvent
    {
		public WeaponEvent() : base("Weapon")
		{
		}

		public int pistolKill { set { SetParameter("pistolKill", value); } }
		public int shotgunKill { set { SetParameter("shotgunKill", value); } }
		public int rifleKill { set { SetParameter("rifleKill", value); } }
		public string weaponTotal { set { SetParameter("weaponTotal", value); } }
    }
}