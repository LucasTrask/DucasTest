﻿using System;

using Decal.Adapter;
using Decal.Adapter.Wrappers;
using MyClasses.MetaViewWrappers;
using VirindiViewService;
using DucasTest.Npcs;
using DucasTest.Vendors;

namespace DucasTest
{
    
    [WireUpBaseEvents] // TODO: learn what this is

    [MVView("DucasTest.mainView.xml")] // file that tells vT how to draw plugin in-game, must be embedded resource
    [MVWireUpControlEvents] // TODO: learn this better
    [FriendlyName("DucasTest")] // decal plugin list name, not in game name


    // Main class, split up into MainView.cs for the button logic
    public partial class PluginCore : PluginBase
    {

        private HudView DucasTestHudView;
        private ACImage SummoningIcon = new ACImage(7687);
        private bool LogOnPkFlag;
        private bool LogOnUnknownFlag;
        private bool LogOnFriendlyFlag;
        private bool LogOnAllFlag;
        private bool TurnInFlag = false;

        /// <summary>
        // This is called when the plugin is started up. This happens only once.
        /// </summary>
        protected override void Startup()
        {
            // manually set flags to false on start up @TODO: this should be read from registry or a file somewhere eventually once I learn how to C#
            LogOnPkFlag = false;
            LogOnUnknownFlag = false;
            LogOnFriendlyFlag = false;
            LogOnAllFlag = false;

            try
            {
                // static Globals class with references to Host and Core.
                // The OOP way would be to pass Host and Core to your objects, but this is easier.
                Globals.Init("DucasTest", Host, Core);

                InitView();

                //Initialize the view.
                MVWireupHelper.WireupStart(this, Host);
            }
            catch (Exception ex) { Util.LogError(ex); }
        }

        /// <summary>
        /// This is called when the plugin is shut down. This happens only once.
        /// </summary>
        protected override void Shutdown()
        {
            try
            {
                //Destroy the view.
                MVWireupHelper.WireupEnd(this);
            }
            catch (Exception ex) { Util.LogError(ex); }
        }

        [BaseEvent("LoginComplete", "CharacterFilter")]
        private void CharacterFilter_LoginComplete(object sender, EventArgs e)
        {
            try
            {
                Util.WriteToChat("Allegiance : " + CoreManager.Current.CharacterFilter.Allegiance.Type.ToString());
                Util.WriteToChat("Patron : " + CoreManager.Current.CharacterFilter.Patron.Type.ToString());
                Util.WriteToChat("Monarch : " + CoreManager.Current.CharacterFilter.Monarch.Type.ToString());
                Util.WriteToChat("Player : " + CoreManager.Current.CharacterFilter.Id.ToString());

                Util.WriteToChat(CoreManager.Current.CharacterFilter.Patron.Id.ToString());
                Util.WriteToChat("Monarch Id: " +
                        CoreManager.Current.CharacterFilter.Monarch.Id.ToString() +
                        " and Monarch Name: " +
                        CoreManager.Current.CharacterFilter.Monarch.Name.ToString());

                // listen for chat commands
                CoreManager.Current.CommandLineText += new EventHandler<Decal.Adapter.ChatParserInterceptEventArgs>(this.Core_CommandLineText);

                // listen for network events
                //CoreManager.Current.EchoFilter.ServerDispatch += new EventHandler<NetworkMessageEventArgs>(this.EchoFilter_NetworkMessage);

                // listen for messages in Chat Box
                CoreManager.Current.ChatBoxMessage += new EventHandler<Decal.Adapter.ChatTextInterceptEventArgs>(this.Core_ChatBoxMessage);

                // listen for create object events!
                CoreManager.Current.WorldFilter.CreateObject += new EventHandler<CreateObjectEventArgs>(this.WorldFilter_CreateObject);

                // misc other stuff
                /* CoreManager.Current.WorldFilter.ReleaseObject += new EventHandler<ReleaseObjectEventArgscorn pep>(this.WorldFilter_ReleaseObject);
                   CoreManager.Current.CharacterFilter.LoginComplete += new EventHandler(this.CharacterFilter_LoginComplete_VHS);
                   CoreManager.Current.ItemDestroyed += new EventHandler<ItemDestroyedEventArgs>(ItemDestroyed_EventArgs);
                   CoreManager.Current.WorldFilter.ChangeObject += new EventHandler<ChangeObjectEventArgs>(ChangeObject_EventArgs);
                   */

                // Subscribe to events here
                Globals.Core.WorldFilter.ChangeObject += new EventHandler<ChangeObjectEventArgs>(WorldFilter_ChangeObject2);

            }
            catch (Exception ex) { Util.LogError(ex); }
        }

        [BaseEvent("Logoff", "CharacterFilter")]
        private void CharacterFilter_Logoff(object sender, Decal.Adapter.Wrappers.LogoffEventArgs e)
        {
            try
            {
                // This is not the proper place to free up resources...
                Globals.Core.WorldFilter.ChangeObject -= new EventHandler<ChangeObjectEventArgs>(WorldFilter_ChangeObject2);
                CoreManager.Current.CommandLineText -= new EventHandler<Decal.Adapter.ChatParserInterceptEventArgs>(this.Core_CommandLineText);
                //CoreManager.Current.EchoFilter.ServerDispatch += new EventHandler<NetworkMessageEventArgs>(this.EchoFilter_NetworkMessage);
                CoreManager.Current.ChatBoxMessage -= new EventHandler<Decal.Adapter.ChatTextInterceptEventArgs>(this.Core_ChatBoxMessage);
                CoreManager.Current.WorldFilter.CreateObject -= new EventHandler<CreateObjectEventArgs>(this.WorldFilter_CreateObject);
                /* 
                CoreManager.Current.WorldFilter.ReleaseObject -= new EventHandler<ReleaseObjectEventArgscorn pep>(this.WorldFilter_ReleaseObject);
                CoreManager.Current.CharacterFilter.LoginComplete -= new EventHandler(this.CharacterFilter_LoginComplete_VHS);
                CoreManager.Current.ItemDestroyed -= new EventHandler<ItemDestroyedEventArgs>(ItemDestroyed_EventArgs);
                CoreManager.Current.WorldFilter.ChangeObject -= new EventHandler<ChangeObjectEventArgs>(ChangeObject_EventArgs);
                */
            }
            catch (Exception ex) { Util.LogError(ex); }
        }

        private void Core_ChatBoxMessage(object sender, Decal.Adapter.ChatTextInterceptEventArgs e)
        {
            Util.WriteToChat(e.Text);
            if (e.Text.Contains("A fine reward for your formidable deed"))
            {
                Util.WriteToChat("Contains Check Is Good");
                if (TurnInFlag)
                {
                    Util.WriteToChat("Flag Is Good");
                    Util.WriteToChat(IvoryCrafter.TurnInIvory());
                    TurnInFlag = IvoryCrafter.GenerateItemLists();
                }

            }


        }

        [BaseEvent("ChangeObject", "WorldFilter")]
        void WorldFilter_ChangeObject(object sender, ChangeObjectEventArgs e)
        {
            /*
            try
            {
                // This can get very spammy so I filted it to just print on ident received
                if (e.Change == WorldChangeType.IdentReceived)
                    Util.WriteToChat("WorldFilter_ChangeObject: " + e.Changed.Name + " " + e.Change);
            }
            catch (Exception ex) { Util.LogError(ex); }
            */
        }

        void WorldFilter_ChangeObject2(object sender, ChangeObjectEventArgs e)
        {
        }




        [MVControlEvent("UseSelectedItem", "Click")]
        void UseSelectedItem_Click(object sender, MVControlEventArgs e)
        {
            /*
            try
            {
                if (Globals.Host.Actions.CurrentSelection == 0 || Globals.Core.WorldFilter[Globals.Host.Actions.CurrentSelection] == null)
                {
                    Util.WriteToChat("UseSelectedItem no item selected");

                    return;
                }

                Util.WriteToChat("UseSelectedItem " + Globals.Core.WorldFilter[Globals.Host.Actions.CurrentSelection].Name);

                Globals.Host.Actions.UseItem(Globals.Host.Actions.CurrentSelection, 0);
            }
            catch (Exception ex) { Util.LogError(ex); }
            */
        }

        [MVControlEvent("ToggleAttack", "Click")]
        void ToggleAttack_Click(object sender, MVControlEventArgs e)
        {
            /*
            try
            {
                Util.WriteToChat("ToggleAttack");

                if (Globals.Host.Actions.CombatMode == CombatState.Peace)
                    Globals.Host.Actions.SetCombatMode(CombatState.Melee);
                else
                    Globals.Host.Actions.SetCombatMode(CombatState.Peace);
            }
            catch (Exception ex) { Util.LogError(ex); }
            */
        }

        [MVControlEvent("DoesNothing", "Click")]
        void DoesNothing_Click(object sender, MVControlEventArgs e)
        {
            /*
            try
            {

            }
            catch (Exception ex) { Util.LogError(ex); }
            */
        }





        [MVControlReference("SampleList")]
        private IList SampleList = null;

        private void InitSampleList()
        {
            /*
            foreach (WorldObject worldObject in Globals.Core.WorldFilter.GetByContainer(Globals.Core.CharacterFilter.Id))
            {
                IListRow row = SampleList.Add();

                row[0][1] = worldObject.Icon + 0x6000000; // Notice we're using an index of 1 for the second parameter. That's because this is a DecalControls.IconColumn column.
                row[1][0] = worldObject.Name;


                if (worldObject.Values(LongValueKey.EquippedSlots) > 0)
                {
                }

                if (worldObject.Values(LongValueKey.Slot, -1) == -1)
                {
                }

                if (worldObject.HasIdData)
                {
                    int currentMana = worldObject.Values(LongValueKey.CurrentMana);
                }

 }
            */
        }

        [MVControlReference("SampleListText")]
        private IStaticText SampleListText = null;

        [MVControlReference("SampleListCheckBox")]
        private ICheckBox SampleListCheckBox = null;

        [MVControlEvent("SampleListCheckBox", "Change")]
        void SampleListCheckBox_Change(object sender, MVCheckBoxChangeEventArgs e)
        {
            /*
            try
            {
                Util.WriteToChat("SampleListCheckBox_Change " + SampleListCheckBox.Checked);

                SampleListText.Text = SampleListCheckBox.Checked.ToString();
            }
            catch (Exception ex) { Util.LogError(ex); }
            */
        }

        private void Core_CommandLineText(object sender, ChatParserInterceptEventArgs e)
        {

            string Text = e.Text.ToLower().TrimEnd();

            switch (Text)
            {
                case "/dt help":
                    Util.WriteToChat("/dt doesNothing");
                    Util.WriteToChat("/dt nothingDoes");
                    Util.WriteToChat("/dt nothingNothing");
                    break;
                case "/dt test":
                    Util.WriteToChat("Test Successful!");
                    break;
                case "/dt add_notes_and_kits":
                case "//dt ank":
                    Util.WriteToChat("Chat Command Noticed, attemping CS!");
                    BuyingUtils.AddKitsAndNotesToBuyTab();
                    break;
                case "/dt sell_all_buy_tab":
                case "//dt sabt":
                    BuyingUtils.SellAllBuyTab();
                    break;
                case "/dt what_does_eglaema_have":
                case "//dt wdeh":
                    TestSpyMethod();
                    break;
                case "//dt otv":
                    //AunMareuraTheCollector.TestBuyTokens();
                    break;
                case "/dt turn_in_wings":
                    TurnInFlag = true;
                    Util.WriteToChat(WingCollector.TurnInWings());
                    break;
                case "/dt turn_in_ivory":
                    TurnInFlag = true;
                    Util.WriteToChat("Test");
                    //Util.WriteToChat(IvoryCrafter.TurnInIvory());
                    break;
                case "/dt turn_in_collector":
                    TurnInFlag = true;
                    Util.WriteToChat(Collector.TurnInStuff());
                    break;
                case "/dt turn_in_triangles":
                    TurnInFlag = true;
                    Util.WriteToChat(RenselmsApprentice.TurnInTriangles());
                    break;
                case "/dt disable_turn_in_flag":
                    TurnInFlag = false;
                    break;


            } // don't put a default in this switch, that is bad


        }

        private void TestSpyMethod()
        {
            WorldObjectCollection Eglaimas_Items =  Globals.Core.WorldFilter.GetByOwner(1342179683);
            foreach (WorldObject eItem in Eglaimas_Items)
            {
                Util.WriteToChat("Spy: " + eItem.Name + " with ID of " + eItem.Id);
            }
        }


        //[BaseEvent("CreateObject", "WorldFilter")]
        private void WorldFilter_CreateObject(object sender, CreateObjectEventArgs e)
        {

            WorldObject worldObject = e.New;
            if (e.New.ObjectClass == ObjectClass.Player)
            {
                if (worldObject.Values(LongValueKey.Monarch) == 0)
                {
                    Util.WriteToChat("Unaligned Player Detected: " + worldObject.Name, ChatUtil.Color.orange);
                    if (LogOnUnknownFlag)
                    {
                        Logout();
                        Util.WriteToChat("LOGGING OUT!!!", ChatUtil.Color.white);
                    }

                }
                else if ((Globals.Core.CharacterFilter.Monarch != null) && (Globals.Core.CharacterFilter.Monarch.Id == worldObject.Values(LongValueKey.Monarch)))
                {
                    Util.WriteToChat("Ally Detected: " + worldObject.Name + " :: " + worldObject.Values(StringValueKey.MonarchName), ChatUtil.Color.orange);
                    if (LogOnFriendlyFlag)
                    {
                        Logout();
                        Util.WriteToChat("LOGGING OUT!!!", ChatUtil.Color.white);
                    }
                }
                else
                {
                    Util.WriteToChat("Enemy Detected: " + worldObject.Name + " :: " + worldObject.Values(StringValueKey.MonarchName), ChatUtil.Color.orange);
                    if (LogOnPkFlag)
                    {
                        Logout();
                        Util.WriteToChat("LOGGING OUT!!!", ChatUtil.Color.white);
                    }
                }
            }
        }

        private void Logout()
        {
            for (int i = 0; i < 100; i++)
            {
                Host.Actions.Logout();
            }
        }
    }
}
