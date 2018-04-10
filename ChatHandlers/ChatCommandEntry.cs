using System;
using System.Collections.Generic;
using System.Text;
using DucasTest.Inventory;
using DucasTest.Npcs;
using DucasTest.Vendors;

namespace DucasTest.ChatHandlers
{
    class ChatCommandEntry
    {

        public static void ProcessCommand(string Text)
        {

            // @TODO: this is ugly, not sure how to make it better, probably some sort of JSON or CSV config file would be easier to maintain           

            switch (Text)
            {
                case "/dt help":
                    Util.WriteToChat("/dt turnin help -- help on turn in commands");
                    Util.WriteToChat("/dt add help -- help on add to vendor commands");
                    Util.WriteToChat("/dt sell help -- help on selling commands");
                    Util.WriteToChat("/dt vitae help -- immediately provides assistance in gaining vitae points");
                    break;
                case "/dt vitae help":
                    Globals.Host.Actions.Logout();
                    break;
                case "/dt test":
                    Util.WriteToChat("Test Successful!");
                    break;
                case "/dt add notes_and_kits":
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
                    break;
                case "//dt otv":
                    //AunMareuraTheCollector.TestBuyTokens();
                    break;
                case "/dt turnin help":
                    Util.WriteToChat("/dt turnin ivorycrafter - this turns in one item to an Ivory Crafter\n" +
                        "/dt turnin wingcollector - this turns in one item to a Wing Collector\n" +
                        "/dt turnin collector - this turns in one item to a regular collector\n" +
                        "/dt turnin AunMareura - this turns in one item to Aun Mareura the Collector\n" +
                        "**these commands are not case sensitive");
                    break;
                case "/dt turnin wingcollector":
                    //TurnInFlag = true;
                    Util.WriteToChat(WingCollector.TurnIn());// TurnInWings());
                    break;
                case "/dt turnin ivorycrafter":
                    //TurnInFlag = true;
                    Util.WriteToChat("Test");
                    Util.WriteToChat(IvoryCrafter.TurnIn());
                    break;
                case "/dt turn_in_collector":
                    //TurnInFlag = true;
                    Util.WriteToChat(Collector.TurnInStuff());
                    break;
                case "/dt turn_in_triangles":
                    //TurnInFlag = true;
                    Util.WriteToChat(RenselmsApprentice.TurnInTriangles());
                    break;
                case "/dt disable_turn_in_flag":
                    //TurnInFlag = false;
                    break;
                case "/dt combine_salvage":
                    Util.WriteToChat(CombineSalvage.Combine());
                    break;


            } // don't put a default in this switch, that is bad


        }

    }
}
