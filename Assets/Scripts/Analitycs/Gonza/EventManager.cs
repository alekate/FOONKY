using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnalyticsEvent = Unity.Services.Analytics.Event;

public class EventManager : MonoBehaviour
{
    public class DamagedEvent : AnalyticsEvent
    {
		public DamagedEvent() : base("Damaged")
		{
		}

		public string enemy { set { SetParameter("enemy", value); } }
		public int safeSlain { set { SetParameter("safeSlain", value); } }
		public int level { set { SetParameter("level", value); } }
    }

	public class GameOverEvent : AnalyticsEvent
    {
		public GameOverEvent() : base("GameOver")
		{
		}

		public int level { set { SetParameter("level", value); } }
		public int deathsGO { set { SetParameter("deathsGO", value); } }
    }

public class LevelCompleteEvent : AnalyticsEvent
    {
		public LevelCompleteEvent() : base("LevelComplete")
		{
		}

		public int level { set { SetParameter("level", value); } }
		public int deaths { set { SetParameter("deaths", value); } }
		public int flusks { set { SetParameter("flusks", value); } }
		public int combo { set { SetParameter("combo", value); } }
		public bool safe { set { SetParameter("safe", value); } }
		public float time { set { SetParameter("time", value); } }
    }

	public class LevelStartEvent : AnalyticsEvent
    {
		public LevelStartEvent() : base("LevelStart")
		{
		}

		public int level { set { SetParameter("level", value); } }
    }

	public class PowerEvent : AnalyticsEvent
    {
		public PowerEvent() : base("Power")
		{
		}

		public int frenzy { set { SetParameter("frenzy", value); } }
		public float timeFrenzy { set { SetParameter("timeFrenzy", value); } }
    }
}