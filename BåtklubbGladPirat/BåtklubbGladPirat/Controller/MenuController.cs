using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BåtklubbGladPirat.View;
using BåtklubbGladPirat.Model;


namespace BåtklubbGladPirat.Controller
{
    class MenuController
    {
        private const string memberTextFile = "./medlem.txt";
        private const string boatTextFile = "./boat.txt";
        public void MenuChoice(){

            MenuView mv = new MenuView();
            MemberView memberView = new MemberView();
            MemberModel memberModel = new MemberModel(memberTextFile);
            BoatView boatView = new BoatView();
            BoatModel boatModel = new BoatModel(boatTextFile, memberTextFile);
            do
            {
                
                switch (mv.GetMenuChoice())//Visar menyn
                {
                    case 0:
                        return; //Avsluta 
                    case 1:
                        memberView.CreateMember();//Skapa ny medlem
                        memberModel.CreateMember(memberView.getFName(), memberView.getPersonId());
                        break;
                    case 2:
                        memberView.ViewCompactListMembers(memberModel.ViewCompactListMembers());//Visa medlemmar med hur många båtar de har
                        break;
                    case 3:
                        memberView.ViewAllMembers(memberModel.ViewCompleteMembers()); // Visa alla medlemmar med deras båtar
                        break;
                    case 4:
                        memberView.DeleteMember(memberModel.ViewAllMembers());// Ta bort medlem
                        memberModel.DeleteMember(memberView.getMemberNumber());
                        break;
                    case 5:
                        memberView.EditMember(memberModel.ViewAllMembers());// Redigera medlem
                        memberModel.EditMember(memberView.getMemberNumber(), memberView.getFName(), memberView.getPersonId());
                        break;
                    case 6:
                        memberView.ShowMember(memberModel.ViewCompactListMembers(), memberModel.ViewAllMembers());//Visa en enstaka medlem
                        break;
                    case 7:
                        boatView.AddBoat(memberModel.ViewAllMembers());//Lägger till en ny båt
                        boatModel.AddBoat(memberView.getMemberNumber(), boatView.getType(), boatView.getLength());
                        break;
                    //case 8:
                    //    program.RemoveBoat();//Tar bort en befintlig båt
                    //    break;
                    //case 9:
                    //    program.EditBoat();//Redigerar en båt
                    //    break;
                }
                mv.ContinueOnKeyPressed();
            } while (true);
        }


    }
}
