using System;
using System.IO;

namespace DucasTest
{
	public static class Util
	{
		public static void LogError(Exception ex)
		{
			try
			{
				using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\Asheron's Call\" + Globals.PluginName + " errors.txt", true))
				{
					writer.WriteLine("============================================================================");
					writer.WriteLine(DateTime.Now.ToString());
					writer.WriteLine("Error: " + ex.Message);
					writer.WriteLine("Source: " + ex.Source);
					writer.WriteLine("Stack: " + ex.StackTrace);
					if (ex.InnerException != null)
					{
						writer.WriteLine("Inner: " + ex.InnerException.Message);
						writer.WriteLine("Inner Stack: " + ex.InnerException.StackTrace);
					}
					writer.WriteLine("============================================================================");
					writer.WriteLine("");
					writer.Close();
				}
			}
			catch
			{
			}
		}

		public static void WriteToChat(string message)
		{
			try
			{
                Globals.Host.Actions.AddChatText("[" + Globals.PluginName + "] : " + message, 5);
			}
			catch (Exception ex) { LogError(ex); }
		}

        public static void WriteToChat(string message, int color)
        {
            try
            {
                Globals.Host.Actions.AddChatText("[" + Globals.PluginName + "] : " + message, color);
            }
            catch (Exception ex) { LogError(ex); }
        }

        public static void WriteToChat(string message, ChatUtil.Color color)
        {
            try
            {
                Globals.Host.Actions.AddChatText("[" + Globals.PluginName + "] : " + message, (int)color);
            }
            catch (Exception ex) { LogError(ex); }
        }
    }
}
