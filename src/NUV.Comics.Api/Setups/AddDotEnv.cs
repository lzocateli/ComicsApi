namespace Startup.Custom
{
    using System;
    using System.IO;

    public static class CustomDotEnv
    {
        public static void LoadDotEnv(string filePath)
        {
            if (filePath.StartsWith("%USERPROFILE%"))
            {
                var pathprofile = Environment.GetEnvironmentVariable("USERPROFILE");
                var pathenv = filePath.Replace("%USERPROFILE%", pathprofile);
                filePath = pathenv;
            }

            if (!File.Exists(filePath))
                return;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(
                    '=',
                    StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 2)
                    continue;

                Environment.SetEnvironmentVariable(parts[0], parts[1]);
            }
        }
    }
}