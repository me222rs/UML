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

        MenuView mv;
        BoatModel boatModel;
        BoatView boatView;
        MemberView memberView;
        MemberModel memberModel;

        public MenuController()
        {

            boatModel = new BoatModel();
            memberModel = new MemberModel();
            mv = new MenuView();
            memberView = new MemberView();
            boatView = new BoatView();


            //memberTextFile = memberModel.getMemberTextFile;

            //boatModel.SetMemberTextfile(memberTextFile);

        }

        public void MenuChoice()
        {
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
                        boatModel.AddBoat(boatView.getBoatNumber(), boatView.getSelectedBoatType(), boatView.getLength());
                        break;
                    case 8:
                        boatView.RemoveBoat(boatModel.ViewAllboats());//Tar bort en befintlig båt
                        boatModel.RemoveBoat(boatView.getBoatNumber());
                        break;
                    case 9:
                        boatView.EditBoat(boatModel.ViewAllboats());//Redigerar en båt
                        boatModel.Editboat(boatView.getBoatNumber(), boatView.getSelectedBoatType(), boatView.getLength());
                        break;
                }
                mv.ContinueOnKeyPressed();
            } while (true);
        }
    }
}
