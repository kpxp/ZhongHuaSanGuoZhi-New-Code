using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;



using		PluginInterface;
//using PluginServices;
using System.IO;
using System.Reflection;
using PluginInterface.BaseInterface;



namespace PluginServices
{
    public class PluginService
    {
        private AvailablePlugins availablePlugins = new AvailablePlugins();
        public static string[] GamePluginTypes = new string[] { 
            "IHelp", "IConmentText", "IArchitectureSurvey", "ITroopSurvey", "IGameContextMenu", "IGameFrame", "ITabList", "IToolBar", "IDateRunner", "IGameSystem", "IOptionDialog", "IConfirmationDialog", "ISimpleTextDialog", "IPersonTextDialog", "IPersonPortrait", "IAirView", 
            "IPersonBubble", "IScreenBlind", "ITroopTitle", "IPersonDetail", "ITroopDetail", "IGameRecord", "IFactionTechniques", "IArchitectureDetail", "IMapLayer", "IRoutewayEditor", "INumberInputer", "ITransportDialog", "ICreateTroop", "IMapViewSelector", "IMarshalSectionDialog", 
            "ITreasureDetail","Iyoucelan","Itupianwenzi","IBianduiLiebiao"
       };

        private void AddPlugin(string FileName)
        {
            Assembly assembly = Assembly.LoadFrom(FileName);
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsPublic && !type.IsAbstract)
                {
                    if (this.GetPluginInterface(type) != null)
                    {
                        AvailablePlugin pluginToAdd = new AvailablePlugin
                        {
                            AssemblyPath = FileName,
                            Instance = (IBasePlugin)Activator.CreateInstance(assembly.GetType(type.ToString()))
                        };
                        pluginToAdd.Instance.Initialize();
                        this.availablePlugins.Add(pluginToAdd);
                        pluginToAdd = null;
                    }
                }
            }
            assembly = null;
        }

        public void ClearPlugins()
        {
            this.availablePlugins.Clear();
        }

        public void ClosePlugin(IBasePlugin plugin)
        {
            for (int i = 0; i < this.availablePlugins.Count; i++)
            {
                if (this.availablePlugins[i].Instance == plugin)
                {
                    this.availablePlugins.RemoveAt(i);
                    plugin.Dispose();
                    plugin = null;
                    break;
                }
            }
        }

        public void ClosePlugins()
        {
            foreach (AvailablePlugin plugin in this.availablePlugins)
            {
                plugin.Instance.Dispose();
                plugin.Instance = null;
            }
            this.availablePlugins.Clear();
        }

        public void FindPlugins()
        {
            this.FindPlugins(AppDomain.CurrentDomain.BaseDirectory);
        }

        public void FindPlugins(string Path)
        {
            if (Directory.Exists(Path))
            {
                foreach (string str in Directory.GetDirectories(Path))
                {
                    foreach (string str2 in Directory.GetFiles(str))
                    {
                        FileInfo info = new FileInfo(str2);
                        if (info.Extension.Equals(".dll"))
                        {
                            this.AddPlugin(str2);
                            break;
                        }
                    }
                }
            }
        }

        private Type GetPluginInterface(Type pluginType)
        {
            Type type = null;
            foreach (string str in GamePluginTypes)
            {
                type = pluginType.GetInterface(str, true);
                if (type != null)
                {
                    return type;
                }
            }
            return type;
        }

        public AvailablePlugins AvailablePlugins
        {
            get
            {
                return this.availablePlugins;
            }
            set
            {
                this.availablePlugins = value;
            }
        }
    }

 

}
