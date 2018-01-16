using System;
using System.Collections.Generic;
using System.Text;
using Decal.Adapter;
using Decal.Adapter.Wrappers;
using Decal.Filters;
using DucasTest.SpellConstants;
using DucasTest.Spellbars;

namespace DucasTest
{
    public partial class PluginCore
    {
        // logger tab
        MyClasses.MetaViewWrappers.IView View;
        MyClasses.MetaViewWrappers.IButton cmdLogOnPk;
        MyClasses.MetaViewWrappers.IButton cmdLogOnUnknown;
        MyClasses.MetaViewWrappers.IButton cmdLogOnFriendly;
        MyClasses.MetaViewWrappers.IButton cmdLogOnAll;


        //spell tab
        MyClasses.MetaViewWrappers.IButton cmdClearAllSpellTabs;
        MyClasses.MetaViewWrappers.IButton cmdLoadMissileSpellTabs;
        MyClasses.MetaViewWrappers.IButton cmdLoadMageSpellTabs;
        MyClasses.MetaViewWrappers.IButton cmdLoadHeavyWeaponsSpellTabs;
        MyClasses.MetaViewWrappers.IButton cmdLoadFinesseWeaponsSpellTabs;
        MyClasses.MetaViewWrappers.IButton cmdLoadLightWeaponsSpellTabs;

        MyClasses.MetaViewWrappers.IButton cmdTestButton;

        //spell tab stuff
        private List<Spell>[] mSpellTabs;
        private FileService mFS;

        void InitView()
        {
            // initialize view @TODO: does this actually do the initialization? figure out what this does
            View = MyClasses.MetaViewWrappers.ViewSystemSelector.CreateViewResource(Host, "DucasTest.ViewXML.mainView.xml");

            // *************************************************************
            //logger tab buttons
            cmdLogOnPk = (MyClasses.MetaViewWrappers.IButton)View["cmdLogOnPk"];
            cmdLogOnUnknown = (MyClasses.MetaViewWrappers.IButton)View["cmdLogOnUnknown"];
            cmdLogOnFriendly = (MyClasses.MetaViewWrappers.IButton)View["cmdLogOnFriendly"];
            cmdLogOnAll = (MyClasses.MetaViewWrappers.IButton)View["cmdLogOnAll"];
            // logger tab handlers
            cmdLogOnPk.Hit += new EventHandler(cmdLogOnPk_Hit);
            cmdLogOnUnknown.Hit += new EventHandler(cmdLogOnUnknown_Hit);
            cmdLogOnFriendly.Hit += new EventHandler(cmdLogOnFriendly_Hit);
            cmdLogOnAll.Hit += new EventHandler(cmdLogOnAll_Hit);
            // /////////////////////////////////////////////////////////////
            // *************************************************************

            // *************************************************************
            // spell tab buttons
            cmdClearAllSpellTabs = (MyClasses.MetaViewWrappers.IButton)View["cmdClearAllSpellTabs"];
            cmdLoadMissileSpellTabs = (MyClasses.MetaViewWrappers.IButton)View["cmdLoadMissileSpellTabs"];
            cmdLoadMageSpellTabs = (MyClasses.MetaViewWrappers.IButton)View["cmdLoadMageSpellTabs"];
            cmdLoadHeavyWeaponsSpellTabs = (MyClasses.MetaViewWrappers.IButton)View["cmdLoadHeavyWeaponsSpellTabs"];
            cmdLoadFinesseWeaponsSpellTabs = (MyClasses.MetaViewWrappers.IButton)View["cmdLoadFinesseWeaponsSpellTabs"];
            cmdLoadLightWeaponsSpellTabs = (MyClasses.MetaViewWrappers.IButton)View["cmdLoadLightWeaponsSpellTabs"];
            //// spell tab handlers
            cmdClearAllSpellTabs.Hit += new EventHandler(cmdClearAllSpellTabs_Hit);
            cmdLoadMissileSpellTabs.Hit += new EventHandler(cmdLoadMissileSpellTabs_Hit);
            cmdLoadMageSpellTabs.Hit += new EventHandler(cmdLoadMageSpellTabs_Hit);
            cmdLoadHeavyWeaponsSpellTabs.Hit += new EventHandler(cmdLoadHeavyWeaponsSpellTabs_Hit);
            cmdLoadFinesseWeaponsSpellTabs.Hit += new EventHandler(cmdLoadFinesseWeaponsSpellTabs_Hit);
            cmdLoadLightWeaponsSpellTabs.Hit += new EventHandler(cmdLoadLightWeaponsSpellTabs_Hit);
            // /////////////////////////////////////////////////////////////
            // *************************************************************


            mFS = (FileService)Core.FileService;


        }

        void DestroyView()
        {
            //destroy logger views
            cmdLogOnPk.Hit -= new EventHandler(cmdLogOnPk_Hit);
            cmdLogOnUnknown.Hit -= new EventHandler(cmdLogOnUnknown_Hit);
            cmdLogOnFriendly.Hit -= new EventHandler(cmdLogOnFriendly_Hit);
            cmdLogOnAll.Hit -= new EventHandler(cmdLogOnAll_Hit);
            // make them null
            cmdLogOnPk = null;
            cmdLogOnUnknown = null;
            cmdLogOnFriendly = null;
            cmdLogOnAll = null;

            // destroy spelltab views
            cmdClearAllSpellTabs.Hit -= new EventHandler(cmdClearAllSpellTabs_Hit);
            cmdLoadMissileSpellTabs.Hit -= new EventHandler(cmdLoadMissileSpellTabs_Hit);
            cmdLoadMageSpellTabs.Hit -= new EventHandler(cmdLoadMageSpellTabs_Hit);
            cmdLoadHeavyWeaponsSpellTabs.Hit -= new EventHandler(cmdLoadHeavyWeaponsSpellTabs_Hit);
            cmdLoadFinesseWeaponsSpellTabs.Hit -= new EventHandler(cmdLoadFinesseWeaponsSpellTabs_Hit);
            cmdLoadLightWeaponsSpellTabs.Hit -= new EventHandler(cmdLoadLightWeaponsSpellTabs_Hit);
            // make them null
            cmdClearAllSpellTabs = null;
            cmdLoadMissileSpellTabs = null;
            cmdLoadMageSpellTabs = null;
            cmdLoadHeavyWeaponsSpellTabs = null;
            cmdLoadFinesseWeaponsSpellTabs = null;
            cmdLoadLightWeaponsSpellTabs = null;


            View.Dispose();
        }


        void cmdClearAllSpellTabs_Hit(object sender, EventArgs e)
        {
            Util.WriteToChat("Entered Clear All Spell Tabs Listener!");
            
            for (int tab = 6; tab >= 0; --tab)
            {
                ICollection<int> spellIds = Core.CharacterFilter.SpellBar(tab);
                foreach (int spellId in spellIds)
                {
                    Host.Actions.SpellTabDelete(tab, spellId);

                }
            }
        }

        void cmdLoadMissileSpellTabs_Hit(object sender, EventArgs e)
        {
            Util.WriteToChat("Entered Load Missile Spell Tab Listener!");
        }

        void cmdLoadMageSpellTabs_Hit(object sender, EventArgs e)
        {
            Util.WriteToChat("Entered Load Mage Spell Tab Listener!");
            MageSpells.SetMageBars();
        }

        void cmdLoadHeavyWeaponsSpellTabs_Hit(object sender, EventArgs e)
        {
            Util.WriteToChat("Entered Load Heavy Weapons Spell Tab Listener!");
        }

        void cmdLoadFinesseWeaponsSpellTabs_Hit(object sender, EventArgs e)
        {
            Util.WriteToChat("Entered Load Finesse Weapons Spell Tab Listener!");
        }

        void cmdLoadLightWeaponsSpellTabs_Hit(object sender, EventArgs e)
        {
            Util.WriteToChat("Entered Load Light Weapons Spell Tab Listener!");
        }

        void cmdLogOnPk_Hit(object sender, EventArgs e)
        {
            LogOnPkFlag ^= true;
            Util.WriteToChat("Log on PK: " + LogOnPkFlag.ToString(), ChatUtil.Color.blue_bright);
        }

        void cmdLogOnUnknown_Hit(object sender, EventArgs e)
        {
            LogOnUnknownFlag ^= true;
            Util.WriteToChat("Log on Unknown: " + LogOnUnknownFlag.ToString(), ChatUtil.Color.blue_bright);
        }

        void cmdLogOnFriendly_Hit(object sender, EventArgs e)
        {
            LogOnFriendlyFlag ^= true;
            Util.WriteToChat("Log on Friendly: " + LogOnFriendlyFlag.ToString(), ChatUtil.Color.blue_bright);
        }

        void cmdLogOnAll_Hit(object sender, EventArgs e)
        {
            LogOnAllFlag ^= true;
            LogOnPkFlag = LogOnAllFlag;
            LogOnUnknownFlag = LogOnAllFlag;
            LogOnFriendlyFlag = LogOnAllFlag;

            Util.WriteToChat(
                "Log on: " +
                "\n     PK: " + LogOnPkFlag.ToString() +
                "\n     Unknown: " + LogOnUnknownFlag.ToString() +
                "\n     Friendly: " + LogOnFriendlyFlag.ToString() +
                "\n   All: " + LogOnAllFlag.ToString(), 
                ChatUtil.Color.blue_bright);
        }





    }
}
