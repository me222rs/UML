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
        List<Member> memberList;
        List<Boat> boatList;
        public MenuController()
        {
            boatModel = new BoatModel();
            memberModel = new MemberModel();
            mv = new MenuView();
            memberView = new MemberView();
            boatView = new BoatView();
            memberList = new List<Member>(100);

            memberList = memberModel.getAllMembers();
            boatList = boatModel.getAllBoats();
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
                        memberModel.CreateMember(memberView.getFName(), memberView.getPersonId(), memberList);
                        break;
                    case 2:
                        memberView.ViewCompactListMembers(memberList);//Visa medlemmar med hur många båtar de har
                        break;
                    case 3:
                        memberView.ViewAllMembers(memberList); // Visa alla medlemmar med deras båtar
                        break;
                    case 4:
                        memberView.DeleteMember(memberList);// Ta bort medlem
                        memberModel.DeleteMember(memberView.getMember(), memberList, boatList);
                        break;
                    case 5:
                        memberView.EditMember(memberList);// Redigera medlem
                        memberModel.EditMember(memberView.getMember(), memberView.getFName(), memberView.getPersonId(), memberList);
                        break;
                    case 6:
                        memberView.ShowMember(memberList, boatList);//Visa en enstaka medlem
                        break;
                    case 7:
                        boatView.AddBoat(memberList);//Lägger till en ny båt
                        boatModel.AddBoat(boatView.getMember(), boatView.getSelectedBoatType(), boatView.getLength(), boatList);
                        break;
                    case 8:
                        boatView.RemoveBoat(boatList);//Tar bort en befintlig båt
                        boatModel.RemoveBoat(boatView.getBoat(), boatList);
                        break;
                    case 9:
                        boatView.EditBoat(boatList);//Redigerar en båt
                        boatModel.Editboat(boatView.getBoat(), boatView.getSelectedBoatType(), boatView.getLength(), boatList);
                        break;
                    case 10:
                        memberModel.SaveMembers(memberList);
                        boatModel.SaveBoats(boatList);
                        break;
                }
                mv.ContinueOnKeyPressed();
            } while (true);
        }
    }
}
