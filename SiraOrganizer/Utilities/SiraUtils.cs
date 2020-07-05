using System;

namespace SiraOrganizer.Utilities
{
    public static class SiraUtils
    {
        private static readonly string[] _greetings = new string[]
        {
            "Welcome back!",
            "TIME_JAPANESE",
            "TIME_ENGLISH",
            "Howdy!",
            "Oh, you're back.",
        };

        public static string GetRandomGreeting()
        {
            int ranNumber = App.Random.Next(0, _greetings.Length);
            string selGreeting = _greetings[ranNumber];
            if (selGreeting == "TIME_JAPANESE")
            {
                int hour = DateTime.Now.Hour;
                if (hour <= 12)
                {
                    return "おはようございます ! ! !";
                }
                if (hour <= 16)
                {
                    return "こんにちは";
                }
                return "おやすみなさい";
            }
            if (selGreeting == "TIME_ENGLISH")
            {
                int hour = DateTime.Now.Hour;
                if (hour <= 12)
                {
                    return "Good Morning!";
                }
                if (hour <= 16)
                {
                    return "Good Afternoon";
                }
                return "Good Evening";
            }
            return selGreeting;
        }
    }
}
