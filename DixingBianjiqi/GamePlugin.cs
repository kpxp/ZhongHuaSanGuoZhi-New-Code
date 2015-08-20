using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using		GameObjects;
using		Microsoft.Xna.Framework;

using		PluginInterface;
using PluginServices;



namespace WorldOfTheThreeKingdoms.GameLogic

{
    internal class GamePlugin
    {
        internal IAirView AirViewPlugin = null;
        internal IArchitectureDetail ArchitectureDetailPlugin = null;
        internal IArchitectureSurvey ArchitectureSurveyPlugin = null;
        internal IConfirmationDialog ConfirmationDialogPlugin = null;
        internal IConmentText ConmentTextPlugin = null;
        internal IGameContextMenu ContextMenuPlugin = null;
        internal ICreateTroop CreateTroopPlugin = null;
        internal IDateRunner DateRunnerPlugin = null;
        internal IFactionTechniques FactionTechniquesPlugin = null;
        internal IGameFrame GameFramePlugin = null;
        internal IGameRecord GameRecordPlugin = null;
        internal IGameSystem GameSystemPlugin = null;
        internal IHelp HelpPlugin = null;
        internal IMapLayer MapLayerPlugin = null;
        internal IMapViewSelector MapViewSelectorPlugin = null;
        internal IMarshalSectionDialog MarshalSectionDialogPlugin = null;
        internal INumberInputer NumberInputerPlugin = null;
        internal IOptionDialog OptionDialogPlugin = null;
        internal IPersonBubble PersonBubblePlugin = null;
        internal IPersonDetail PersonDetailPlugin = null;
        internal IPersonPortrait PersonPortraitPlugin = null;
        internal IPersonTextDialog PersonTextDialogPlugin = null;

        internal Itupianwenzi tupianwenziPlugin = null;

        internal IRoutewayEditor RoutewayEditorPlugin = null;
        internal IScreenBlind ScreenBlindPlugin = null;
        internal ISimpleTextDialog SimpleTextDialogPlugin = null;
        internal ITabList TabListPlugin = null;
        internal Iyoucelan youcelanPlugin = null;
        internal IToolBar ToolBarPlugin = null;
        internal ITransportDialog TransportDialogPlugin = null;
        internal ITreasureDetail TreasureDetailPlugin = null;
        internal ITroopDetail TroopDetailPlugin = null;
        internal ITroopSurvey TroopSurveyPlugin = null;
        internal ITroopTitle TroopTitlePlugin = null;

        internal void InitializePlugins(Screen screen)
        {
            AvailablePlugin plugin = Plugin.Plugins.AvailablePlugins.Find("HelpPlugin");
            if ((plugin != null) && (plugin.Instance is IHelp))
            {
                this.HelpPlugin = plugin.Instance as IHelp;
                this.HelpPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                this.HelpPlugin.SetScreen(screen);
                screen.PluginList.Add(this.HelpPlugin.Instance as GameObject);
            }
            plugin = Plugin.Plugins.AvailablePlugins.Find("PersonDetailPlugin");
            if ((plugin != null) && (plugin.Instance is IPersonDetail))
            {
                this.PersonDetailPlugin = plugin.Instance as IPersonDetail;
                this.PersonDetailPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                this.PersonDetailPlugin.SetScreen(screen);
                screen.PluginList.Add(this.PersonDetailPlugin.Instance as GameObject);
            }
            plugin = Plugin.Plugins.AvailablePlugins.Find("TroopDetailPlugin");
            if ((plugin != null) && (plugin.Instance is ITroopDetail))
            {
                this.TroopDetailPlugin = plugin.Instance as ITroopDetail;
                this.TroopDetailPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                this.TroopDetailPlugin.SetScreen(screen);
                screen.PluginList.Add(this.TroopDetailPlugin.Instance as GameObject);
            }
            plugin = Plugin.Plugins.AvailablePlugins.Find("ArchitectureDetailPlugin");
            if ((plugin != null) && (plugin.Instance is IArchitectureDetail))
            {
                this.ArchitectureDetailPlugin = plugin.Instance as IArchitectureDetail;
                this.ArchitectureDetailPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                this.ArchitectureDetailPlugin.SetScreen(screen);
                screen.PluginList.Add(this.ArchitectureDetailPlugin.Instance as GameObject);
            }
            plugin = Plugin.Plugins.AvailablePlugins.Find("FactionTechniquesPlugin");
            if ((plugin != null) && (plugin.Instance is IFactionTechniques))
            {
                this.FactionTechniquesPlugin = plugin.Instance as IFactionTechniques;
                this.FactionTechniquesPlugin.SetScreen(screen);
                this.FactionTechniquesPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                screen.PluginList.Add(this.FactionTechniquesPlugin.Instance as GameObject);
            }
            plugin = Plugin.Plugins.AvailablePlugins.Find("TreasureDetailPlugin");
            if ((plugin != null) && (plugin.Instance is ITreasureDetail))
            {
                this.TreasureDetailPlugin = plugin.Instance as ITreasureDetail;
                this.TreasureDetailPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                this.TreasureDetailPlugin.SetScreen(screen);
                screen.PluginList.Add(this.TreasureDetailPlugin.Instance as GameObject);
            }
            plugin = Plugin.Plugins.AvailablePlugins.Find("ConmentTextPlugin");
            if ((plugin != null) && (plugin.Instance is IConmentText))
            {
                this.ConmentTextPlugin = plugin.Instance as IConmentText;
                this.ConmentTextPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                screen.PluginList.Add(this.ConmentTextPlugin.Instance as GameObject);
            }
            plugin = Plugin.Plugins.AvailablePlugins.Find("ArchitectureSurveyPlugin");
            if ((plugin != null) && (plugin.Instance is IArchitectureSurvey))
            {
                this.ArchitectureSurveyPlugin = plugin.Instance as IArchitectureSurvey;
                this.ArchitectureSurveyPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                screen.PluginList.Add(this.ArchitectureSurveyPlugin.Instance as GameObject);
            }
            plugin = Plugin.Plugins.AvailablePlugins.Find("TroopSurveyPlugin");
            if ((plugin != null) && (plugin.Instance is ITroopSurvey))
            {
                this.TroopSurveyPlugin = plugin.Instance as ITroopSurvey;
                this.TroopSurveyPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                screen.PluginList.Add(this.TroopSurveyPlugin.Instance as GameObject);
            }
            plugin = Plugin.Plugins.AvailablePlugins.Find("ContextMenuPlugin");
            if ((plugin != null) && (plugin.Instance is IGameContextMenu))
            {
                this.ContextMenuPlugin = plugin.Instance as IGameContextMenu;
                this.ContextMenuPlugin.SetScreen(screen);
                this.ContextMenuPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                this.ContextMenuPlugin.SetIHelp(this.HelpPlugin);
                screen.PluginList.Add(this.ContextMenuPlugin.Instance as GameObject);
            }
            plugin = Plugin.Plugins.AvailablePlugins.Find("GameFramePlugin");
            if ((plugin != null) && (plugin.Instance is IGameFrame))
            {
                this.GameFramePlugin = plugin.Instance as IGameFrame;
                this.GameFramePlugin.SetScreen(screen);
                this.GameFramePlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                screen.PluginList.Add(this.GameFramePlugin.Instance as GameObject);
            }
            plugin = Plugin.Plugins.AvailablePlugins.Find("ScreenBlindPlugin");
            if ((plugin != null) && (plugin.Instance is IScreenBlind))
            {
                this.ScreenBlindPlugin = plugin.Instance as IScreenBlind;
                this.ScreenBlindPlugin.SetScreen(screen);
                this.ScreenBlindPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                screen.PluginList.Add(this.ScreenBlindPlugin.Instance as GameObject);
            }
            plugin = Plugin.Plugins.AvailablePlugins.Find("MapViewSelectorPlugin");
            if ((plugin != null) && (plugin.Instance is IMapViewSelector))
            {
                this.MapViewSelectorPlugin = plugin.Instance as IMapViewSelector;
                this.MapViewSelectorPlugin.SetScreen(screen);
                this.MapViewSelectorPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                this.MapViewSelectorPlugin.SetGameFrame(this.GameFramePlugin);
                screen.PluginList.Add(this.MapViewSelectorPlugin.Instance as GameObject);
            }
            plugin = Plugin.Plugins.AvailablePlugins.Find("TabListPlugin");
            if ((plugin != null) && (plugin.Instance is ITabList))
            {
                this.TabListPlugin = plugin.Instance as ITabList;
                this.TabListPlugin.SetScreen(screen);
                this.TabListPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                this.TabListPlugin.SetPersonDetailDialog(this.PersonDetailPlugin);
                this.TabListPlugin.SetTroopDetailDialog(this.TroopDetailPlugin);
                this.TabListPlugin.SetArchitectureDetailDialog(this.ArchitectureDetailPlugin);
                this.TabListPlugin.SetFactionTechniquesDialog(this.FactionTechniquesPlugin);
                this.TabListPlugin.SetTreasureDetailDialog(this.TreasureDetailPlugin);
                this.TabListPlugin.SetGameFrame(this.GameFramePlugin);
                this.TabListPlugin.SetMapViewSelector(this.MapViewSelectorPlugin);
                screen.PluginList.Add(this.TabListPlugin.Instance as GameObject);
            }
            plugin = Plugin.Plugins.AvailablePlugins.Find("OptionDialogPlugin");
            if ((plugin != null) && (plugin.Instance is IOptionDialog))
            {
                this.OptionDialogPlugin = plugin.Instance as IOptionDialog;
                this.OptionDialogPlugin.SetScreen(screen);
                this.OptionDialogPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                screen.PluginList.Add(this.OptionDialogPlugin.Instance as GameObject);
            }
            plugin = Plugin.Plugins.AvailablePlugins.Find("SimpleTextDialogPlugin");
            if ((plugin != null) && (plugin.Instance is ISimpleTextDialog))
            {
                this.SimpleTextDialogPlugin = plugin.Instance as ISimpleTextDialog;
                this.SimpleTextDialogPlugin.SetScreen(screen);
                this.SimpleTextDialogPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                screen.PluginList.Add(this.SimpleTextDialogPlugin.Instance as GameObject);
            }
            plugin = Plugin.Plugins.AvailablePlugins.Find("PersonTextDialogPlugin");
            if ((plugin != null) && (plugin.Instance is IPersonTextDialog))
            {
                this.PersonTextDialogPlugin = plugin.Instance as IPersonTextDialog;
                this.PersonTextDialogPlugin.SetScreen(screen);
                this.PersonTextDialogPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                this.PersonTextDialogPlugin.SetContextMenu(this.ContextMenuPlugin);
                screen.PluginList.Add(this.PersonTextDialogPlugin.Instance as GameObject);
            }


            plugin = Plugin.Plugins.AvailablePlugins.Find("tupianwenziPlugin");
            if ((plugin != null) && (plugin.Instance is Itupianwenzi))
            {
                this.tupianwenziPlugin = plugin.Instance as Itupianwenzi;
                this.tupianwenziPlugin.SetScreen(screen);
                this.tupianwenziPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                this.tupianwenziPlugin.SetContextMenu(this.ContextMenuPlugin);
                screen.PluginList.Add(this.tupianwenziPlugin.Instance as GameObject);
            }




            plugin = Plugin.Plugins.AvailablePlugins.Find("ConfirmationDialogPlugin");
            if ((plugin != null) && (plugin.Instance is IConfirmationDialog))
            {
                this.ConfirmationDialogPlugin = plugin.Instance as IConfirmationDialog;
                this.ConfirmationDialogPlugin.SetScreen(screen);
                this.ConfirmationDialogPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                screen.PluginList.Add(this.ConfirmationDialogPlugin.Instance as GameObject);
            }
            plugin = Plugin.Plugins.AvailablePlugins.Find("ToolBarPlugin");
            if ((plugin != null) && (plugin.Instance is IToolBar))
            {
                this.ToolBarPlugin = plugin.Instance as IToolBar;
                this.ToolBarPlugin.SetScreen(screen);
                this.ToolBarPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                this.ToolBarPlugin.SetContextMenuPlugin(this.ContextMenuPlugin);
                screen.PluginList.Add(this.ToolBarPlugin.Instance as GameObject);
            }
            if (this.ToolBarPlugin != null)
            {
                plugin = Plugin.Plugins.AvailablePlugins.Find("DateRunnerPlugin");
                if ((plugin != null) && (plugin.Instance is IDateRunner))
                {
                    this.DateRunnerPlugin = plugin.Instance as IDateRunner;
                    this.DateRunnerPlugin.SetScreen(screen);
                    this.DateRunnerPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                    this.DateRunnerPlugin.SetGameDate(screen.Scenario.Date);
                    this.ToolBarPlugin.AddTool(this.DateRunnerPlugin.ToolInstance);
                    screen.PluginList.Add(this.DateRunnerPlugin.Instance as GameObject);
                }
            }
            if (this.ToolBarPlugin != null)
            {
                plugin = Plugin.Plugins.AvailablePlugins.Find("GameRecordPlugin");
                if ((plugin != null) && (plugin.Instance is IGameRecord))
                {
                    this.GameRecordPlugin = plugin.Instance as IGameRecord;
                    this.GameRecordPlugin.SetScreen(screen);
                    this.GameRecordPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                    this.ToolBarPlugin.AddTool(this.GameRecordPlugin.ToolInstance);
                    screen.PluginList.Add(this.GameRecordPlugin.Instance as GameObject);
                }
            }
            if (this.ToolBarPlugin != null)
            {
                plugin = Plugin.Plugins.AvailablePlugins.Find("MapLayerPlugin");
                if ((plugin != null) && (plugin.Instance is IMapLayer))
                {
                    this.MapLayerPlugin = plugin.Instance as IMapLayer;
                    this.MapLayerPlugin.SetScreen(screen);
                    this.MapLayerPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                    this.ToolBarPlugin.AddTool(this.MapLayerPlugin.ToolInstance);
                    screen.PluginList.Add(this.MapLayerPlugin.Instance as GameObject);
                }
            }
            if (this.ToolBarPlugin != null)
            {
                plugin = Plugin.Plugins.AvailablePlugins.Find("GameSystemPlugin");
                if ((plugin != null) && (plugin.Instance is IGameSystem))
                {
                    this.GameSystemPlugin = plugin.Instance as IGameSystem;
                    this.GameSystemPlugin.SetScreen(screen);
                    this.GameSystemPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                    this.GameSystemPlugin.SetOptionDialog(this.OptionDialogPlugin);
                    this.ToolBarPlugin.AddTool(this.GameSystemPlugin.ToolInstance);
                    screen.PluginList.Add(this.GameSystemPlugin.Instance as GameObject);
                }
            }
            if (this.ToolBarPlugin != null)
            {
                plugin = Plugin.Plugins.AvailablePlugins.Find("AirViewPlugin");
                if ((plugin != null) && (plugin.Instance is IAirView))
                {
                    this.AirViewPlugin = plugin.Instance as IAirView;
                    this.AirViewPlugin.SetScreen(screen);
                    this.AirViewPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                    this.ToolBarPlugin.AddTool(this.AirViewPlugin.ToolInstance);
                    screen.PluginList.Add(this.AirViewPlugin.Instance as GameObject);
                }
            }
            plugin = Plugin.Plugins.AvailablePlugins.Find("PersonPortraitPlugin");
            if ((plugin != null) && (plugin.Instance is IPersonPortrait))
            {
                this.PersonPortraitPlugin = plugin.Instance as IPersonPortrait;
                this.PersonPortraitPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                screen.PluginList.Add(this.PersonPortraitPlugin.Instance as GameObject);
            }
            plugin = Plugin.Plugins.AvailablePlugins.Find("PersonBubblePlugin");
            if ((plugin != null) && (plugin.Instance is IPersonBubble))
            {
                this.PersonBubblePlugin = plugin.Instance as IPersonBubble;
                this.PersonBubblePlugin.SetScreen(screen);
                this.PersonBubblePlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                screen.PluginList.Add(this.PersonBubblePlugin.Instance as GameObject);
            }
            plugin = Plugin.Plugins.AvailablePlugins.Find("TroopTitlePlugin");
            if ((plugin != null) && (plugin.Instance is ITroopTitle))
            {
                this.TroopTitlePlugin = plugin.Instance as ITroopTitle;
                this.TroopTitlePlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                screen.PluginList.Add(this.TroopTitlePlugin.Instance as GameObject);
            }
            plugin = Plugin.Plugins.AvailablePlugins.Find("RoutewayEditorPlugin");
            if ((plugin != null) && (plugin.Instance is IRoutewayEditor))
            {
                this.RoutewayEditorPlugin = plugin.Instance as IRoutewayEditor;
                this.RoutewayEditorPlugin.SetScreen(screen);
                this.RoutewayEditorPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                screen.PluginList.Add(this.RoutewayEditorPlugin.Instance as GameObject);
            }
            plugin = Plugin.Plugins.AvailablePlugins.Find("NumberInputerPlugin");
            if ((plugin != null) && (plugin.Instance is INumberInputer))
            {
                this.NumberInputerPlugin = plugin.Instance as INumberInputer;
                this.NumberInputerPlugin.SetScreen(screen);
                this.NumberInputerPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                screen.PluginList.Add(this.NumberInputerPlugin.Instance as GameObject);
            }
            plugin = Plugin.Plugins.AvailablePlugins.Find("TransportDialogPlugin");
            if ((plugin != null) && (plugin.Instance is ITransportDialog))
            {
                this.TransportDialogPlugin = plugin.Instance as ITransportDialog;
                this.TransportDialogPlugin.SetScreen(screen);
                this.TransportDialogPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                this.TransportDialogPlugin.SetGameFrame(this.GameFramePlugin);
                this.TransportDialogPlugin.SetTabList(this.TabListPlugin);
                this.TransportDialogPlugin.SetNumberInputer(this.NumberInputerPlugin);
                screen.PluginList.Add(this.TransportDialogPlugin.Instance as GameObject);
            }
            plugin = Plugin.Plugins.AvailablePlugins.Find("CreateTroopPlugin");
            if ((plugin != null) && (plugin.Instance is ICreateTroop))
            {
                this.CreateTroopPlugin = plugin.Instance as ICreateTroop;
                this.CreateTroopPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                this.CreateTroopPlugin.SetScreen(screen);
                this.CreateTroopPlugin.SetGameFrame(this.GameFramePlugin);
                this.CreateTroopPlugin.SetTabList(this.TabListPlugin);
                this.CreateTroopPlugin.SetNumberInputer(this.NumberInputerPlugin);
                screen.PluginList.Add(this.CreateTroopPlugin.Instance as GameObject);
            }
            plugin = Plugin.Plugins.AvailablePlugins.Find("MarshalSectionDialogPlugin");
            if ((plugin != null) && (plugin.Instance is IMarshalSectionDialog))
            {
                this.MarshalSectionDialogPlugin = plugin.Instance as IMarshalSectionDialog;
                this.MarshalSectionDialogPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                this.MarshalSectionDialogPlugin.SetScreen(screen);
                this.MarshalSectionDialogPlugin.SetGameFrame(this.GameFramePlugin);
                this.MarshalSectionDialogPlugin.SetTabList(this.TabListPlugin);
                screen.PluginList.Add(this.MarshalSectionDialogPlugin.Instance as GameObject);
            }
            
            plugin = Plugin.Plugins.AvailablePlugins.Find("youcelanPlugin");
            if ((plugin != null) && (plugin.Instance is Iyoucelan))
            {
                this.youcelanPlugin = plugin.Instance as Iyoucelan;
                this.youcelanPlugin.SetScreen(screen);
                this.youcelanPlugin.SetGraphicsDevice(screen.spriteBatch.GraphicsDevice);
                this.youcelanPlugin.SetPersonDetailDialog(this.PersonDetailPlugin);
                this.youcelanPlugin.SetTroopDetailDialog(this.TroopDetailPlugin);
                this.youcelanPlugin.SetArchitectureDetailDialog(this.ArchitectureDetailPlugin);
                this.youcelanPlugin.SetFactionTechniquesDialog(this.FactionTechniquesPlugin);
                this.youcelanPlugin.SetTreasureDetailDialog(this.TreasureDetailPlugin);
                this.youcelanPlugin.SetGameFrame(this.GameFramePlugin);
                this.youcelanPlugin.SetMapViewSelector(this.MapViewSelectorPlugin);
                screen.PluginList.Add(this.youcelanPlugin.Instance as GameObject);
            }
            

        }
    }

 

}
