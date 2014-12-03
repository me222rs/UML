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
        public MenuController()
        {
            boatModel = new BoatModel();
            memberModel = new MemberModel();
            mv = new MenuView();
            memberView = new MemberView();
            boatView = new BoatView();
            memberList = new List<Member>(100);

            GetLists();
        }

        public void GetLists() 
        {
            memberList = memberModel.getAllMembers();
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
                        memberModel.DeleteMember(memberView.getMember(), memberList);
                        break;
                    case 5:
                        memberView.EditMember(memberList);// Redigera medlem
                        memberModel.EditMember(memberView.getMember(), memberView.getFName(), memberView.getPersonId(), memberList);
                        break;
                    case 6:
                        memberView.ShowMember(memberList);//Visa en enstaka medlem
                        break;
                    case 7:
                        boatView.AddBoat(memberList);//Lägger till en ny båt
                        boatModel.AddBoat(boatView.getMember(), boatView.getSelectedBoatType(), boatView.getLength(), memberList);
                        break;
                    case 8:
                        boatView.RemoveBoat(memberList);//Tar bort en befintlig båt
                        boatModel.RemoveBoat(boatView.getMember(), boatView.getBoat());
                        break;
                    case 9:
                        boatView.EditBoat(memberList);//Redigerar en båt
                        boatModel.Editboat(boatView.getMember(), boatView.getBoat(), boatView.getSelectedBoatType(), boatView.getLength());
                        break;
                    case 10:
                        memberModel.SaveMembers(memberList);
                        break;
                }
                mv.ContinueOnKeyPressed();
            } while (true);
        }
    }
}
